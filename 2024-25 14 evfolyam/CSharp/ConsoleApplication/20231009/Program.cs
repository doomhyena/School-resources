using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231009
{
			internal class Program
			{
						static Random rnd = new Random();
						static ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.DarkBlue, ConsoleColor.DarkGreen, ConsoleColor.DarkCyan, ConsoleColor.DarkMagenta, ConsoleColor.DarkRed, ConsoleColor.DarkYellow, ConsoleColor.Gray, ConsoleColor.DarkGray, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.White };
						static void Main(string[] args)
						{
									/*Kérj be 4 egész számot (x,y,sz,m)
									 * Állapítsd meg, hogy ezekkel az adatokkal kirajzolható e egy téglalap
									 * és ha igen rajzold ki
									 * 
									 */
									Console.WindowWidth = Console.LargestWindowWidth;
									Console.WindowHeight = Console.LargestWindowHeight;
									#region Adatbekérés
									//Console.Write("x:");
									//int.TryParse(Console.ReadLine(), out int x);
									//Console.Write("y:");
									//int.TryParse(Console.ReadLine(), out int y);
									//Console.Write("sz:");
									//int.TryParse(Console.ReadLine(), out int sz);
									//Console.Write("m:");
									//int.TryParse(Console.ReadLine(), out int m);
									#endregion
									int x, y, sz, m;
									do
									{
												x = rnd.Next(Console.WindowWidth - 2);
												y = rnd.Next(Console.WindowHeight - 2);
												sz = rnd.Next(2, Console.WindowWidth);
												m = rnd.Next(2, Console.WindowHeight);
												if (CheckRectangle(x, y, sz, m))
												{
															DrawRectangle(x, y, sz, m, colors[rnd.Next(colors.Length)]);
												}
									} while (true);


								

									//--------------VÉGE--------------------			
									Console.ReadKey();
						}
						static void DrawRectangle(int offsetX, int offsetY, int width, int height, ConsoleColor color)
						{
									#region Rajzolás
									Console.CursorVisible = false;
									Console.ForegroundColor = color;
									for (int xi = 0; xi < width; xi++)
									{
												Console.SetCursorPosition(offsetX + xi, offsetY);
												Console.Write("█");
												Console.SetCursorPosition(offsetX + xi, offsetY + height - 1);
												Console.Write("█");
									}
									for (int yi = 0; yi < height; yi++)
									{
												Console.SetCursorPosition(offsetX, offsetY + yi);
												Console.Write("█");
												Console.SetCursorPosition(offsetX + width - 1, offsetY + yi);
												Console.Write("█");
									}
									#endregion
						}
						static bool CheckRectangle(int offsetX, int offsetY, int width, int height)
						{
									//if (width < 2 || height < 2 || offsetX + width > Console.WindowWidth || offsetY + height > Console.WindowHeight)
									//{
									//			return false;
									//}
									//else
									//{
									//			return true;
									//}
									return !(width < 2 || height < 2 || offsetX + width > Console.WindowWidth || offsetY + height > Console.WindowHeight);
						}
			}
}
