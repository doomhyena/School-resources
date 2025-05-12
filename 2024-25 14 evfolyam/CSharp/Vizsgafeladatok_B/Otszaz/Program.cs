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
		static List<Vasarlas> vasarlasok = new List<Vasarlas>();
		static int vSorszam, db;
		static string aru;
		static void Main(string[] args)
		{
			Feladat_1();
			Feladat_2();
			Feladat_3();
			Feladat_4();
			Feladat_5();
			Feladat_7();
			Feladat_8();
			//---------------
			Console.WriteLine("- VÉGE -");
			Console.ReadKey();
		}

		private static void Feladat_8()
		{
			Console.WriteLine("8. feladat");
			foreach (var item in vasarlasok)
			{
				Console.WriteLine($"\t{item.No}: {item.Kosar.Sum(q => Ertek(q.Value))}");
				;
			}
		}

		private static void Feladat_7()
		{
			Console.WriteLine("7. feladat");
			foreach (var item in vasarlasok.First(q => q.No == vSorszam).Kosar)
			{
				Console.WriteLine($"\t{item.Value} {item.Key}");
			}
		}

		private static int Ertek(int _db)
		{
			if (_db == 1)
			{
				return 500;
			}
			else if (_db == 2)
			{
				return 950;
			}
			else
			{
				return 950 + (_db - 2) * 400;
			}
		}

		private static void Feladat_5()
		{
			Console.WriteLine("5. feladat");
			var result = vasarlasok.Where(v => v.Kosar.ContainsKey(aru)).ToList();
			Console.WriteLine($"\tAz első vásárlás sorszáma: {result.First().No}");
			Console.WriteLine($"\tAz utolsó vásárlás sorszáma: {result.Last().No}");
			Console.WriteLine($"\t{result.Count} vásárlás során vettek belőle.");
		}

		private static void Feladat_4()
		{
			Console.WriteLine("4. feladat");
			Console.Write($"\tAdd meg egy vásárlás sorszámát: ");
			int.TryParse(Console.ReadLine(), out vSorszam);
			Console.Write("\tAdd meg egy áru nevét: ");
			aru = Console.ReadLine();
			Console.Write($"\tAdj meg egy darabszámot: ");
			int.TryParse(Console.ReadLine(), out db);
		}

		private static void Feladat_3()
		{
			Console.WriteLine("3. feladat");
			Console.WriteLine($"Az első vásárló {vasarlasok.First().Kosar.Sum(q => q.Value)} darab árucikket vásárolt. ");
		}

		private static void Feladat_2()
		{
			Console.WriteLine("2. feladat");
			Console.WriteLine($"A fizetések száma: {vasarlasok.Count}");
		}

		private static void Feladat_1()
		{
			string sor;
			Vasarlas v;
			try
			{
				using (StreamReader sr = new StreamReader("penztar.txt"))
				{
					v = new Vasarlas();
					while ((sor = sr.ReadLine()) != null)
					{
						if (sor != "F")
						{
							if (!v.Kosar.ContainsKey(sor))
							{
								v.Kosar.Add(sor, 0);
							}
							v.Kosar[sor]++;
						}
						else
						{
							vasarlasok.Add(v);
							v = new Vasarlas();
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
		static int _no = 1;
		public int No { get; }
		public Dictionary<string, int> Kosar { get; set; }
		public Vasarlas()
		{
			No = _no++;
			Kosar = new Dictionary<string, int>();
		}
	}
}
