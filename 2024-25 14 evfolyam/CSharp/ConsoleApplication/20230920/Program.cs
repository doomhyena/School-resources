using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230920
{
			class Program
			{
						static void Main(string[] args)
						{
									int szam;
									//	string szamSTR;
									//bool siker;
									#region Feltételes elágazás
									//Console.Write("Írj be egy egés	z számot: ");

									//szamSTR = Console.ReadLine();

									//	siker = int.TryParse(szamSTR, out szam);

									//if (int.TryParse(Console.ReadLine(), out szam))
									//{
									//			Console.WriteLine("Tényleg számot írtál be.");
									//			if (szam < 1000)
									//			{
									//						Console.WriteLine("A beírt szám kisebb mint 1000.");
									//			}
									//			else if (szam == 1000)
									//			{
									//						Console.WriteLine("A beírt szám 1000.");
									//			}
									//			else
									//			{
									//						Console.WriteLine("A beírt szám nagyobb mint 1000.");
									//			}
									//}
									//else
									//{
									//			Console.WriteLine("Nem tudom számmá alakítani!");
									//} 
									#endregion

									#region Ciklusok
									//for (int i = 0; i < 10; i++)
									//{
									//			Console.WriteLine($"Az i értéke={i}");
									//}
									szam = 110;
									//do
									//{
									//			Console.WriteLine($"Az szam változó értéke={++szam}");
									//		//	szam = szam + 1;
									//			//szam += 1;
									//			//szam++;
									//} while (szam < 10);

									while (szam<10)
									{
												Console.WriteLine($"Az szam változó értéke={szam++}");
									}
									#endregion



									//--------------------------------
									Console.WriteLine("-------------- VÉGE ------------------");
									Console.ReadKey();
						}
			}
}
