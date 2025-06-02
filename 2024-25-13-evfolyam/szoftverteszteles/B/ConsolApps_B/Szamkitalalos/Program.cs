using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamkitalalos
{
	internal class Program
	{
		static Random rnd = new Random();
		
		static void Main(string[] args)
		{
			bool jatekvege = false;
			int kitalaltSzam = rnd.Next(1, 101);
			int tipp, tippSzamlalo = 0;

			do
			{
				Console.Write("Tipped? : ");
				tipp = int.Parse(Console.ReadLine());
				if (tipp == kitalaltSzam)
				{
					jatekvege = true;
					Console.WriteLine($"Sikerült kitalálnod {tippSzamlalo} próbálkozásból!");
				}
				else if (tipp < kitalaltSzam)
				{
					Console.WriteLine("A kitalált szám nagyobb.");
					tippSzamlalo++;
				}
				else
				{
					Console.WriteLine("A kitalált szám kisebb.");
					tippSzamlalo++;
				}
			} while (!jatekvege);

			//----------------------------------
			
			Console.WriteLine("- VÉGE -");
			Console.ReadKey();
		}		
	}
}
