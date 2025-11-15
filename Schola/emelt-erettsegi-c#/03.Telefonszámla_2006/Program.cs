using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telefonszámla_2006
{
	internal class Program
	{
		static List<Hivas> hivasok = new List<Hivas>();
		static void Main(string[] args)
		{
			//Feladat_1();
			//Feladat_2();
			FileBeolvasas();
			Feladat_3();
			Feladat_4();
			Feladat_5();
			Feladat_6();

			///--------------------
			Console.WriteLine("VÉGE");
			Console.ReadKey();
		}

		private static void Feladat_6()
		{
			Console.WriteLine("6. feladat");
			double result = hivasok
									.Where(s => s.H_Kezdete.Hour >= 7 && s.H_Kezdete.Hour < 18)									
									.Sum(h => h.IsMobile ? h.Duration.TotalMinutes * 69.175 : h.Duration.TotalMinutes * 30);
			
			Console.WriteLine($"\tCsúcsidejű hívások díjja:{result:N} Ft");
		}

		private static void Feladat_5()
		{
			Console.WriteLine("5. feladat");
			double mobile = hivasok.Where(s => s.IsMobile).Sum(s => s.Duration.TotalMinutes);
			double noMobile = hivasok.Where(s => !s.IsMobile).Sum(s => s.Duration.TotalMinutes);
			Console.WriteLine($"\tMobil irányba: {mobile} perc");
			Console.WriteLine($"\tNem mobil irányba: {noMobile} perc");
		}

		private static void Feladat_4()
		{
			Console.WriteLine($"4. feladat");
			int csucsido = hivasok.Count(h => h.H_Kezdete.Hour >= 7 && h.H_Kezdete.Hour < 18);
			int nemCsucsido = hivasok.Count(h => h.H_Kezdete.Hour < 7 || h.H_Kezdete.Hour >= 18);
			Console.WriteLine($"\tCsúcsidőben: {csucsido}");
			Console.WriteLine($"\tCsúcsidőn kívűl: {nemCsucsido}");
		}

		private static void FileBeolvasas()
		{
			try
			{
				using (StreamReader sr = new StreamReader(@"hivasok.txt"))
				{
					string sor1, sor2;
					while (!sr.EndOfStream)
					{
						sor1 = sr.ReadLine();
						sor2 = sr.ReadLine();
						hivasok.Add(new Hivas(sor2, sor1));
					}
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		private static void Feladat_3()
		{
			Console.WriteLine("3. feladat");
			Double min;
			try
			{
				using (StreamWriter sw = new StreamWriter("percek.txt", false))
				{
					foreach (Hivas hivas in hivasok)
					{
						min = (hivas.H_Vege - hivas.H_Kezdete).TotalMinutes;
						if (min - Math.Round(min, 0) > 0)
						{
							min++;
						}
						sw.WriteLine($"\t{(int)min} {hivas.TelefonSzam}");
					}
				}
				Console.WriteLine("\tSikeres fájlba írás.");
			}
			catch (Exception)
			{
				Console.WriteLine("\tSikertelen fájlba írás.");
			}

		}

		private static void Feladat_2()
		{
			Console.WriteLine("2. feladat");
			Console.Write("\tHívás kezdete [hh:mm:ss]:");
			string hKezdet = Console.ReadLine();
			string[] hK_T = hKezdet.Split(':');
			DateTime hK_DT = new DateTime(2025, 04, 09, int.Parse(hK_T[0]), int.Parse(hK_T[1]), int.Parse(hK_T[2]));
			Console.Write("\tHívás vége [hh:mm:ss]:");
			string hVege = Console.ReadLine();
			string[] hV_T = hVege.Split(':');
			DateTime hV_DT = new DateTime(2025, 04, 09, int.Parse(hV_T[0]), int.Parse(hV_T[1]), int.Parse(hV_T[2]));
			Console.WriteLine($"\tA hívás időtartama:{(hV_DT - hK_DT)}");
		}

		private static void Feladat_1()
		{
			Console.WriteLine("1. feladat");
			Console.Write("Adj meg egy telefonszámot [+xx xx xxxxxxx]: ");
			string tszam = Console.ReadLine();
			string[] szamok = tszam.Split(' ');
			if (szamok.Length >= 3)
			{
				if ((new string[] { "20", "30", "50", "70" }).Any(q => q == szamok[1]))
				{
					Console.WriteLine("\tA szám mobil szám.");
				}
				else
				{
					Console.WriteLine($"\tA szám nem mobil szám.");
				}
			}
			else
			{
				Console.WriteLine("\tRossz formátum.");
			}
		}
	}

	public class Hivas
	{
		public string TelefonSzam { get; set; }
		public DateTime H_Kezdete { get; set; }
		public DateTime H_Vege { get; set; }
		public TimeSpan Duration
		{
			get
			{
				return H_Vege - H_Kezdete;
			}
		}
		public bool IsMobile
		{
			get
			{
				return TelefonSzam.StartsWith("39") || TelefonSzam.StartsWith("41") || TelefonSzam.StartsWith("71");
			}
		}

		public Hivas(string _tszam, string _hivasIdok)
		{
			TelefonSzam = _tszam;
			string[] t = _hivasIdok.Split(' ');
			H_Kezdete = new DateTime(2025, 04, 09, int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]));
			H_Vege = new DateTime(2025, 04, 09, int.Parse(t[3]), int.Parse(t[4]), int.Parse(t[5]));
		}
	}
}
