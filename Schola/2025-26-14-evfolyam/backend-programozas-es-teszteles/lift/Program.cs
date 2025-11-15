using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Lift
{
    internal class Program
    {
        private sealed class Request
        {
            public TimeSpan Time { get; set; }
            public int Team { get; set; }
            public int From { get; set; }
            public int To { get; set; }
        }

        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("1. feladat:");

            const string inputPath = "igeny.txt";
            int floorCount, teamCount;
            List<Request> requests;

            if (!TryReadInput(inputPath, out floorCount, out teamCount, out requests)) {
                Console.WriteLine("Beolvasási hiba volt, fallback adatokkal folytatom.");
                FallbackDataset(out floorCount, out teamCount, out requests);
            }

            Console.WriteLine("\n2. feladat:");
            Console.Write("Kérem a lift indulási szintjét: ");
            if (!int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var startFloor)) {
                startFloor = requests[0].From; 
            }
            startFloor = Math.Max(0, Math.Min(floorCount, startFloor));

            requests = requests.OrderBy(r => r.Time).ToList();

            var currentFloor = startFloor;
            var minTouched = currentFloor;
            var maxTouched = currentFloor;
            var upWithPassenger = 0;
            var upEmpty = 0;
            var usedTeams = new HashSet<int>();

            foreach (var req in requests) {
                if (currentFloor != req.From) {
                    if (req.From > currentFloor) upEmpty++;
                    minTouched = Math.Min(minTouched, Math.Min(currentFloor, req.From));
                    maxTouched = Math.Max(maxTouched, Math.Max(currentFloor, req.From));
                    currentFloor = req.From;
                }

                if (req.To > currentFloor) upWithPassenger++;
                minTouched = Math.Min(minTouched, Math.Min(currentFloor, req.To));
                maxTouched = Math.Max(maxTouched, Math.Max(currentFloor, req.To));
                currentFloor = req.To;

                usedTeams.Add(req.Team);
            }

            Console.WriteLine("\n3. feladat:");
            Console.WriteLine($"A lift a(z) {currentFloor}. szinten áll az utolsó igény teljesítése után.");

            Console.WriteLine("\n4. feladat:");
            Console.WriteLine($"Legalacsonyabb érintett szint: {minTouched}");
            Console.WriteLine($"Legmagasabb érintett szint: {maxTouched}");

            Console.WriteLine("\n5. feladat:");
            Console.WriteLine($"Felfelé indulások száma utassal: {upWithPassenger}");
            Console.WriteLine($"Felfelé indulások száma utas nélkül: {upEmpty}");

            Console.WriteLine("\n6. feladat:");
            var notUsed = Enumerable.Range(1, teamCount).Where(t => !usedTeams.Contains(t)).ToList();
            if (notUsed.Count == 0) {
                Console.WriteLine("Minden csapat használta a liftet.");
            } else {
                Console.WriteLine("A következő csapatok nem használták: " + string.Join(" ", notUsed));
            }

            Console.WriteLine("\n7. feladat:");
            var chosenTeam = PickRandomTeam(teamCount);
            if (chosenTeam < 1 || chosenTeam > teamCount) chosenTeam = 3;
            Console.WriteLine($"Vizsgált csapat: {chosenTeam}");

            var teamReqs = requests.Where(r => r.Team == chosenTeam).OrderBy(r => r.Time).ToList();
            var proven = false;
            var walkFrom = 0;
            var walkTo = 0;

            if (teamReqs.Count >= 2) {
                var lastArrived = teamReqs[0].To;
                for (int i = 1; i < teamReqs.Count; i++) {
                    var rr = teamReqs[i];
                    if (rr.From != lastArrived) {
                        proven = true;
                        walkFrom = lastArrived;
                        walkTo = rr.From;
                        break;
                    }
                    lastArrived = rr.To;
                }
            }

            Console.WriteLine(proven
                ? $"Bizonyítható szabálytalanság: gyalog mentek a {walkFrom}. és {walkTo}. szint között."
                : "Nem bizonyítható szabálytalanság.");

            Console.WriteLine("\n8. feladat – Blokkoló adatok pótlása");

            if (teamReqs.Count == 0) {
                Console.WriteLine("Ennek a csapatnak nincs igénye a vizsgált időszakban, nincs mit pótolni.");
                return;
            }

            const string outputPath = "blokkol.txt";
            using (var sw = new StreamWriter(outputPath, false, System.Text.Encoding.UTF8))
            {
                foreach (var ig in teamReqs) {
                    Console.WriteLine($"\nIdő: {FormatTime(ig.Time)} | Indulási emelet: {ig.From} | Célemelet: {ig.To}");

                    string success;
                    while (true) {
                        Console.Write("Sikeresség (befejezett / befejezetlen): ");
                        success = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();
                        if (success == "befejezett" || success == "befejezetlen") break;
                        Console.WriteLine("Csak „befejezett” vagy „befejezetlen” lehet. Próbáld újra!");
                    }

                    int code;
                    while (true) {
                        Console.Write("Feladatkód (1..99): ");
                        var s = (Console.ReadLine() ?? string.Empty).Trim();
                        if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out code) && code >= 1 && code <= 99)
                            break;
                        Console.WriteLine("A kódnak 1 és 99 közötti egésznek kell lennie.");
                    }

                    sw.WriteLine($"Befejezés ideje: {FormatTime(ig.Time)}");
                    sw.WriteLine($"Sikeresség: {success}");
                    sw.WriteLine("-----");
                    sw.WriteLine($"Indulási emelet: {ig.From}");
                    sw.WriteLine($"Célemelet: {ig.To}");
                    sw.WriteLine($"Feladatkód: {code}");
                }
            }

            Console.WriteLine($"\nKész ✅ A pótló adatok a(z) „{outputPath}” fájlba kerültek.");
        }
        private static bool TryReadInput(string path, out int floorCount, out int teamCount, out List<Request> requests)
        {
            floorCount = 0;
            teamCount = 0;
            requests = new List<Request>();

            if (!File.Exists(path)) return false;

            try {
                var lines = File.ReadAllLines(path)
                                .Where(l => !string.IsNullOrWhiteSpace(l))
                                .ToList();

                if (lines.Count < 4)
                    throw new InvalidDataException("Túl kevés sor az igeny.txt-ben.");

                floorCount = int.Parse(lines[0].Trim(), CultureInfo.InvariantCulture);
                teamCount = int.Parse(lines[1].Trim(), CultureInfo.InvariantCulture);
                var requestCountDeclared = int.Parse(lines[2].Trim(), CultureInfo.InvariantCulture);

                for (int i = 3; i < lines.Count; i++) {
                    var parts = lines[i].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 6) continue;

                    int hh = int.Parse(parts[0], CultureInfo.InvariantCulture);
                    int mm = int.Parse(parts[1], CultureInfo.InvariantCulture);
                    int ss = int.Parse(parts[2], CultureInfo.InvariantCulture);
                    int team = int.Parse(parts[3], CultureInfo.InvariantCulture);
                    int from = int.Parse(parts[4], CultureInfo.InvariantCulture);
                    int to = int.Parse(parts[5], CultureInfo.InvariantCulture);

                    requests.Add(new Request
                    {
                        Time = new TimeSpan(hh, mm, ss),
                        Team = team,
                        From = from,
                        To = to
                    });
                }

                if (requests.Count == 0)
                    throw new InvalidDataException("Nem találtam olvasható igényeket az állományban.");

                return true;
            } catch (Exception ex) {
                Console.WriteLine($"Beolvasási hiba: {ex.Message}");
                return false;
            }
        }

        private static string FormatTime(TimeSpan t) => $"{t.Hours}:{t.Minutes:00}:{t.Seconds:00}";

        private static void FallbackDataset(out int floorCount, out int teamCount, out List<Request> requests)
        {
            floorCount = 100;
            teamCount = 10;
            requests = new List<Request>
            {
                new Request{ Time = new TimeSpan(9,07,11), Team=7, From=6,  To=22 },
                new Request{ Time = new TimeSpan(9,10,30), Team=8, From=18, To=2  },
                new Request{ Time = new TimeSpan(9,11,00), Team=5, From=12, To=20 },
                new Request{ Time = new TimeSpan(9,15,42), Team=7, From=22, To=30 },
                new Request{ Time = new TimeSpan(9,32,10), Team=2, From=5,  To=1  },
                new Request{ Time = new TimeSpan(10,05,05),Team=3, From=1,  To=40 },
                new Request{ Time = new TimeSpan(10,20,00),Team=3, From=40, To=39 },
                new Request{ Time = new TimeSpan(10,55,12),Team=8, From=2,  To=25 },
            };
        }

        private static int PickRandomTeam(int teamCount)
        {
            try {
                var rng = new Random();
                return rng.Next(1, teamCount + 1);
            } catch {
                return 3;
            }
        }
    }
}
