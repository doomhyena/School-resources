using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RGB
{
	internal class Program
	{
		static List<RGB> adatok;
		static RGB[,] adatTomb;
		static void Main(string[] args)
		{
			adatok = new List<RGB>();
			adatTomb = new RGB[640, 360];
			Feladat_1();
			//Feladat_2();
			Feladat_3();
			Feladat_4();
			Feladat_6();
			Console.ReadKey();
		}

		private static void Feladat_6()
		{
			Console.WriteLine("6. feladat");
			List<int> felho = new List<int>();
			for (int i = 0; i < 360; i++)
			{
				if (Hatar(i, 10))
				{
					felho.Add(i);
				}
			}
			Console.WriteLine($"\tA felhő legfelső sora: {felho.First()+1}");
			Console.WriteLine($"\tA felhő legalsó sora: {felho.Last()+1}");
		}

		private static bool Hatar(int sor, int kulonb)
		{
			bool result = false;
			for (int i = 1; i < 640; i++)
			{
				if (Math.Abs(adatTomb[i - 1, sor].b - adatTomb[i, sor].b) > kulonb)
				{
					result = true;
				}
			}
			return result;

		}
		private static void Feladat_4()
		{
			Console.WriteLine("4. feladat");
			int minValue = adatok.Min(q => q.Value);
			Console.WriteLine($"\tA legsötétebb pont RGB összege: {minValue}");
			foreach (var item in adatok.Where(q => q.Value == minValue))
			{
				Console.WriteLine($"\tRGB({item.r},{item.g},{item.b})");
			}
		}

		private static void Feladat_3()
		{
			Console.WriteLine("3. feladat");
			//int n = 0;
			//foreach (var item in adatok)
			//{
			//	if (item.Value>600)
			//	{
			//		n++;
			//	}
			//}
			Console.WriteLine($"A világos képpontok száma: {adatok.Count(q => q.Value > 600)}");
		}

		private static void Feladat_2()
		{
			Console.WriteLine("2. feladat");
			Console.Write("\nSor:");
			int y = int.Parse(Console.ReadLine());
			Console.Write("\nOszlop:");
			int x = int.Parse(Console.ReadLine());
			RGB result = adatTomb[x - 1, y - 1];
			Console.WriteLine($"A képpont színe RGB({result.r},{result.g},{result.b})");
		}

		private static void Feladat_1()
		{
			string[] tomb;
			int n;
			try
			{
				using (StreamReader sr = new StreamReader("kep-1.txt"))
				{
					for (int y = 0; y < 360; y++)
					{
						tomb = sr.ReadLine().Split(' ');
						n = 0;
						for (int x = 0; x < 640; x++)
						{
							adatok.Add(new RGB()
							{
								x = x,
								y = y,
								r = byte.Parse(tomb[n++]),
								g = byte.Parse(tomb[n++]),
								b = byte.Parse(tomb[n++])
							});
							n -= 3;
							adatTomb[x, y] = new RGB()
							{
								x = x,
								y = y,
								r = byte.Parse(tomb[n++]),
								g = byte.Parse(tomb[n++]),
								b = byte.Parse(tomb[n++])
							};
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

	public struct RGB
	{
		public byte r;
		public byte g;
		public byte b;
		public int x, y;

		public int Value { get { return r + g + b; } }
	}
}
