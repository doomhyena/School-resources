using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartyaJatek
{
			internal class Program
			{
						static Random rnd = new Random();
						static readonly string[] szinek = new string[] { "♥", "♦", "♣", "♠" };
						static readonly string[] ertek = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
						static void Main(string[] args)
						{
									string[] pakli = LapGenerator();
									pakli = PakliMixer(pakli);
									int aScore = 0, bScore = 0, pakliIndex = 0;
									string aValue, bValue;
									Console.WriteLine("    A    |    B    |  Scores");
									Console.WriteLine("----------------------------");
									do
									{
												// a játékos lapja pakli[pakliIndex], a b játékos lapja pakli[pakilIndex+1]
												aValue = pakli[pakliIndex].Split('_')[1];
												bValue = pakli[pakliIndex + 1].Split('_')[1];
												if (Array.IndexOf(ertek, aValue) == Array.IndexOf(ertek, bValue))
												{
															aScore++;
															bScore++;
												}
												else if (Array.IndexOf(ertek, aValue) > Array.IndexOf(ertek, bValue))
												{
															aScore++;
												}
												else
												{
															bScore++;
												}
												Console.WriteLine($"   {pakli[pakliIndex]}      {pakli[pakliIndex + 1]}      ({aScore} vs {bScore})");
												pakliIndex += 2;
												Console.ReadKey();
									} while (pakliIndex < pakli.Length);
									//----VÉGE---------
									Console.ReadKey();
						}

						private static string[] PakliMixer(string[] lapok)
						{
									string temp;
									int x;
									for (int i = 0; i < 1000; i++)
									{
												for (int j = 0; j < lapok.Length; j++)
												{
															do
															{
																		x = rnd.Next(lapok.Length);
															} while (x == j);
															temp = lapok[j];
															lapok[j] = lapok[x];
															lapok[x] = temp;
												}
									}
									return lapok;
						}

						private static string[] LapGenerator()
						{
									string[] result = new string[52];
									int n = 0;
									for (int i = 0; i < szinek.Length; i++)
									{
												for (int j = 0; j < ertek.Length; j++)
												{
															result[n++] = $"{szinek[i]}_{ertek[j]}";
												}
									}
									return result;
						}
			}
}
