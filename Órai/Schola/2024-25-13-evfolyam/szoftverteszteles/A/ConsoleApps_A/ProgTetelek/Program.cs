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
			int[] tomb = TombGenerator(100);
			TombToOutput(tomb);
			Console.WriteLine($"A tomb összege: {Osszegzes(tomb)}");
			Console.WriteLine($"A tömb {Megszamolas(tomb)} darab páros számot tartalmaz.");
			//----------------------------------
			Console.WriteLine("- VÉGE -");
			Console.ReadKey();
		}

		private static int Megszamolas(int[] t)
		{
			int result = 0;
			for (int i = 0; i < t.Length; i++)
			{
				if (t[i] % 2 == 0)
				{
					result++;
				}
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
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = rnd.Next(1000);
			}
			return result;
		}
	}
}
