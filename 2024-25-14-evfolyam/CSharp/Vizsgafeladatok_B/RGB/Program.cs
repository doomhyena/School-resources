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
		//http://informatika.fazekas.hu/wp-content/uploads/2015/10/RGB-sz%C3%ADnek.pdf
		static List<RGB> szinek;
		static RGB[,] szinTomb;
		static void Main(string[] args)
		{
			szinek = new List<RGB>();
			szinTomb = new RGB[640, 360];
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
			Console.WriteLine($"\tA felhő legfelső sora: {felho.First() + 1} ");
			Console.WriteLine($"\tA felhő legalsó sora: {felho.Last() + 1} ");
		}

		private static bool Hatar(int sor, int hatarErtek)
		{
			//bool result = false;
			for (int i = 1; i < 640; i++)
			{
				if (Math.Abs(szinTomb[i - 1, sor].b - szinTomb[i, sor].b) > hatarErtek)
				{
					return true;
				}
			}
			return false;
		}
		private static void Feladat_4()
		{
			Console.WriteLine("4. feladat");
			int minValue = szinek.Min(q => q.Value);
			Console.WriteLine($"\tA legsötétebb pont RGB összege: {minValue}");
			Console.WriteLine($"\tA legsötétebb pixelek színe:");
			foreach (RGB szin in szinek.Where(q => q.Value == minValue))
			{
				Console.WriteLine($"\tRGB ({szin.r},{szin.g},{szin.b})");
			}
		}

		private static void Feladat_3()
		{
			Console.WriteLine("3. feladat");
			Console.WriteLine($"\tA világos képpontok száma: {szinek.Count(q => q.IsLight)} ");
		}

		private static void Feladat_2()
		{
			Console.WriteLine("2. feladat");
			Console.WriteLine("/tKérem egy képpont adatait:");
			Console.Write("\tSor: ");
			int.TryParse(Console.ReadLine(), out int y);
			Console.Write("\tOszlop: ");
			int.TryParse(Console.ReadLine(), out int x);
			RGB r = szinTomb[x - 1, y - 1];
			Console.WriteLine($"\tA képpont színe RGB({r.r},{r.g},{r.b}) ");
		}

		private static void Feladat_1()
		{
			string sor;
			string[] tomb;
			int n;
			try
			{
				using (StreamReader sr = new StreamReader("kep-1.txt"))
				{
					for (int y = 0; y < 360; y++)
					{
						sor = sr.ReadLine();
						tomb = sor.Split(' ');
						n = 0;
						for (int x = 0; x < 640; x++)
						{
							szinek.Add(new RGB()
							{
								x = x,
								y = y,
								r = byte.Parse(tomb[n++]),
								g = byte.Parse(tomb[n++]),
								b = byte.Parse(tomb[n++])
							});
							n -= 3;
							szinTomb[x, y] = new RGB()
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
		public int x, y;
		public byte r;
		public byte g;
		public byte b;

		public bool IsLight
		{
			get
			{
				return r + g + b > 600;
			}

		}

		public int Value { get { return r + g + b; } }
	}
}
