using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utepites
{
	class Program
	{
		static List<Adat> adatok = new List<Adat>();
		static void Main(string[] args)
		{
			Feladat_1();
			Feladat_2();
			Feladat_3();
			Feladat_4();
			//-----------------------
			Console.ReadKey();
		}

		private static void Feladat_3()
		{
			var tomb = adatok.Where(a=>a.Kiindulas=='A').ToArray();
			var result = tomb[tomb.Length-1].Ido - tomb[tomb.Length-2].Ido;
			Console.WriteLine("3. feladat");
			Console.WriteLine($"\tKülönbség: {result}");
		}

		private static void Feladat_2()
		{
			Console.WriteLine("2. feladat");
			Console.Write("Hanyadik jármű: ");
			int.TryParse(Console.ReadLine(), out int n);
			Console.WriteLine($"\t{n}. jármű {adatok[n-1].Kiindulas}");
		}

		private static void Feladat_1()
		{
			string[] tomb;
			try
			{
				using (StreamReader sr = new StreamReader("forgalom-1.txt"))
				{
					sr.ReadLine();
					while (!sr.EndOfStream)
					{
						tomb=sr.ReadLine().Split(' ');
						adatok.Add(new Adat()
						{
							Ido=new DateTime(2025, 03, 31, int.Parse(tomb[0]), int.Parse(tomb[1]), int.Parse(tomb[2])),
							Athaladas=new TimeSpan(0,0, int.Parse(tomb[3])),
							Kiindulas=char.Parse(tomb[4]),
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

	class Adat
	{
		public DateTime Ido { get; set; }
		public TimeSpan Athaladas { get; set; }
		public char Kiindulas { get; set; }
	}
}
