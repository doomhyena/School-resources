using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230927
{
			class Program
			{
						static void Main(string[] args)
						{
									int szam;
									bool siker = false;

									do
									{
												Console.Write("Adj meg egy egész számot: ");
												siker = int.TryParse(Console.ReadLine(), out szam);
												if (!siker)
												{
															Console.WriteLine("Csak egész számot adhatsz meg!");
												}
												else
												{
															Console.WriteLine("Szuper, köszi!");
												}
									} while (!siker);
								
									//--------------------------
									Console.WriteLine("--- VÉGE ---");
									Console.ReadKey();
						}
			}
}
