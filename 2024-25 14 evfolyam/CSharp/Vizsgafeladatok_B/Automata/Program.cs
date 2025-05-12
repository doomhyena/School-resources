using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Automata
{
	//http://informatika.fazekas.hu/wp-content/uploads/2015/10/e_prog_2009_maj_id.pdf
	class Program
	{
		static List<Rekesz> rekeszek = new List<Rekesz>();
		static List<Vasarlas> vasarlasok = new List<Vasarlas>();
		static void Main(string[] args)
		{
			Feladat_1();
			Feladat_2();
			Feladat_3();
			Feladat_4();
			Feladat_5();
			Feladat_6();
			//-------------------
			Console.ReadKey();
		}

		private static void Feladat_6()
		{
			Console.WriteLine("6. Feladat");
			Rekesz rekesz7 = rekeszek.First(q => q.ID == 7);
			int sorszam = 1;
			try
			{
				using (StreamWriter sw = new StreamWriter("rekesz7.txt", false))
				{
					foreach (Vasarlas vasarlas in vasarlasok.Where(q => q.RekeszID == 7))
					{
						if (vasarlas.Quantity <= rekesz7.Quantity) // van e annyi a rekeszben
						{
							if (vasarlas.Bedobott >= vasarlas.Quantity * rekesz7.Price) // van e elég pénz
							{
								sw.WriteLine($"\t{sorszam}\t{vasarlas.Quantity}");
								rekesz7.Quantity -= vasarlas.Quantity;
							}
							else
							{
								sw.WriteLine($"\t{sorszam}\tkevés a pénz");
							}
						}
						else
						{
							sw.WriteLine($"\t{sorszam}\tkevés a csoki");
						}
						sorszam++;
					}
				}
			}
			catch (Exception)
			{

				throw;
			}

		}

		private static void Feladat_5()
		{
			Console.WriteLine("5. Feladat");
			Console.Write("\tRekesz száma: ");
			int.TryParse(Console.ReadLine(), out int rID);
			Console.Write("\tMennyiség: ");
			int.TryParse(Console.ReadLine(), out int darab);
			int összeg = darab * rekeszek.First(q => q.ID == rID).Price;
			Console.WriteLine($"\tÖsszeg: {összeg}");
			int[] alapCimletek = new int[] { 1, 2, 5, 10, 20, 50, 100, 200 };
			int[] cimletek = new int[alapCimletek.Length]; // [0] = 1 -........[6] = 100


			int v;
			bool exit;
			do
			{
				v = alapCimletek.Length - 1;
				exit = false;
				do
				{
					if (összeg >= alapCimletek[v])
					{
						összeg -= alapCimletek[v];
						cimletek[v]++;
						exit = true;
					}
					v--;
				} while (!exit && v >= 0);
				//if (összeg >= 100)
				//{
				//	összeg -= 100;
				//	cimletek[6]++;
				//}
				//else if (összeg >= 50)
				//{
				//	összeg -= 50;
				//	cimletek[5]++;
				//}
				//else if (összeg >= 20)
				//{
				//	összeg -= 20;
				//	cimletek[4]++;
				//}
				//else if (összeg >= 10)
				//{
				//	összeg -= 10;
				//	cimletek[3]++;
				//}
				//else if (összeg >= 5)
				//{
				//	összeg -= 5;
				//	cimletek[2]++;
				//}
				//else if (összeg >= 2)
				//{
				//	összeg -= 2;
				//	cimletek[1]++;
				//}
				//else if (összeg >= 1)
				//{
				//	összeg -= 1;
				//	cimletek[0]++;
				//}
			} while (összeg > 0);
			for (int i = 0; i < cimletek.Length; i++)
			{
				Console.WriteLine($"\t{alapCimletek[i],3}:{cimletek[i],3}");
			}
			Console.WriteLine();
		}
		private static void Feladat_4()
		{
			Console.WriteLine("4. Feladat");
			Console.Write("\tRászánt összeg: ");
			int.TryParse(Console.ReadLine(), out int összeg);
			Console.Write("\tMegfelelő rekeszek:");
			int[] result = rekeszek.Where(q => q.Quantity >= 7 && q.Price * 7 <= összeg).Select(q => q.ID).ToArray();
			foreach (Rekesz rekesz in rekeszek)
			{
				if (rekesz.Quantity >= 7 && rekesz.Price * 7 <= összeg)
				{
					Console.Write($" {rekesz.ID}");
				}
			}
			Console.WriteLine();
		}
		private static void Feladat_3()
		{
			Console.WriteLine("3. Feladat");
			List<int> result = new List<int>();
			Console.Write("\tHasznált rekeszek:");
			//foreach (Vasarlas vasarlas in vasarlasok)
			//{
			//	if (!result.Contains(vasarlas.RekeszID))
			//	{
			//		result.Add(vasarlas.RekeszID);
			//		Console.Write($" {vasarlas.RekeszID}");
			//	}
			//}
			//result = result.OrderBy(q=>q).ToList();
			result = vasarlasok.Select(q => q.RekeszID).Distinct().ToList();
			foreach (int rID in result.OrderBy(q => q))
			{
				Console.Write($" {rID}");
			}
			Console.WriteLine();
		}
		private static void Feladat_2()
		{
			Console.WriteLine("2. Feladat");
			int sum = rekeszek.Sum(q => q.Quantity * q.Price);

			//foreach (var rekesz in rekeszek)
			//{
			//	sum += rekesz.Price * rekesz.Quantity;
			//}

			Console.WriteLine($"Az automatában {sum} fabatka értékű csokoládé van.");
		}
		private static void Feladat_1()
		{
			string sor;
			string[] tomb;
			try
			{
				using (StreamReader sr = new StreamReader("csoki.txt"))
				{
					sr.ReadLine();
					while (!sr.EndOfStream)
					{
						sor = sr.ReadLine();
						tomb = sor.Split(' ');
						rekeszek.Add(new Rekesz()
						{
							ID = int.Parse(tomb[0]),
							Quantity = int.Parse(tomb[1]),
							Price = int.Parse(tomb[2])
						});
					}
				}
				using (StreamReader sr = new StreamReader("vasarlas.txt"))
				{
					sr.ReadLine();
					while (!sr.EndOfStream)
					{
						tomb = sr.ReadLine().Split(' ');
						vasarlasok.Add(new Vasarlas()
						{
							RekeszID = int.Parse(tomb[0]),
							Quantity = int.Parse(tomb[1]),
							Coins = new int[] {
								int.Parse(tomb[2]),
								int.Parse(tomb[3]),
								int.Parse(tomb[4]),
								int.Parse(tomb[5]),
								int.Parse(tomb[6]),
								int.Parse(tomb[7]),
								int.Parse(tomb[8])
							}
						});
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}

	public class Rekesz
	{
		public int ID { get; set; }
		public int Quantity { get; set; }
		public int Price { get; set; }
	}

	public class Vasarlas
	{
		public int RekeszID { get; set; }
		public int Quantity { get; set; }
		public int[] Coins { get; set; }
		public int Bedobott
		{
			get
			{
				return Coins[0]
						+ Coins[1] * 2
						+ Coins[2] * 5
						+ Coins[3] * 10
						+ Coins[4] * 20
						+ Coins[5] * 50
						+ Coins[6] * 100;
			}
		}
		public Vasarlas()
		{
			Coins = new int[7];
		}
	}
}
