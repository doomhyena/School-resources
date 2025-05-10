using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2008robot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- 1. feladat ---");
            List<string> programok = new List<string>();

            try
            {
                var sorok = File.ReadAllLines("program.txt");
                int programokSzama = int.Parse(sorok[0]);
                for (int i = 1; i <= programokSzama; i++)
                {
                    programok.Add(sorok[i]);
                }
                Console.WriteLine($"A sorok száma: {programokSzama} db");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nem sikerült beolvasni a fájlt. Ellenőrizze, hogy a 'program.txt' fájl elérhető és megfelelő formátumú.");
                return;
            }

            Console.WriteLine("--- 2. feladat ---");
            int sorszam;
            if (!int.TryParse(Console.ReadLine(), out sorszam) || sorszam < 1 || sorszam > programok.Count)
            {
                Console.WriteLine("Hibás sorszám!");
                return;
            }

            string utasitasSor = programok[sorszam - 1];

            Console.WriteLine("--- 2.1 feladat ---");
            if (Egyszerusitheto(utasitasSor))
            {
                Console.WriteLine("Egyszerűsíthető");
            }
            else
            {
                Console.WriteLine("Nem egyszerűsíthető");
            }

            Console.WriteLine("--- 2.2. feladat ---");
            VisszajutasiLepesek(utasitasSor);

            Console.WriteLine("--- 2.3. feladat ---");
            LegnagyobbTavolsag(utasitasSor);

            Console.WriteLine("--- 3. feladat ---");

            for (int i = 0; i < programok.Count; i++)
            {
                int energia = SzuksgesEnergia(programok[i]);
                Console.WriteLine($"{i + 1}. sor: {energia} J");
            }

            // Házi feladat

            Console.WriteLine("--- 4. feladat ---");
            try
            {
                using (StreamWriter sw = new StreamWriter("ujprog.txt"))
                {
                    foreach (var program in programok)
                    {
                        string roviditett = RoviditettForma(program);
                        sw.WriteLine(roviditett);
                    }
                }
                Console.WriteLine("Az ujprog.txt fájl elkészült.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba az ujprog.txt fájl írása közben: {ex.Message}");
            }

            Console.WriteLine("--- 5. feladat ---");
            Console.WriteLine("Kérem az új formátumú utasítássort:");
            string ujForma = Console.ReadLine();

            try
            {
                string regiForma = VisszaalakitasRegiFormara(ujForma);
                Console.WriteLine($"Régi formátum: {regiForma}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba az átalakítás során: {ex.Message}");
            }

            Console.ReadKey();
        }

        static bool Egyszerusitheto(string utasitasSor)
        {
            for (int i = 0; i < utasitasSor.Length - 1; i++)
            {
                string par = utasitasSor.Substring(i, 2);
                if (par == "ED" || par == "DE" || par == "KN" || par == "NK")
                {
                    return true;
                }
            }
            return false;
        }

        static void VisszajutasiLepesek(string utasitasSor)
        {
            int kelet = 0, eszak = 0;

            foreach (char utasitas in utasitasSor)
            {
                switch (utasitas)
                {
                    case 'E': kelet++; break;
                    case 'D': kelet--; break;
                    case 'K': eszak++; break;
                    case 'N': eszak--; break;
                }
            }

            Console.WriteLine($"{Math.Abs(kelet)} lépést kell tenni az ED, {Math.Abs(eszak)} lépést a KN tengely mentén.");
        }

        static void LegnagyobbTavolsag(string utasitasSor)
        {
            int x = 0, y = 0;
            double maxTavolsag = 0;
            int maxLepes = 0;

            for (int i = 0; i < utasitasSor.Length; i++)
            {
                switch (utasitasSor[i])
                {
                    case 'E': x++; break;
                    case 'D': x--; break;
                    case 'K': y++; break;
                    case 'N': y--; break;
                }

                double tavolsag = Math.Sqrt(x * x + y * y);
                if (tavolsag > maxTavolsag)
                {
                    maxTavolsag = tavolsag;
                    maxLepes = i + 1;
                }
            }

            Console.WriteLine($"A legtávolabbi pont a {maxLepes}. lépés után volt, távolság: {maxTavolsag:F3} cm.");
        }

        static int SzuksgesEnergia(string utasitasSor)
        {
            int energia = 0;
            int x = 0, y = 0;
            foreach (char utasitas in utasitasSor)
            {
                switch (utasitas)
                {
                    case 'E': x++; break;
                    case 'D': x--; break;
                    case 'K': y++; break;
                    case 'N': y--; break;
                }
                energia += Math.Abs(x) + Math.Abs(y);
            }
            return energia;
        }
        static string RoviditettForma(string utasitasSor)
        {
            StringBuilder roviditett = new StringBuilder();
            int darab = 1;

            for (int i = 1; i <= utasitasSor.Length; i++)
            {
                if (i < utasitasSor.Length && utasitasSor[i] == utasitasSor[i - 1])
                {
                    darab++;
                }
                else
                {
                    if (darab > 1)
                    {
                        roviditett.Append(darab);
                    }
                    roviditett.Append(utasitasSor[i - 1]);
                    darab = 1;
                }
            }

            return roviditett.ToString();
        }
        static string VisszaalakitasRegiFormara(string ujForma)
        {
            StringBuilder regiForma = new StringBuilder();
            int i = 0;

            while (i < ujForma.Length)
            {
                if (char.IsDigit(ujForma[i]))
                {
                    int szamKezdete = i;
                    while (i < ujForma.Length && char.IsDigit(ujForma[i]))
                    {
                        i++;
                    }
                    int ismDb = int.Parse(ujForma.Substring(szamKezdete, i - szamKezdete));

                    if (i < ujForma.Length && char.IsLetter(ujForma[i]))
                    {
                        regiForma.Append(new string(ujForma[i], ismDb));
                    }
                }
                else if (char.IsLetter(ujForma[i]))
                {
                    regiForma.Append(ujForma[i]);
                }
                i++;
            }

            return regiForma.ToString();
        }

    }
}
