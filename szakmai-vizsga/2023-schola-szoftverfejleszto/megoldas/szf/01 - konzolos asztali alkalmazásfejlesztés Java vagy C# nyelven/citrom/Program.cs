using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace citrom
{
    class Citromos
    {
        public string Megnevezes { get; }
        public int Ar { get; }
        public string Kategoria { get; }

        public Citromos(string megnevezes, int ar, string kategoria) {
            Megnevezes = megnevezes;
            Ar = ar;
            Kategoria = kategoria;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var citromosok = new List<Citromos>();
            var filePath = "citrom.csv";

            foreach (var line in File.ReadLines(filePath, Encoding.UTF8).Skip(1)) {
                var parts = line.Split(';');
                if (parts.Length == 3) {
                    string megnevezes = parts[0];
                    int ar = int.Parse(parts[1]);
                    string kategoria = parts[2];
                    citromosok.Add(new Citromos(megnevezes, ar, kategoria));
                }
            }

            double atlagAr = citromosok.Average(c => c.Ar);
            Console.WriteLine($"4. feladat: Átlagár: {atlagAr:0.00} Ft");

            Console.WriteLine("5. feladat: Kategóriánkénti összár:");
            var kategoriak = citromosok
                .GroupBy(c => c.Kategoria)
                .Select(g => new { Kategoria = g.Key, Osszeg = g.Sum(c => c.Ar) });

            foreach (var kat in kategoriak) {
                Console.WriteLine($"{kat.Kategoria}: {kat.Osszeg} Ft");
            }
        }
    }
}
