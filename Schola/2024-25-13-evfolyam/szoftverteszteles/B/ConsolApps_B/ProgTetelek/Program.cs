using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgTetelek
{
	internal class Program
	{
		static Random rnd = new Random();
		static void Main(string[] args)
		{
			int[] tomb = TombGenerator(10);
			TombToOutput(tomb);
			int osszeg = Osszegzes(tomb);
			int paratlan = Megszamolas(tomb);
			Console.Write("Add meg a keresett értéket: ");
			int.TryParse(Console.ReadLine(), out int keresett);
			bool benneVan = Eldontes(tomb, keresett);
			Console.WriteLine($"A tomb elemeinek összege: {osszeg}");
			Console.WriteLine($"A tömbben {paratlan} darab páratlan szám van.");
			Console.WriteLine("A keresett elem {0}", benneVan ? "benne van" : "nincsen benne.");
			//---------------------------------
			Console.WriteLine("- VÉGE -");
			Console.ReadKey();
		}

		private static bool Eldontes(int[] t, int v)
		{
			int i = 0;
			bool talalat = false;
			do
			{
				if (t[i] == v)
				{
					talalat = true;
				}
				else
				{
					i++;
				}
			} while (i < t.Length && !talalat);

			return i < t.Length;
		}
		private static int Megszamolas(int[] t)
		{
			int result = 0;
			for (int i = 0; i < t.Length; i++)
			{
				if (t[i] % 2 == 1)
				{
					result++;
				}
			}
			return result;
		}
		private static void TombToOutput(int[] t)
		{
			for (int i = 0; i < t.Length; i++)
			{
				System.Diagnostics.Debug.Write(t[i]);
				if (i < t.Length - 1)
				{
					System.Diagnostics.Debug.Write(",");
				}

			}
			System.Diagnostics.Debug.WriteLine("");
		}
		private static int[] TombGenerator(int v)
		{
			int[] result = new int[v];
			for (int i = 0; i < v; i++)
			{
				result[i] = rnd.Next(1000);
			}
			return result;
		}
		private static int Osszegzes(int[] t)
		{
			int result = 0;
			for (int i = 0; i < t.Length; i++)
			{
				result += t[i];
			}

			return result;
		}
	}
}
