using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szamkitalálós
{
			internal class Program
			{
						static Random rnd = new Random();
						static void Main(string[] args)
						{
									int maximum = 100;
									int minimum = 0;
									int tippQ = 10;
									int veletlenSz = rnd.Next(minimum, maximum + 1);
									int tipp;

									System.Diagnostics.Debug.WriteLine(veletlenSz);
									do
									{
												Console.WriteLine($"Még ennyi lehetőséged van: {tippQ}");
												Console.Write("Mi a tipped: ");
												int.TryParse(Console.ReadLine(), out tipp);
												if (tipp == veletlenSz)
												{
															Console.WriteLine("Sikerült, eltaláltad a számot.");
												}
												else if (tipp < veletlenSz)
												{
															Console.WriteLine("A kitalálandó szám nagyobb.");
															tippQ--;
												}
												else
												{
															Console.WriteLine("A kitalálandó szám kisebb.");
															tippQ--;
												}
											
									} while (tippQ > 0 && tipp != veletlenSz);

									if (tippQ == 0)
									{
												Console.WriteLine("Vesztettél. EZ most nem sikerült.");
									}

									//-----------------------------------------
									Console.WriteLine("----- VÉGE -----");
									Console.ReadKey();
						}
			}
}
