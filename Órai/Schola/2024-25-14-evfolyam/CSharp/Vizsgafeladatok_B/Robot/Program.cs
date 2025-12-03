using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Robot
{
	class Program
	{
		static string[] programok;
		static void Main(string[] args)
		{
			Feladat_1();
			Feladat_2();
			Feladat_3();
			Feladat_4();
			Feladat_5();
			//----------------
			Console.ReadKey();
		}

		private static void Feladat_5()
		{
			//3ED2N
			Console.WriteLine("5. feladat");
			Console.Write("\tRövid program: ");
			string ujprog = Console.ReadLine();
			string prog = string.Empty;
			for (int i = 0; i < ujprog.Length; i++)
			{
				if (int.TryParse(ujprog[i].ToString(),out int q))
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
			Console.WriteLine($"\tRégi változat: {prog}");
		}

		private static void Feladat_4()
		{
			Console.WriteLine("4. feladat");
			try
			{
				using (StreamWriter sw = new StreamWriter(@"ujprog.txt", false))
				{
					foreach (var prog in programok)
					{
						sw.WriteLine(Simple(prog));
					}
				}
				Console.WriteLine("\t Sikeres fájlba írás.");
			}
			catch (Exception ex)
			{
				Console.WriteLine("\t Sikertelen fájlba írás."+Environment.NewLine+ex.Message);				
			}

		}

		private static string Simple(string prog)
		{
			//ENNNDKENDND => E 3N D K E N D N D
			string result = string.Empty;
			List<CharCount> list = new List<CharCount>();
			CharCount cc = new CharCount() { C = prog[0], Q = 1 };
			for (int i = 1; i < prog.Length; i++)
			{
				if (cc.C == prog[i])
				{
					cc.Q++;
				}
				else
				{
					list.Add(cc);
					cc = new CharCount() { C = prog[i], Q = 1 };
				}
				if (i == prog.Length - 1)
				{
					list.Add(cc);
				}
			}
			foreach (var item in list)
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
			int energia;
			Console.WriteLine("3. feladat");
			for (int i = 0; i < programok.Length; i++)
			{
				energia = EnergyCalc(programok[i]);
				if (energia <= 100)
				{
					Console.WriteLine($"\t{i + 1} {energia}");
				}
			}
		}

		private static int EnergyCalc(string prog)
		{
			//EKK
			int result = 3;
			char actual = prog[0];
			for (int i = 1; i < prog.Length; i++)
			{
				if (prog[i] != actual)
				{
					result += 2;
					actual = prog[i];
				}
				result++;
			}
			return result;
		}

		private static void Feladat_2()
		{
			Console.WriteLine("2. feladat");
			Console.Write("\tAdd meg egy sor számát:");
			string aSor = Console.ReadLine();
			int sorszam = int.Parse(aSor);
			string str = programok[sorszam - 1];
			#region a
			Console.WriteLine("\t a,");
			string[] tomb = new string[] { "ED", "DE", "KN", "NK" };
			if (tomb.Any(q => str.Contains(q)))
			{
				Console.WriteLine("\t Egyszerüsíthető.");
			}
			else
			{
				Console.WriteLine("\t Nem egyszerüsíthető.");
			}
			#endregion

			#region b 			
			Console.WriteLine("\t b,");
			int ed = str.Count(q => q == 'E') - str.Count(q => q == 'D');
			int kn = str.Count(q => q == 'K') - str.Count(q => q == 'N');
			//foreach (var c in str)
			//{
			//	switch (c)
			//	{
			//		case 'E':
			//			ed++;
			//			break;
			//		case 'D':
			//			ed--;
			//			break;
			//		case 'K':
			//			kn++;
			//			break;
			//		case 'N':
			//			kn--;
			//			break;
			//		default:
			//			break;
			//	}
			//}
			Console.WriteLine($"\t ED irányban {ed} lépés, KN irányban {kn} lépés");
			#endregion

			#region c
			Console.WriteLine("\t c,");
			ed = kn = 0;
			int stepMAX = 0;
			double d, maxD = 0;
			for (int i = 0; i < str.Length; i++)
			{
				switch (str[i])
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
					stepMAX = i;
				}
			}
			Console.WriteLine($"\t A robot a {stepMAX + 1}. lépésnél volt a legtávolabb: {Math.Round(maxD, 3)}cm");
			#endregion
		}

		private static void Feladat_1()
		{
			string sor;
			try
			{
				using (StreamReader sr = new StreamReader(@"program.txt"))
				{
					sor = sr.ReadLine();
					programok = new string[int.Parse(sor)];
					for (int i = 0; i < programok.Length; i++)
					{
						programok[i] = sr.ReadLine();
					}
				}
			}
			catch (Exception)
			{

			}
		}
	}

	public class CharCount
	{
		public char C { get; set; }
		public int Q { get; set; }
	}
}
