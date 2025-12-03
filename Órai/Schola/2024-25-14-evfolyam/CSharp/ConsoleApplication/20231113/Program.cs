using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231113
{
			internal class Program
			{
						static int xO, yO;
						static void Main(string[] args)
						{
									#region Init
									Console.CursorVisible = false;
									int x, xt, y, yt, w, h;
									bool end = false;
									#endregion

									x = Console.WindowWidth / 2;
									y = Console.WindowHeight / 2;
									w = 20;
									h = 20;
									xO = Console.WindowWidth / 2 - w / 2;
									yO = Console.WindowHeight / 2 - h / 2;

									Draw_Frame(w, h);
									Draw(x, y);
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
																					if (Check(x, y - 1))
																					{
																								xt = x;
																								yt = y;
																								y--;
																								Draw(x, y);
																								Clear(xt, yt);
																					}
																					break;
																		case ConsoleKey.RightArrow:
																					if (Check(x + 1, y))
																					{
																								xt = x;
																								yt = y;
																								x++;
																								Draw(x, y);
																								Clear(xt, yt);
																					}
																					break;
																		case ConsoleKey.LeftArrow:
																					if (Check(x - 1, y))
																					{
																								xt = x;
																								yt = y;
																								x--;
																								Draw(x, y);
																								Clear(xt, yt);
																					}
																					break;
																		case ConsoleKey.DownArrow:
																					if (Check(x, y + 1))
																					{
																								xt = x;
																								yt = y;
																								y++;
																								Draw(x, y);
																								Clear(xt, yt);
																					}
																					break;
																		default:
																					break;
															}
												}
									} while (!end);
									//-----------------------
									//Console.ReadKey();
						}

						private static void Draw_Frame(int w, int h)
						{									
									int x = 0, y = 0;

									for (x = 0; x < w; x++)
									{
												Draw(xO + x, yO + y);
												Draw(xO + x, yO + y + h - 1);
									}
									x = 0;
									for ( y = 0; y < h; y++)
									{
												Draw(xO + x, yO + y);
												Draw(xO + x+w-1, yO + y);
									}
						}

						private static bool Check(int x, int y)
						{
									if (x >= xO+1 && x < Console.WindowWidth-xO-1 && y >= yO+1 && y < Console.WindowHeight-yO-1)
									{
												return true;
									}
									return false;
						}

						private static void Clear(int xt, int yt)
						{
									Console.SetCursorPosition(xt, yt);
									Console.Write(" ");
						}

						private static void Draw(int x, int y)
						{
									Console.SetCursorPosition(x, y);
									Console.Write("█");
						}
			}
}
