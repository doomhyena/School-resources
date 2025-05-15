using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231108
{
			class Program
			{
						static int dx, dy;
						static void Main(string[] args)
						{
									#region Init
									Console.CursorVisible = false;
									int x, y, xTemp, yTemp, w, h;

									w = 52;
									h = 18;

									x = Console.WindowWidth / 2;
									y = Console.WindowHeight / 2;

									dx = Console.WindowWidth / 2 - w / 2;
									dy = Console.WindowHeight / 2 - h / 2;
									bool end = false;
									#endregion
									DrawFrame(w, h);
									Graphic(x, y, '█');
									do
									{
												if (Console.KeyAvailable)
												{
															switch (Console.ReadKey(true).Key)
															{
																		case ConsoleKey.Escape:
																					end = true;
																					break;
																		case ConsoleKey.UpArrow:
																					if (y > dy + 1)
																					{
																								xTemp = x;
																								yTemp = y;
																								y--;
																								Graphic(x, y, '█');
																								Graphic(xTemp, yTemp, ' ');
																					}
																					break;
																		case ConsoleKey.RightArrow:
																					if (x < Console.WindowWidth - 1 - dx - 1)
																					{
																								xTemp = x;
																								yTemp = y;
																								x++;
																								Graphic(x, y, '█');
																								Graphic(xTemp, yTemp, ' ');
																					}
																					break;
																		case ConsoleKey.DownArrow:
																					if (y < ((h % 2) == 1 ? Console.WindowHeight - 1 - dy - 1 : Console.WindowHeight - 1 - dy - 2))
																					{
																								xTemp = x;
																								yTemp = y;
																								y++;
																								Graphic(x, y, '█');
																								Graphic(xTemp, yTemp, ' ');
																					}
																					break;
																		case ConsoleKey.LeftArrow:
																					if (x > dx + 1)
																					{
																								xTemp = x;
																								yTemp = y;
																								x--;
																								Graphic(x, y, '█');
																								Graphic(xTemp, yTemp, ' ');
																					}
																					break;
																		default:
																					break;
															}
												}
									} while (!end);
						}
						private static void DrawFrame(int w, int h)
						{
									int y = 0;
									int x;
									for (x = 0; x < w; x++)
									{
												Graphic(dx + x, dy + y, '█');
												Graphic(dx + x, dy + y + h - 1, '█');
									}
									x = 0;
									for (y = 0; y < h; y++)
									{
												Graphic(dx + x, dy + y, '█');
												Graphic(dx + x + w - 1, dy + y, '█');
									}
						}
						private static void Graphic(int x, int y, char c)
						{
									Console.SetCursorPosition(x, y);
									Console.Write(c);
						}
			}
}
