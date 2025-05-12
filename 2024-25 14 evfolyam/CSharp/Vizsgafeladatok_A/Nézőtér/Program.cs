using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nézőtér
{
	//http://informatika.fazekas.hu/wp-content/uploads/2015/10/e_prog_2014_okt.pdf
	internal class Program
	{
		static string[] foglaltsag = new string[15];
		static string[] kategoria = new string[15];
		static void Main(string[] args)
		{
			Feladat_1();
			//Feladat_2();
			Feladat_3();
			Feladat_4();
			Feladat_5();
			Feladat_6();
			Feladat_7();
			//-----------------
			Console.ReadKey();
		}

		private static void Feladat_7()
		{
			Console.WriteLine("7. feladat");
			for (int sor = 0; sor < foglaltsag.Length; sor++)
			{
				for (int szek = 0; szek < foglaltsag[sor].Length; szek++)
				{
					if (foglaltsag[sor][szek]=='x')
					{
						Console.Write('x');
					}
					else
					{
						Console.Write(kategoria[sor][szek]);
					}
				}
				Console.WriteLine();
			}
		}

		private static void Feladat_6()
		{
			Console.WriteLine("6. feladat");
			List<int> uresek = new List<int>();
			int darab = 0;
			for (int sor = 0; sor < foglaltsag.Length; sor++)
			{
				if (darab > 0)
				{
					uresek.Add(darab);
				}
				darab = 0;
				for (int szek = 0; szek < foglaltsag[sor].Length; szek++)
				{
					if (foglaltsag[sor][szek] == 'o')
					{
						darab++;
					}
					else
					{
						if (darab > 0)
						{
							uresek.Add(darab);
							darab = 0;
						}
					}
				}
			}
			Console.WriteLine($"\tÜres helyek : {uresek.Count(q => q == 1)}");
		}

		private static void Feladat_5()
		{
			Console.WriteLine("5. feladat");
			Dictionary<char, int> arak = new Dictionary<char, int>() {
				{'1',5000 },
				{'2',4000 },
				{'3',3000 },
				{'4',2000 },
				{'5',1500 },
			};
			int bevetel = 0;
			for (int sor = 0; sor < foglaltsag.Length; sor++)
			{
				for (int szek = 0; szek < foglaltsag[sor].Length; szek++)
				{
					if (foglaltsag[sor][szek] == 'x')
					{
						bevetel += arak[kategoria[sor][szek]];
					}
				}
			}

			Console.WriteLine($"\tBevétel= {bevetel:N0}Ft");
		}

		private static void Feladat_4()
		{
			Console.WriteLine("4. feladat");
			char legtobb = ' ';
			char cat;
			Dictionary<char, int> kategoriak = new Dictionary<char, int>();
			for (int sor = 0; sor < foglaltsag.Length; sor++)
			{
				for (int szek = 0; szek < foglaltsag[sor].Length; szek++)
				{
					if (foglaltsag[sor][szek] == 'x')
					{
						cat = kategoria[sor][szek];
						if (!kategoriak.ContainsKey(cat))
						{
							kategoriak.Add(cat, 0);
						}
						kategoriak[cat]++;
					}
				}
			}
			Console.WriteLine($"\tA legtöbb jegyet a(z) {kategoriak.OrderByDescending(q => q.Value).First().Key}. árkategóriában értékesítették.");
		}

		private static void Feladat_3()
		{
			Console.WriteLine("3. feladat");
			int foglalt = foglaltsag.Sum(q => q.Count(w => w == 'x'));
			//for (int sor = 0; sor < foglaltsag.Length; sor++)
			//{
			//	for (int szek = 0; szek < foglaltsag[sor].Length; szek++)
			//	{
			//		if (foglaltsag[sor][szek] == 'x')
			//		{
			//			foglalt++;
			//		}
			//	}
			//}
			double szazalek = (double)foglalt / 300 * 100;
			Console.WriteLine($"\tAz előadásra eddig {foglalt} jegyet adtak el, ez a nézőtér {Math.Round(szazalek, 0)}%-a.");
		}

		private static void Feladat_2()
		{
			Console.WriteLine("2. feladat");
			Console.Write("\tSor száma:");
			int.TryParse(Console.ReadLine(), out int sor);
			Console.Write("\tSzék száma:");
			int.TryParse(Console.ReadLine(), out int szek);
			if (foglaltsag[sor - 1][szek - 1] == 'x')
			{
				Console.WriteLine("\tA megadott szék foglalt.");
			}
			else
			{
				Console.WriteLine("\tA megadott szék szabad.");
			}
		}
		private static void Feladat_1()
		{
			try
			{
				using (StreamReader sr = new StreamReader("foglaltsag.txt"))
				{
					for (int i = 0; i < 15; i++)
					{
						foglaltsag[i] = sr.ReadLine();
					}
				}
				using (StreamReader sr = new StreamReader("kategoria-4.txt"))
				{
					for (int i = 0; i < 15; i++)
					{
						kategoria[i] = sr.ReadLine();
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
