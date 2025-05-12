using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231122
{
			class Program
			{
						static Random rnd = new Random();
						static Position cursor, offset, tempPos;
						static Size size;
						static Direction dir;
						static bool end;
						static Direction[] dirs = new Direction[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left };
						static int stepCounter;

						static void Main(string[] args)
						{
									Init();
									DrawFrame();
									Draw(cursor.x, cursor.y, '█');
									Loop();
									//---------------------
									//Console.ReadKey();
						}
						private static void Init()
						{
									Console.CursorVisible = false;
									size = new Size() { width = 50, height = 20 };
									cursor = new Position() { x = size.width / 2, y = size.height / 2 };
									offset = new Position() { x = 10, y = 3 };
									dir = Direction.Left;
									end = false;
									stepCounter = rnd.Next(3, 8);
						}
						private static void Loop()
						{
									Position nextPosition;

									do
									{
												if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
												{
															end = true;
												}
												else
												{
															if (stepCounter>0)
															{
																		stepCounter--;
															}
															else
															{
																		dir = dirs[rnd.Next(dirs.Length)];
																		stepCounter = rnd.Next(3, 8);
															}
															nextPosition = NextPosition();
															if (Check(nextPosition))
															{
																		Move(nextPosition);
																		System.Threading.Thread.Sleep(150);
															}
															else
															{
																		dir = dirs[rnd.Next(dirs.Length)];
															}
												}
									} while (!end);
						}
						private static bool Check(Position nP)
						{
									if (nP.x > 0 && nP.x < size.width - 1 && nP.y > 0 && nP.y < size.height - 1)
									{
												return true;
									}
									return false;
						}
						private static void Move(Position nextPosition)
						{
									tempPos = cursor;
									cursor = nextPosition;
									Draw(cursor.x, cursor.y, '█');
									Draw(tempPos.x, tempPos.y, ' ');
						}
						private static Position NextPosition()
						{
									switch (dir)
									{
												case Direction.Up:
															return new Position() { x = cursor.x, y = cursor.y - 1 };

												case Direction.Right:
															return new Position() { x = cursor.x + 1, y = cursor.y };

												case Direction.Down:
															return new Position() { x = cursor.x, y = cursor.y + 1 };

												case Direction.Left:
															return new Position() { x = cursor.x - 1, y = cursor.y };

												default:
															return cursor;

									}
						}
						private static void DrawFrame()
						{
									for (int y = 0; y < size.height; y++)
									{
												for (int x = 0; x < size.width; x++)
												{
															if (y == 0 || x == 0 || y == size.height - 1 || x == size.width - 1)
															{
																		Draw(x, y, '█');
															}
												}
									}
						}
						private static void Draw(int x, int y, char v)
						{
									Console.SetCursorPosition(offset.x + x, offset.y + y);
									Console.Write(v);
						}

			}

			public struct Position
			{
						public int x, y;
			}
			public struct Size
			{
						public int width, height;
			}
			public enum Direction { Up, Right, Down, Left }
}
