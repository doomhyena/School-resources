using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _02.Jackie
{
    class Program
    {
        class Record
        {
            public int Year { 
                get; set; 
            }
            public int Races { 
                get; set; 
            }
            public int Wins { 
                get; set; 
            }
            public int Podiums { 
                get; set; 
            }
            public int Poles { 
                get; set; 
            }
            public int Fastests { 
                get; set; 
            }
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // 2. feladat
            List<Record> records = new List<Record>();
            string[] lines = File.ReadAllLines("jackie.txt", Encoding.UTF8);

            for (int i = 1; i < lines.Length; i++) {
                var parts = lines[i].Split('\t');
                records.Add(new Record
                {
                    Year = int.Parse(parts[0]),
                    Races = int.Parse(parts[1]),
                    Wins = int.Parse(parts[2]),
                    Podiums = int.Parse(parts[3]),
                    Poles = int.Parse(parts[4]),
                    Fastests = int.Parse(parts[5])
                });
            }

            // 3. feladat
            Console.WriteLine("3. feladat: " + records.Count + " adatsor található az állományban.");

            // 4. feladat
            var maxRaces = records.OrderByDescending(r => r.Races).First();
            Console.WriteLine("4. feladat: " + maxRaces.Year + " évben indult a legtöbb versenyen.");

            // 5. feladat
            Console.WriteLine("5. feladat:");
            var decades = records
                .GroupBy(r => (r.Year / 10) * 10)
                .Select(g => new { Decade = g.Key, TotalWins = g.Sum(r => r.Wins) })
                .OrderBy(d => d.Decade);

            foreach (var d in decades) {
                Console.WriteLine($"{d.Decade}-es évek: {d.TotalWins} megnyert verseny");
            }

            // 6. feladat
            Console.WriteLine("6. feladat: jackie.html létrehozása...");

            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine("<meta charset=\"UTF-8\">");
            html.AppendLine("<style>td { border:1px solid black; }</style>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("<h1>Jackie Stewart</h1>");
            html.AppendLine("<table>");

            foreach (var r in records) {
                html.AppendLine($"<tr><td>{r.Year}</td><td>{r.Races}</td><td>{r.Wins}</td><td>{r.Podiums}</td><td>{r.Poles}</td><td>{r.Fastests}</td></tr>");
            }

            html.AppendLine("</table>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            File.WriteAllText("jackie.html", html.ToString(), Encoding.UTF8);
            Console.WriteLine("jackie.html sikeresen létrehozva!");
        }
    }
}
