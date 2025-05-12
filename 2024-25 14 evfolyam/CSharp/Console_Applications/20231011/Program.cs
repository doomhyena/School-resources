using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231011
{
			class Program
			{
						static Random rnd = new Random();
						static ConsoleColor[] colors = new ConsoleColor[]      {ConsoleColor.Black,ConsoleColor.DarkBlue,ConsoleColor.DarkGreen,ConsoleColor.DarkCyan,ConsoleColor.DarkRed,ConsoleColor.DarkMagenta,ConsoleColor.DarkYellow,ConsoleColor.Gray,ConsoleColor.DarkGray,ConsoleColor.Blue,ConsoleColor.Green,ConsoleColor.Cyan,ConsoleColor.Red,ConsoleColor.Magenta,ConsoleColor.Yellow, ConsoleColor.White
						};
						static void Main(string[] args)
						{
									/*Kérj be a konzolról 4 egész számot, amelyek segítségével kirajzolsz egy téglalapot a képernyőre. A négy szám: x,y,sz,m. X,y a téglalap bal felső sarka, sz a szélesség, m a magasság.
									 */
									#region Adatbekérés
									int x, y, sz, m;
									//Console.Write("x:");
									//int.TryParse(Console.ReadLine(), out x);
									//Console.Write("y:");
									//int.TryParse(Console.ReadLine(), out y);
									//Console.Write("sz:");
									//int.TryParse(Console.ReadLine(), out sz);
									//Console.Write("m:");
									//int.TryParse(Console.ReadLine(), out m);

									#endregion



									do
									{
												x = rnd.Next(Console.WindowWidth - 2);
												y = rnd.Next(Console.WindowHeight - 2);
												sz = rnd.Next(2, Console.WindowWidth);
												m = rnd.Next(2, Console.WindowHeight);
												if (DrawCheck(x, y, sz, m))
												{
															DrawRectangle(x, y, sz, m, colors[rnd.Next(colors.Length)]);
															HeaderPrinter(x, y, sz, m);
															Console.ReadKey();
												}

									} while (true);


									//-------------- VÉGE -----------------
									Console.ReadKey();
						}
						static bool DrawCheck(int x, int y, int w, int h)
						{
									if (x + w > Console.WindowWidth || y + h > Console.WindowHeight || w < 2 || h < 2)
									{
												return false;
									}
									return true;
						}
						static void DrawRectangle(int x, int y, int w, int h, ConsoleColor color)
						{
									Console.CursorVisible = false;
									Console.ForegroundColor = color;
									for (int xi = 0; xi < w; xi++)
									{
												Console.SetCursorPosition(x + xi, y);
												Console.Write("█");
												Console.SetCursorPosition(x + xi, y + h - 1);
												Console.Write("█");
									}
									for (int yi = 0; yi < h; yi++)
									{
												Console.SetCursorPosition(x, y + yi);
												Console.Write("█");
												Console.SetCursorPosition(x + w - 1, y + yi);
												Console.Write("█");
									}
						}
						static void HeaderPrinter(int x, int y, int w, int h)
						{
									string text = $"W:{w} | H:{h}";
									int textX = x + (w / 2 - text.Length / 2);
									int textY = y;

									Console.SetCursorPosition(textX, textY);
									Console.Write(text);
						}
			}
}
