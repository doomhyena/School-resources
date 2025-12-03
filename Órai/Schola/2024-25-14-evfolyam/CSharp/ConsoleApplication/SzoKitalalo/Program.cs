using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzoKitalalo
{
			internal class Program
			{
						static Random rnd = new Random();
						static void Main(string[] args)
						{
									string[] szavak = new string[] { "kelkáposzta", "repülőgép", "madárpók", "Ausztrália" };
									string aSzo = szavak[rnd.Next(szavak.Length)];
									string kitalaltSzo = UresSzoGenerator(aSzo.Length);
									string rosszTippek = string.Empty;
									int tippekSzama = 10;
									string tippSTR;
									do
									{
												Console.Clear();
												tippSTR = TippKeres(kitalaltSzo, tippekSzama, rosszTippek);
												if (TippEllenorzes(tippSTR, aSzo))
												{
															kitalaltSzo = BetuCserelo(tippSTR, aSzo, kitalaltSzo);
												}
												else
												{
															rosszTippek += tippSTR;
												}
												tippekSzama--;
									} while (tippekSzama > 0 && kitalaltSzo != aSzo);
									if (tippekSzama == 0)
									{
												Console.WriteLine($"Vesztettél, a kitalálandó szó: {aSzo}");
									}
									else
									{
												Console.WriteLine($"Gratulálok, nyertél, ennyi tipped maradt még: {tippekSzama}");
									}
									//-----------------------------
									Console.WriteLine("--- VÉGE ---");
									Console.ReadKey();
						}
						private static string BetuCserelo(string tippSTR, string aSzo, string kitalaltSzo)
						{
									string result = string.Empty;
									for (int i = 0; i < aSzo.Length; i++)
									{
												if (aSzo[i] == tippSTR[0])
												{
															result += tippSTR[0];
												}
												else
												{
															result += kitalaltSzo[i];
												}
									}
									return result;
						}
						private static bool TippEllenorzes(string tippSTR, string aSzo)
						{
									int i = 0;
									char c = tippSTR[0];
									while (i < aSzo.Length && aSzo[i] != c)
									{
												i++;
									}
									if (i < aSzo.Length)
									{
												return true;
									}
									return false;
						}
						private static string TippKeres(string adat, int tsz, string rosszTippek)
						{
									string result = string.Empty;
									Console.WriteLine($"Eddigi eredmény: {adat}");
									Console.WriteLine($"Lehetőségek száma: {tsz}");
									Console.WriteLine($"Rossz tippek: {rosszTippek}");
									do
									{
									//☺
												Console.Write("Tipp: ");
												result = Console.ReadLine();
												if (result.Length > 1)
												{
															Console.WriteLine("Csak egy betüt adhatsz meg.");
												}
									} while (result.Length != 1);

									return result;
						}
						private static string UresSzoGenerator(int length)
						{
									string result = string.Empty;
									for (int i = 0; i < length; i++)
									{
												result += "_";
									}

									return result;
						}
			}
}
