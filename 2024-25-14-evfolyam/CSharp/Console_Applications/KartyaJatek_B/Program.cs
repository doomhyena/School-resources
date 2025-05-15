using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartyaJatek_B
{
			class Program
			{
						static Random rnd = new Random();
						static readonly string[] values = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
						static void Main(string[] args)
						{
									Console.CursorVisible = false;
									string[] pakli = PakliGenerator();
									pakli = PakliMixer(pakli);
									Game(pakli);
									//-----------------------------------
									Console.ReadKey();
						}
						private static void Game(string[] pakli)
						{
									int aScore = 0, bScore = 0, n = 0, round = pakli.Length / 2;

									Console.WriteLine($"  Kör  |  A lap  |  B lap  |  Score");
									Console.WriteLine($"---------------------------");
									do
									{
												Console.Write($"  {round--}");
												Console.ReadKey(true);
												Console.Write($"      {pakli[n],-4}");
												Console.ReadKey(true);
												Console.Write($"     {pakli[n + 1],-4}");
												if (Get_Value(pakli[n]) == Get_Value(pakli[n + 1]))
												{
															aScore++;
															bScore++;
												}
												else if (Get_Value(pakli[n]) > Get_Value(pakli[n + 1]))
												{
															aScore++;
												}
												else
												{
															bScore++;
												}
												Console.Write($"       {aScore} vs {bScore}");
												Console.WriteLine();
												n += 2;
									} while (n < pakli.Length);
						}
						private static int Get_Value(string card)
						{
									// card="♥_6"
									string[] arr = card.Split('_');
									int result = Array.IndexOf(values, arr[1]);
									return result;
						}
						private static string[] PakliMixer(string[] pakli)
						{
									string temp;
									int p;
									for (int n = 0; n < 1000; n++)
									{
												for (int i = 0; i < pakli.Length; i++)
												{
															do
															{
																		p = rnd.Next(pakli.Length);
															} while (p == i);

															temp = pakli[p];
															pakli[p] = pakli[i];
															pakli[i] = temp;
												}
									}
									return pakli;
						}
						private static string[] PakliGenerator()
						{
									string[] result = new string[52];
									string[] simbolums = new string[] { "♥", "♦", "♣", "♠" };

									int n = 0;
									for (int s = 0; s < simbolums.Length; s++)
									{
												for (int v = 0; v < values.Length; v++)
												{
															result[n++] = $"{simbolums[s]}_{values[v]}";//simbolums[s]+"_"+values[v]
												}
									}

									return result;
						}
			}
}
