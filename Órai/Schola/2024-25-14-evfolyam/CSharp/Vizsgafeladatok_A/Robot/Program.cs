using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Versioning;

namespace Robot
{
	internal class Program
	{
		static Dictionary<int, string> programok = new Dictionary<int, string>();
		static void Main(string[] args)
		{
			Feladat_1();
			Feladat_2();
			Feladat_3();
			Feladat_4();
			Feladat_5();
			//--------------------------
			Console.ReadKey();
		}

		private static void Feladat_5()
		{
			Console.WriteLine("5. Feladat.");
			Console.Write("\tAdd meg a programot: ");
			string ujprog = Console.ReadLine();
			//2DN3K => DDNKKK
			string prog = string.Empty;
			for (int i = 0; i < ujprog.Length; i++)
			{
				if (int.TryParse(ujprog[i].ToString(), out int q))
				{
					for (int j = 0; j < q; j++)
					{
						prog += ujprog[i + 1];
					}
					i++;
				}
				else
				{
					prog += ujprog[i];
				}
			}
			Console.WriteLine($"\tRégi verzió: {prog}");
		}

		private static void Feladat_4()
		{
			Console.WriteLine("4. Feladat.");
			try
			{
				using (StreamWriter sw = new StreamWriter(@"ujprog.txt", false))
				{
					foreach (var prog in programok.Values)
					{
						sw.WriteLine(Simple(prog));
					}
				}
				Console.WriteLine("\tA fájlba írás sikerült.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("\tA fájlba írás nem sikerült."+Environment.NewLine+ex.Message);
			}
		}
		private static string Simple(string prog)
		{
			//ENNNDKENDND => E 3N D K E N D N D
			string result = string.Empty;
			Cetli cetli = new Cetli() { C = prog[0], Q = 1 };
			List<Cetli> cetlik = new List<Cetli>();
			for (int i = 1; i < prog.Length; i++)
			{
				if (prog[i] == cetli.C)
				{
					cetli.Q++;
				}
				else
				{
					cetlik.Add(cetli);
					cetli = new Cetli() { C = prog[i], Q = 1 };
				}
				if (i == prog.Length - 1)
				{
					cetlik.Add(cetli);
				}
			}
			foreach (var item in cetlik)
			{
				if (item.Q > 1)
				{
					result += $"{item.Q}{item.C}";
				}
				else
				{
					result += item.C;
				}
			}
			return result;
		}
		private static void Feladat_3()
		{
			Console.WriteLine("3. Feladat.");
			int fogyasztas;
			foreach (var prog in programok)
			{
				fogyasztas = Fogyi(prog.Value);
				if (fogyasztas <= 100)
				{
					Console.WriteLine($"\t {prog.Key}. program alkalmas, e igény:{fogyasztas}");
				}
			}
		}
		private static int Fogyi(string prog)
		{
			int fogyi = 3;
			char akt = prog[0];
			for (int i = 1; i < prog.Length; i++)
			{
				if (prog[i] != akt)
				{
					fogyi += 2;
					akt = prog[i];
				}
				fogyi++;
			}
			return fogyi;
		}
		private static void Feladat_2()
		{
			Console.WriteLine("2. Feladat.");
			Console.Write("\tAdd meg egy sor számát:");
			string aSor = Console.ReadLine();
			int sorSzam = int.Parse(aSor);
			string aStr = programok[sorSzam];

			#region A
			Console.WriteLine("\tA,");
			string[] tomb = new string[] { "ED", "DE", "NK", "KN" };
			if (tomb.Any(q => aStr.Contains(q)))
			{
				Console.WriteLine("\tEgyszerüsíthető.");
			}
			else
			{
				Console.WriteLine("\tNem egyszerüsíthető.");
			}
			#endregion

			#region B
			Console.WriteLine("\tB,");
			int ed = aStr.Count(q => q == 'E') - aStr.Count(q => q == 'D');
			int kn = aStr.Count(q => q == 'K') - aStr.Count(q => q == 'N');

			Console.WriteLine($"\tA ED tengelyen {ed} lépést, a KN tengelyen {kn} lépést kell tenni.");
			#endregion

			#region C
			Console.WriteLine("\tC,");
			double d;
			double maxD = 0;
			int step = 0;
			ed = kn = 0;
			for (int i = 0; i < aStr.Length; i++)
			{
				switch (aStr[i])
				{
					case 'E':
						ed++;
						break;
					case 'D':
						ed--;
						break;
					case 'K':
						kn++;
						break;
					case 'N':
						kn--;
						break;
					default:
						break;
				}
				d = Math.Sqrt(ed * ed + kn * kn);
				if (d > maxD)
				{
					maxD = d;
					step = i;
				}
			}
			Console.WriteLine($"\tA legtávolabb a {step + 1}. lépésnál volt, {Math.Round(maxD, 3)}cm ");
			#endregion
		}
		private static void Feladat_1()
		{
			Console.WriteLine("1. Feladat.");
			string sor;
			int i = 1;
			try
			{
				using (StreamReader sr = new StreamReader(@"program.txt"))
				{
					sr.ReadLine();
					while (!sr.EndOfStream)
					{
						sor = sr.ReadLine();
						programok.Add(i++, sor);
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}

	public class Cetli
	{
		public char C { get; set; }
		public int Q { get; set; }
	}
}
