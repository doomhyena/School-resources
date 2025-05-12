using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231120
{
			internal class Program
			{
						static Position offset;
						static Size size;
						static Random rnd = new Random();
						static void Main(string[] args)
						{
									#region Init
									Console.CursorVisible = false;
									offset = new Position() { x = 10, y = 2 };
									size = new Size() { width = 40, height = 20 };
									Position cursor = new Position() { x = size.width / 2, y = size.height / 2 };
									Position cursorT;
									Direction direction = Direction.Right;
									bool end = false;
									Direction[] dirs = new Direction[] { Direction.Left, Direction.Right, Direction.Up, Direction.Down };
									int step=rnd.Next(1,8);
									#endregion

									Draw_Frame(size);
									Draw(cursor, '#');
									#region Loop
									do
									{
												if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
												{
															end = true;
												}
												else
												{
															if (step > 0)
															{
																		step--;
															}
															else
															{
																		direction = dirs[rnd.Next(4)];
																		step = rnd.Next(1, 8);
															}
															if (Check(cursor, direction))
															{																	
																		cursorT = cursor;
																		cursor = NextPosition(cursor, direction);
																		Draw(cursor, '#');
																		Draw(cursorT, ' ');
																		System.Threading.Thread.Sleep(50);
															}
															else
															{
																		direction = dirs[rnd.Next(4)];
															}
												}
												
									} while (!end);
									#endregion


									//----------------------
									//Console.ReadKey();
						}

						private static bool Check(Position cursor, Direction direction)
						{
									Position p = NextPosition(cursor, direction);
									return (p.x > 0 && p.x < size.width - 1 && p.y > 0 && p.y < size.height - 1);
						}
						private static Position NextPosition(Position cursor, Direction direction)
						{
									Position p = new Position();
									switch (direction)
									{
												case Direction.Up:
															p = new Position() { x = cursor.x, y = cursor.y - 1 };
															break;
												case Direction.Right:
															p = new Position() { x = cursor.x + 1, y = cursor.y };
															break;
												case Direction.Down:
															p = new Position() { x = cursor.x, y = cursor.y + 1 };
															break;
												case Direction.Left:
															p = new Position() { x = cursor.x - 1, y = cursor.y };
															break;
												default:
															break;
									}

									return p;
						}
						private static void Draw_Frame(Size size)
						{
									int x = 0, y = 0;

									for (x = 0; x < size.width; x++)
									{
												Draw(x, y, '█');
												Draw(x, y + size.height - 1, '█');
									}
									x = 0;
									for (y = 0; y < size.height; y++)
									{
												Draw(x, y, '█');
												Draw(x + size.width - 1, y, '█');
									}
						}
						static void Draw(Position p, char c)
						{
									Console.SetCursorPosition(offset.x + p.x, offset.y + p.y);
									Console.Write(c);
						}
						static void Draw(int x, int y, char c)
						{
									Console.SetCursorPosition(offset.x + x, offset.y + y);
									Console.Write(c);
						}
			}

			public struct Position
			{
						public int x;
						public int y;
			}
			public struct Size
			{
						public int width;
						public int height;
			}
			public enum Direction { Up, Right, Down, Left }
}
