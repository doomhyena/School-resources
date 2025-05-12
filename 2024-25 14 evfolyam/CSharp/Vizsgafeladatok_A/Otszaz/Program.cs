using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otszaz
{
	internal class Program
	{
		static List<Vasarlas> kosarak = new List<Vasarlas>();
		static string prodName;
		static int darab, vSzam;
		static void Main(string[] args)
		{
			Feladat_1();
			Feladat_2();
			Feladat_3();
			Feladat_4();
			Feladat_5();
			Feladat_6();
			Feladat_7();
			Feladat_8();
			//----------------------
			Console.WriteLine("- VÉGE - ");
			Console.ReadKey();
		}

		private static void Feladat_8()
		{
			Console.WriteLine("7. feladat");
			foreach (var item in kosarak)
			{
				Console.WriteLine($"{item.No,3} {item.Kosar.Sum(q => Ertek(q.Value))}");
			}
		}

		private static void Feladat_7()
		{
			Console.WriteLine("7. feladat");
			foreach (var item in kosarak.First(q => q.No == vSzam).Kosar)
			{
				Console.WriteLine($"{item.Value,2} {item.Key}");
			}
		}

		private static void Feladat_6()
		{
			Console.WriteLine("6. feladat");
			Console.WriteLine($"{darab} darab vételekor fizetendő: {Ertek(darab)}");
		}

		private static int Ertek(int darab)
		{
			if (darab < 2)
			{
				return 500;
			}
			else if (darab < 3)
			{
				return 950;
			}
			else
			{
				return 950 + (darab - 2) * 400;
			}
		}

		private static void Feladat_5()
		{
			Console.WriteLine("5. feladat");
			var result = kosarak.Where(q => q.Kosar.ContainsKey(prodName)).ToList();
			Console.WriteLine($"Az első vásárlás sorszáma: {result.First().No} " +
				$" \r\nAz utolsó vásárlás sorszáma: {result.Last().No} " +
				$"\r\n{result.Count} vásárlás során vettek belőle.");

		}

		private static void Feladat_4()
		{
			Console.WriteLine("4. feladat");
			Console.Write("Adja meg egy vásárlás sorszámát: ");
			int.TryParse(Console.ReadLine(), out vSzam);
			Console.Write("Adja meg egyárúcikk nevét: ");
			prodName = Console.ReadLine();
			Console.Write("Adja meg a vásárolt darabszámot");
			int.TryParse(Console.ReadLine(), out darab);

		}

		private static void Feladat_3()
		{
			Console.WriteLine("3. feladat");
			Console.WriteLine($"Az első vásárló {kosarak.First().Kosar.Sum(q => q.Value)} darab árucikket vásárolt. ");
		}

		private static void Feladat_2()
		{
			Console.WriteLine("2. feladat");
			Console.WriteLine($"A fizetések száma: {kosarak.Count}");
		}

		private static void Feladat_1()
		{
			string sor;
			Vasarlas v = new Vasarlas();
			try
			{
				using (StreamReader sr = new StreamReader("penztar.txt"))
				{
					while ((sor = sr.ReadLine()) != null)
					{
						if (sor == "F")
						{
							kosarak.Add(v);
							v = new Vasarlas();
						}
						else
						{
							if (!v.Kosar.ContainsKey(sor))
							{
								v.Kosar.Add(sor, 1);
							}
							else
							{
								v.Kosar[sor]++;
							}
						}
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}

	public class Vasarlas
	{
		static int _id = 1;
		public int No { get; set; }
		public Dictionary<string, int> Kosar { get; set; }

		public Vasarlas()
		{
			No = _id++;
			Kosar = new Dictionary<string, int>();
		}
	}
}
