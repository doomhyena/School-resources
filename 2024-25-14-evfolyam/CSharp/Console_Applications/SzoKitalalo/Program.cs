using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzoKitalalo
{
			class Program
			{
						static Random rnd = new Random();
						static string[] szotar = new string[] { "kerékpár", "mákostészta", "gumicsizma", "lakat", "elefánt" };
						static void Main(string[] args)
						{
									string aSzo = szotar[rnd.Next(szotar.Length)];
									string aktualis = UresSzoGenerator(aSzo.Length);
									string rosszTippek = string.Empty;
									string tipp;
									int maxTipp = 10;
									do
									{
												Console.WriteLine($"Jelenlegi helyzet: {aktualis}");
												Console.WriteLine($"Eddigi rossz tippek: {rosszTippek}");
												Console.WriteLine($"Tippelési lehetőségek száma: {maxTipp}");
												Console.Write("Tipped: ");
												tipp = Console.ReadLine();
												if (Ellenorzes(aSzo, tipp))
												{
															aktualis = BetuCserelo(aktualis, aSzo, tipp);
												}
												else
												{
															rosszTippek += tipp;
												}
												maxTipp--;
												Console.Clear();
									} while (maxTipp > 0 && aktualis != aSzo);
									if (maxTipp == 0)
									{
												Console.WriteLine($"Vesztettél, ez volt a kiatlálandó szó: {aSzo}");
									}
									else
									{
												Console.WriteLine($"Gratulálok, kitaláltad. Megmaradt tippek száma: {maxTipp}");
									}
									//---------------------------------------
									Console.WriteLine("---- VÉGE ----");
									Console.ReadKey();
						}

						private static string BetuCserelo(string aktualis, string aSzo, string tipp)
						{
									char c = tipp[0];
									string result = string.Empty;
									for (int i = 0; i < aktualis.Length; i++)
									{
												if (aSzo[i]==c)
												{
															result += c;
												}
												else
												{
															result += aktualis[i];
												}
									}
									return result;
						}

						private static bool Ellenorzes(string aSzo, string tipp)
						{
									if (tipp.Length > 0)
									{
												char c = tipp[0];
												int i = 0;
												while (i < aSzo.Length && aSzo[i] != c)
												{
															i++;
												}
												if (i < aSzo.Length)
												{
															return true;
												}
									}
									return false;
						}

						private static string UresSzoGenerator(int length)
						{
									string result = string.Empty;
									for (int i = 0; i < length; i++)
									{
												result += '_';
									}
									return result;
						}
			}
}
