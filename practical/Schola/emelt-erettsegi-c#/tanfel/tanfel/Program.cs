using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanfel
{
    internal class Program
    {
        static List<Tanar> tanar = new List<Tanar>();
        static void Main(string[] args)
        {
            FileBeolvasas();
            Feladat2();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            ///--------------------
            Console.WriteLine("VÉGE");
            Console.ReadKey();
        }


        private static void FileBeolvasas()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"beosztas.txt"))
                {
                    string sor1, sor2, sor3;
                    int sor4;
                    while (!sr.EndOfStream)
                    {
                        sor1 = sr.ReadLine();
                        sor2 = sr.ReadLine();
                        sor3 = sr.ReadLine();
                        sor4 = int.Parse(sr.ReadLine());
                        tanar.Add(new Tanar(sor1, sor2, sor3, sor4));
                    }
                }
                Console.WriteLine("1.feladat:");
                Console.WriteLine("Fájl beolvasása sikeres!");
            }
            catch (Exception ex)
            {
               string hiba = ex.Message;
               Console.WriteLine("1.feladat:");
               Console.WriteLine("Hiba történt a fájl beolvasása során: " + hiba);
            }
        }

        private static void Feladat2()
        {
            Console.WriteLine("2. feladat:");
            Console.Write("Fájlban lévő sorok száma: ");
            Console.WriteLine(tanar.Count);
        }
        private static void Feladat3()
        {
            Console.WriteLine("3. feladat:");
            int osszesOra = tanar.Sum(t => t.Oraszam);
            Console.WriteLine("Összes tanítási óra száma: " + osszesOra);
        }

        private static void Feladat4()
        {
            Console.WriteLine("4.feladat: ");
            Console.Write("Kérem adja meg egy tanár nevét: ");
            string nev = Console.ReadLine();
            Tanar tanar1 = tanar.FirstOrDefault(t => t.Nev.Equals(nev, StringComparison.OrdinalIgnoreCase));
            if (tanar1 != null)
            {
                Console.WriteLine($"{tanar1.Nev} hetente {tanar1.Oraszam} órában tanít.");
            }
            else
            {
                Console.WriteLine("Nincs ilyen nevű tanár a listában.");
            }
        }

        private static void Feladat5()
        {
            Console.WriteLine("5.feladat: ");

            try
            {
                using (StreamWriter sw = new StreamWriter("of.txt", false))
                {
                    foreach (Tanar t in tanar)
                    {
                        if (t.Osztaly.Equals("osztalyfonok", StringComparison.OrdinalIgnoreCase))
                        {
                            sw.WriteLine(t.Nev + " - " + t.Osztaly);
                        }
                    }
                }
                Console.WriteLine("Sikeres fájlba írás.");
            }
            catch (Exception ex)
            {
                string hiba = ex.Message;
                Console.WriteLine("Hiba történt a fájl írása során: " + hiba);
            }
        }

        private static void Feladat6()
        {
            Console.WriteLine("6.feladat: ");

            Console.Write("Kérem adjon meg egy osztály: ");
            string osztaly = Console.ReadLine();
            Console.Write("Kérem adjon meg egy tantárgy nevét: ");
            string tantargy = Console.ReadLine();

            int count = tanar.Count(t => t.Osztaly.Equals(osztaly, StringComparison.OrdinalIgnoreCase) && t.Tantargy.Equals(tantargy, StringComparison.OrdinalIgnoreCase));
            if (count > 1)
            {
                Console.WriteLine($"Az osztály a {tantargy} tantárgyat csoportbontásban tanulja.");
            }
            else
            {
                Console.WriteLine($"Az osztály a {tantargy} tantárgyat osztályszinten tanulja.");
            }
        }

        private static void Feladat7()
        {
            Console.WriteLine("7.feladat: ");
            int tanarSzam = tanar.Count;
            Console.WriteLine($"Az iskolában {tanarSzam} tanár dolgozik.");
        }

        public class Tanar
        {
            public string Nev { get; set; }
            public string Tantargy { get; set; }
            public string Osztaly { get; set; }
            public int Oraszam { get; set; }


            public Tanar(string nev, string tantargy, string osztaly, int oraszam)
            {
                Nev = nev;
                Tantargy = tantargy;
                Osztaly = osztaly;
                Oraszam = oraszam;
            }
        }
    }
}
