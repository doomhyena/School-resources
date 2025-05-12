using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzamKitalalos
{
			class Program
			{
						static Random rnd = new Random();
						static void Main(string[] args)
						{
									int kitalalando;
									int tipp,alsoH,felsoH;
									int lehetoseg = 10;
									bool siker = false;


									Console.Write("Add meg az alsó határértéket: ");
									int.TryParse(Console.ReadLine(),out alsoH);
									Console.Write("Add meg a felső határértéket: ");
									int.TryParse(Console.ReadLine(), out felsoH);
									kitalalando = rnd.Next(alsoH, felsoH + 1);

									do
									{
												Console.WriteLine($"Tippelési lehetőségeid száma: {lehetoseg}");
												Console.Write("Mi a tipped: ");
												int.TryParse(Console.ReadLine(), out tipp);
												if (tipp==kitalalando)
												{
															siker = true;
															Console.WriteLine("Sikerült eltalálnod a számot!");
												}
												else if (tipp<kitalalando)
												{
															lehetoseg--;
															Console.WriteLine("A kitalálandó szám nagyobb.");
												}
												else
												{
															lehetoseg--;
															Console.WriteLine("A kitalálandó szám kisebb.");
												}
									} while (!siker && lehetoseg > 0);
									//        true  &&    true = true
									//        true  &&   false = false
									//        false &&    true = false
									//        false &&   false = false
									if (lehetoseg==0)
									{
												Console.WriteLine($"Sajnos vesztettél, a kitalálandó szám: {kitalalando}");
									}
									//--------------------------
									Console.WriteLine("--- VÉGE ---");
									Console.ReadKey();
						}
			}
}
