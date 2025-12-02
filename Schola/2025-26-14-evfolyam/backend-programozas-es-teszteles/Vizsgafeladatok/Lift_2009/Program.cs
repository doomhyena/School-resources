using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lift_2009
{
	internal class Program
	{
		static int emeletekSzama;
		static int csoportSzam;
		static int indulas;
		static List<Igeny> igenyek = new List<Igeny>();
		static void Main(string[] args)
		{
			Feladat_1();
			Feladat_2();
			Feladat_3();
			Feladat_4();
			//--------------------------------
			Console.WriteLine("-- VÉGE --");
			Console.ReadKey();
		}

		private static void Feladat_4()
		{
			Console.WriteLine("4. feladat");
			Console.WriteLine($"A legalsó szint:{igenyek.Min(i => i.Cel)}");
			Console.WriteLine($"A legfelső szint:{igenyek.Max(i => i.Cel)}");
		}

		private static void Feladat_3()
		{
			Console.WriteLine("3. feladat");
			Console.WriteLine($"A lift a {igenyek.Last().Cel}. szinten áll az utolsó igény teljesítése után.");
		}

		private static void Feladat_2()
		{
			Console.WriteLine("2. feladat");
			Console.Write("\tHanyadik szintről induljon a lift: ");
			indulas = int.Parse(Console.ReadLine());
		}

		private static void Feladat_1()
		{
			string[] lineArray;
			try
			{
				using (StreamReader sr = new StreamReader("igeny.txt"))
				{
					emeletekSzama = int.Parse(sr.ReadLine());
					csoportSzam = int.Parse(sr.ReadLine());
					sr.ReadLine();
					while (!sr.EndOfStream)
					{
						lineArray = sr.ReadLine().Split(' ');
						igenyek.Add(new Igeny()
						{
							Ora = int.Parse(lineArray[0]),
							Perc = int.Parse(lineArray[1]),
							Masodperc = int.Parse(lineArray[2]),
							TeamID = int.Parse(lineArray[3]),
							Start = int.Parse(lineArray[4]),
							Cel = int.Parse(lineArray[5])
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

	public class Igeny
	{
		public int Ora { get; set; }
		public int Perc { get; set; }
		public int Masodperc { get; set; }
		public int TeamID { get; set; }
		public int Start { get; set; }
		public int Cel { get; set; }

	}
}
