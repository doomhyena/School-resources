using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElsoApp
{
	internal class Program
	{
		static Random rnd = new Random();
		static void Main(string[] args)
		{
			string[] lehetosegek = new string[] { "kő", "papír", "olló" };

			string gepValasztas = lehetosegek[rnd.Next(lehetosegek.Length)];

			Console.Write("Választásod [kő/papír/olló]: ");
			string jatekosValasztas = Console.ReadLine();

			if (gepValasztas == jatekosValasztas)
			{
				Console.WriteLine("Döntetlen.");
				Console.WriteLine($"A gép választása: {gepValasztas}");
			}
			else if (gepValasztas == "kő" && jatekosValasztas == "papír" ||
						gepValasztas == "papír" && jatekosValasztas == "olló" ||
						gepValasztas == "olló" && jatekosValasztas == "kő")
			{
				Console.WriteLine("Nyertél");
				Console.WriteLine($"A gép választása: {gepValasztas}");
			}
			else if (jatekosValasztas == "kő" && gepValasztas == "papír" ||
						jatekosValasztas == "papír" && gepValasztas == "olló" ||
						jatekosValasztas == "olló" && gepValasztas == "kő"
				)
			{
				Console.WriteLine("Vesztettél");
				Console.WriteLine($"A gép választása: {gepValasztas}");
			}
			else
			{
				Console.WriteLine("Értékelhetetlen választás.");
			}
			//----------------------------------------
			Console.WriteLine("- VÉGE -");
			Console.ReadKey();
		}
	}
}
