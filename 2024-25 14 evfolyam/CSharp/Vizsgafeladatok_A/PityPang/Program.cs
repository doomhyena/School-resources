using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PityPang
{
	internal class Program
	{
		static List<Foglalas> foglalasok = new List<Foglalas>();
		static Dictionary<int, int> napHonap = new Dictionary<int, int>();
		static void Main(string[] args)
		{
			Feladat_1();
			Feladat_2();
			Feladat_3();
			Feladat_4();
			//------------------------
			Console.ReadKey();
		}
		private static void Feladat_4()
		{
			HonapNap_Init();
			int[] months = new int[13];
			foreach (var foglalas in foglalasok)
			{
				for (int day = foglalas.ComingDay; day < foglalas.GoingDay; day++)
				{
					months[napHonap[day]] += foglalas.People;
				}
			}
			for (int i = 1; i < months.Length; i++)
			{
				Console.WriteLine($"\t{i} : {months[i]}");
			}
		}
		private static void HonapNap_Init()
		{
			int n = 0;
			int m = 1;
			try
			{
				using (StreamReader sr = new StreamReader("honapok.txt"))
				{
					while (!sr.EndOfStream)
					{
						sr.ReadLine();
						int.TryParse(sr.ReadLine(), out int days);
						for (int i = 0; i < days; i++)
						{
							n++;
							napHonap.Add(n, m);
						}
						m++;
						sr.ReadLine();
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		private static int Price(int day)
		{
			if (day < 121)
			{
				return 9000;
			}
			else if (day >= 121 && day < 244)
			{
				return 10000;
			}
			else
			{
				return 8000;
			}
		}
		private static void Feladat_3()
		{
			Console.WriteLine("3. feladat");
			int sum;
			foreach (var foglalas in foglalasok)
			{
				sum = 0;
				for (int day = foglalas.ComingDay; day < foglalas.GoingDay; day++)
				{
					sum += Price(day) * foglalas.People;
					if (foglalas.Breakfast)
					{
						sum += 1100 * foglalas.People;
					}
					if (foglalas.People > 2)
					{
						sum += 2000;
					}
				}
				Console.WriteLine($"\t{foglalas.ID,3} : {sum,6}");
				;
			}
		}
		private static void Feladat_2()
		{
			Console.WriteLine("2. feladat");
			Foglalas foglalas = foglalasok.First(f => f.Days == foglalasok.Max(f2 => f2.Days));
			Console.WriteLine($"{foglalas.Name} ({foglalas.ComingDay}) – {foglalas.Days}");
		}
		private static void Feladat_1()
		{
			string[] tomb;
			try
			{
				using (StreamReader sr = new StreamReader("pitypang.txt"))
				{
					sr.ReadLine();
					while (!sr.EndOfStream)
					{
						tomb = sr.ReadLine().Split(' ');
						foglalasok.Add(new Foglalas()
						{
							ID = int.Parse(tomb[0]),
							Room = int.Parse(tomb[1]),
							ComingDay = int.Parse(tomb[2]),
							GoingDay = int.Parse(tomb[3]),
							People = int.Parse(tomb[4]),
							Breakfast = tomb[5] == "1",
							Name = tomb[6]
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

	public class Foglalas
	{
		public int ID { get; set; }
		public int Room { get; set; }
		public int ComingDay { get; set; }
		public int GoingDay { get; set; }
		public int People { get; set; }
		public bool Breakfast { get; set; }
		public string Name { get; set; }
		public int Days
		{
			get
			{
				return GoingDay - ComingDay;
			}
		}
	}

}
