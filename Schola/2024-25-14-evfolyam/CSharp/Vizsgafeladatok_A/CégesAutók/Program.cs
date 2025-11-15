using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CégesAutók
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
			Feladat_5();
			Feladat_6();
			Feladat_7();
			//-----------------
			Console.ReadKey();
		}

		private static void Feladat_7()
		{
			Console.WriteLine("7. feladat");
			Console.Write("\tRendszám: ");
			string rsz = Console.ReadLine();
			Adat[] adatT = adatok.Where(q => q.RSZ == rsz).ToArray();
			try
			{
				using (StreamWriter sw = new StreamWriter($"{rsz}_menetlevel.txt", false))
				{
					for (int i = 0; i < adatT.Length; i = i + 2)
					{
						if (i + 1 <= adatT.Length - 1)
						{
							sw.WriteLine($"\t{adatT[i].Dolgozo}\t{adatT[i].Nap}\t{adatT[i].Ido.ToString("HH:mm")}\t{adatT[i].KM}Km\t{adatT[i + 1].Nap}\t{adatT[i + 1].Ido.ToString("HH:mm")}\t{adatT[i + 1].KM}Km");
						}
						else
						{
							sw.WriteLine($"\t{adatT[i].Dolgozo}\t{adatT[i].Nap}\t{adatT[i].Ido.ToString("HH:mm")}\t{adatT[i].KM}Km");
						}
					}
				}
			}
			catch (Exception)
			{

				throw;
			}


		}
		private static void Feladat_6()
		{
			Console.WriteLine("6. feladat");
			List<Ut> utak = new List<Ut>();
			foreach (Adat adat in adatok)
			{
				if (!adat.Behajtas)
				{
					utak.Add(new Ut()
					{
						RSZ = adat.RSZ,
						Ki_KM = adat.KM,
						Be_KM = 0,
						User = adat.Dolgozo
					});
				}
				else
				{
					utak.First(q => q.RSZ == adat.RSZ && q.Be_KM == 0).Be_KM = adat.KM;
				}
			}
			Ut max = utak.First(q => q.Tavolsag == utak.Max(w => w.Tavolsag));
			Console.WriteLine($"\tLeghosszabb út: {max.Tavolsag} km, személy: {max.User}");
		}
		private static void Feladat_5()
		{
			Console.WriteLine("5. feladat");
			int result;
			foreach (string auto in adatok.Select(q => q.RSZ).Distinct())
			{
				result = adatok.Where(q => q.RSZ == auto).Max(q => q.KM)
							- adatok.Where(q => q.RSZ == auto).Min(q => q.KM);
				Console.WriteLine($"\t{auto} {result}km");
			}
		}
		private static void Feladat_4()
		{
			Console.WriteLine("4. feladat");
			int db = 0;
			foreach (string auto in adatok.Select(q => q.RSZ).Distinct())
			{
				if (!adatok.Where(q => q.RSZ == auto).Last().Behajtas)
				{
					db++;
				}
			}
			Console.WriteLine($"\tA hónap végén {db} autót nem hoztak vissza. ");
		}
		private static void Feladat_3()
		{
			Console.WriteLine("3. feladat");
			Console.Write("\tNap: ");
			int.TryParse(Console.ReadLine(), out int nap);
			Console.WriteLine($"\tForgalom a(z) {nap}. napon: ");
			foreach (Adat adat in adatok.Where(q => q.Nap == nap))
			{
				Console.WriteLine("\t{0} {1} {2} {3}",
						adat.Ido.ToString("HH:mm"),
						adat.RSZ,
						adat.Dolgozo,
						adat.Behajtas ? "be" : "ki");
			}
		}
		private static void Feladat_2()
		{
			Console.WriteLine("2. feladat");
			Adat adat = adatok.Last(q => !q.Behajtas);
			Console.WriteLine($"\t{adat.Nap}. nap rendszám: {adat.RSZ}");
		}
		private static void Feladat_1()
		{
			string sor;
			string[] tomb;
			try
			{
				using (StreamReader sr = new StreamReader("autok.txt"))
				{
					while (!sr.EndOfStream)
					{
						sor = sr.ReadLine();
						tomb = sor.Split(' '); // 1 08:45 CEG306 501 23989 0
						adatok.Add(new Adat()
						{
							Behajtas = tomb[5] == "1",
							Dolgozo = int.Parse(tomb[3]),
							Ido = new DateTime(
								2024, 04, 08,
								int.Parse(tomb[1].Split(':')[0]), int.Parse(tomb[1].Split(':')[1]), 0),
							KM = int.Parse(tomb[4]),
							Nap = int.Parse(tomb[0]),
							RSZ = tomb[2]
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
	public class Adat
	{
		public int Nap { get; set; }
		public DateTime Ido { get; set; }
		public string RSZ { get; set; }
		public int Dolgozo { get; set; }
		public int KM { get; set; }
		public bool Behajtas { get; set; }
	}

	public class Ut
	{
		public string RSZ { get; set; }
		public int User { get; set; }
		public int Ki_KM { get; set; }
		public int Be_KM { get; set; }
		public int Tavolsag { get => Be_KM - Ki_KM; }

	}
}
