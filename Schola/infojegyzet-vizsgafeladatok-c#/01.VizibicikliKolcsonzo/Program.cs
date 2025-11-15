using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.VizibicikliKolcsonzo
{
    class Kolcsonzes
    {
        public string Nev { get; set; }
        public char JAzon { get; set; } 
        public TimeSpan Elvitel { get; set; }
        public TimeSpan Visszahozatal { get; set; }

        public Kolcsonzes(string nev, char jAzon, TimeSpan elvitel, TimeSpan visszahozatal)
        {
            Nev = nev;
            JAzon = jAzon;
            Elvitel = elvitel;
            Visszahozatal = visszahozatal;
        }

        public string IntervallumString()
        {
            return $"{Elvitel:hh\\:mm}-{Visszahozatal:hh\\:mm}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string forras = "kolcsonzesek.txt";

            List<Kolcsonzes> list = new List<Kolcsonzes>();

            try
            {
                var lines = File.ReadAllLines(forras, Encoding.UTF8);

                if (lines.Length <= 1) {
                    Console.WriteLine("Nincs adat a fájlban.");
                    return;
                }

                for (int i = 1; i < lines.Length; i++) {
                    string line = lines[i].Trim();
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var parts = line.Split(';');
                    if (parts.Length < 6) {
                        continue;
                    }

                    string nev = parts[0].Trim();

                    char jAzon = '?';
                    foreach (char c in parts[1]) {
                        if (char.IsLetter(c)) {
                            jAzon = char.ToUpper(c);
                            break;
                        }
                    }
                    if (jAzon == '?') continue;

                    bool parsed = int.TryParse(parts[2].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int eOra);
                    parsed &= int.TryParse(parts[3].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int ePerc);
                    parsed &= int.TryParse(parts[4].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int vOra);
                    parsed &= int.TryParse(parts[5].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int vPerc);

                    if (!parsed) continue;

                    TimeSpan elv = new TimeSpan(eOra, ePerc, 0);
                    TimeSpan vissza = new TimeSpan(vOra, vPerc, 0);
                    list.Add(new Kolcsonzes(nev, jAzon, elv, vissza));
                }
            } catch (FileNotFoundException) {
                Console.WriteLine($"Nem találom a {forras} fájlt. Kérlek helyezd a projekt mappájába vagy add meg a helyes fájlnevet.");
                return;
            } catch (Exception ex) {
                Console.WriteLine("Hiba a fájl beolvasásakor: " + ex.Message);
                return;
            }

            Console.WriteLine("5. feladat: Napi kölcsönzések száma: " + list.Count);

            Console.Write("6. feladat: Kérek egy nevet: ");
            string keresNev = Console.ReadLine()?.Trim() ?? "";

            var talalatok = list.Where(k => string.Equals(k.Nev, keresNev, StringComparison.CurrentCultureIgnoreCase)).ToList();

            if (talalatok.Count == 0) {
                Console.WriteLine("Nem volt ilyen nevű kölcsönző!");
            } else {
                Console.WriteLine(keresNev + " kölcsönzései:");
                foreach (var t in talalatok) {
                    Console.WriteLine($"{t.Elvitel:hh\\:mm}-{t.Visszahozatal:hh\\:mm}");
                }
            }

            Console.Write("7. feladat: Adjon meg egy idopontot ora:perc alakban: ");
            string idopontStr = Console.ReadLine()?.Trim() ?? "";
            bool parsedTime = TryParseHourMinute(idopontStr, out TimeSpan keresTime);
            if (!parsedTime) {
                Console.WriteLine("Hibás időpont formátum. Példa helyes formára: 10:09 vagy 9:5 stb.");
            } else {
                Console.WriteLine("A vízen lévő járművek:");
                var vizen = list.Where(k => k.Elvitel <= keresTime && keresTime < k.Visszahozatal)
                                .OrderBy(k => k.JAzon)
                                .ToList();

                foreach (var v in vizen) {
                    Console.WriteLine($"{v.Elvitel:hh\\:mm}-{v.Visszahozatal:hh\\:mm} : {v.Nev}");
                }
            }

            const int dijPerFelFelezo = 2400;
            long osszBevetel = 0;
            foreach (var k in list) {
                int perc = (int)(k.Visszahozatal - k.Elvitel).TotalMinutes;
                if (perc < 0) perc = 0; 
                int darabFelHarminc = (perc + 29) / 30; 
                osszBevetel += (long)darabFelHarminc * dijPerFelFelezo;
            }
            Console.WriteLine("8. feladat: A napi bevétel: " + osszBevetel + " Ft");

            string fFile = "F.txt";
            try {
                var fList = list.Where(k => k.JAzon == 'F').ToList();
                using (var sw = new StreamWriter(fFile, false, new UTF8Encoding(false)))
                {
                    sw.WriteLine("Név;Elvitel;Visszahozatal");
                    foreach (var f in fList)
                    {
                        sw.WriteLine($"{f.Nev};{f.Elvitel:hh\\:mm};{f.Visszahozatal:hh\\:mm}");
                    }
                }
                Console.WriteLine("9. feladat: Létrehoztam az F.txt fájlt az F jármű kölcsönzőivel.");
            } catch (Exception ex) {
                Console.WriteLine("Hiba az F.txt létrehozásakor: " + ex.Message);
            }

            Console.WriteLine("10. feladat: Statisztika");
            var azonositok = new[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G' };
            var stat = new Dictionary<char, int>();
            foreach (var a in azonositok) stat[a] = 0;
            foreach (var k in list) {
                if (stat.ContainsKey(k.JAzon)) stat[k.JAzon] += 1;
                else stat[k.JAzon] = 1; 
            }
            foreach (var a in azonositok) {
                Console.WriteLine($"{a} - {stat[a]}");
            }

            Console.ReadLine();
        }
        static bool TryParseHourMinute(string s, out TimeSpan t)
        {
            t = TimeSpan.Zero;
            if (string.IsNullOrWhiteSpace(s)) return false;
            s = s.Trim();
            var parts = s.Split(':');
            if (parts.Length != 2) return false;
            if (!int.TryParse(parts[0].Trim(), out int ora)) return false;
            if (!int.TryParse(parts[1].Trim(), out int perc)) return false;
            if (ora < 0 || ora > 23 || perc < 0 || perc > 59) return false;
            t = new TimeSpan(ora, perc, 0);
            return true;
        }
    }
}
