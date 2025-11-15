using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Nézőtér
{
	//http://informatika.fazekas.hu/wp-content/uploads/2015/10/e_prog_2014_okt.pdf
	class Program
	{
		static string[] foglaltsag = new string[15];
		static string[] kategoriak = new string[15];

		static void Main(string[] args)
		{
			Feladat_1();
			//Feladat_2();
			Feladat_3();
			Feladat_4();
			Feladat_5();
			Feladat_6();
			Feladat_7();
			//---------------------
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
						Console.Write(kategoriak[sor][szek]);
					}
				}
				Console.WriteLine();
			}
		}

		private static void Feladat_6()
		{
			Console.WriteLine("6. feladat");
			List<int> solo = new List<int>();
			int counter = 0;
			for (int sor = 0; sor < foglaltsag.Length; sor++)
			{
				if (counter > 0)
				{
					solo.Add(counter);
				}
				counter = 0;
				for (int szek = 0; szek < foglaltsag[sor].Length; szek++)
				{
					if (foglaltsag[sor][szek] == 'o')
					{
						counter++;
					}
					else
					{
						if (counter > 0)
						{
							solo.Add(counter);
							counter = 0;
						}
					}
				}
			}
			Console.WriteLine($"Egyedülálló helyek száma: {solo.Count(q => q == 1)}");
		}
		private static void Feladat_5()
		{
			Console.WriteLine("5. feladat");
			int összeg = 0;
			int[] arak = new int[] { 5000, 4000, 3000, 2000, 1500 };
			for (int sor = 0; sor < foglaltsag.Length; sor++)
			{
				for (int szek = 0; szek < foglaltsag[sor].Length; szek++)
				{
					if (foglaltsag[sor][szek] == 'x')
					{
						összeg += arak[int.Parse(kategoriak[sor][szek].ToString()) - 1];
					}
				}
			}
			Console.WriteLine($"\tBevétel: {összeg}");
		}
		private static void Feladat_4()
		{
			Console.WriteLine("4. feladat");
			Dictionary<char, int> catCount = new Dictionary<char, int>();
			for (int sor = 0; sor < foglaltsag.Length; sor++)
			{
				for (int szek = 0; szek < kategoriak[sor].Length; szek++)
				{
					if (foglaltsag[sor][szek] == 'x')
					{
						if (!catCount.ContainsKey(kategoriak[sor][szek]))
						{
							catCount.Add(kategoriak[sor][szek], 0);
						}
						catCount[kategoriak[sor][szek]]++;
					}
				}
			}
			char max = catCount.First(w => w.Value == catCount.Max(q => q.Value)).Key;
			Console.WriteLine($"\tA legtöbb jegyet a(z) {max}. árkategóriában értékesítették.");
		}
		private static void Feladat_3()
		{
			Console.WriteLine("3. feladat");
			int eladott = foglaltsag.Sum(q => q.Count(w => w == 'x'));
			//for (int i = 0; i < foglaltsag.Length; i++)
			//{
			//	for (int j = 0; j < foglaltsag[i].Length; j++)
			//	{
			//		if (foglaltsag[i][j] == 'x')
			//		{
			//			eladott++;
			//		}
			//	}
			//}
			double fsag = (double)eladott / 300 * 100;
			Console.WriteLine($"\tAz előadásra eddig {eladott} jegyet adtak el, ez a nézőtér {Math.Round(fsag, 0)}%-a.");
		}
		private static void Feladat_2()
		{
			int sor, szek;
			Console.WriteLine("2. feladat");
			Console.Write("\tSor: ");
			int.TryParse(Console.ReadLine(), out sor);
			Console.Write("\tSzék: ");
			int.TryParse(Console.ReadLine(), out szek);
			if (foglaltsag[sor - 1][szek - 1] == 'x')
			{
				Console.WriteLine("\tEz a szék már foglalt.");
			}
			else
			{
				Console.WriteLine("\tEz a szék még szabad.");
			}
		}
		private static void Feladat_1()
		{
			try
			{
				using (StreamReader sr = new StreamReader("foglaltsag.txt"))
				{
					for (int i = 0; i < foglaltsag.Length; i++)
					{
						foglaltsag[i] = sr.ReadLine();
					}
				}
				using (StreamReader sr = new StreamReader("kategoria-4.txt"))
				{
					for (int i = 0; i < kategoriak.Length; i++)
					{
						kategoriak[i] = sr.ReadLine();
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
