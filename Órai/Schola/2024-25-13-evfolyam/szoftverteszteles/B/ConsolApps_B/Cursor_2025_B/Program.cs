using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Cursor_2025_B
{
	internal class Program
	{
		static Random rnd = new Random();
		static Direction[] dirs;
		static bool exit = false;
		static int width, height;
		static int offsetX, offsetY;

		static void Main(string[] args)
		{
			// console inicializálás
			Console.CursorVisible = false;
			Console.OutputEncoding = Encoding.UTF8;

			// változók + tulajdonságok
			width = 60;
			height = 20;
			int x = width / 2;
			int y = height / 2;
			int xT = x, yT = y;
			int step = rnd.Next(2, 16);		
			offsetX = Console.WindowWidth / 2 - x;
			offsetY = Console.WindowHeight / 2 - y;



			char face = '█'; //Alt + 219
			Direction dir = Direction.Right;

			// algoritmus
			DrawRectangle(width, height);
			DrawCursor(x, y, face, ConsoleColor.Red);
			do
			{
				/* pozíció ujraszámítása
				 * új helyen kirajzolni
				 * régi helyről törölni								 
				 */
				xT = x; //jelenlegi pozíció mentése
				yT = y; //jelenlegi pozíció mentése
				ChangeDirection(ref step, ref dir);
				CalculatePosition(ref x, ref y, ref dir); // pozíció újraszámítása
				DrawCursor(x, y, face,ConsoleColor.Red); // kurzor kirajzolása
				DrawCursor(xT, yT, ' ',ConsoleColor.Black); // törlés
				System.Threading.Thread.Sleep(100); // várakoztatás
			} while (!exit);
			//-------------------
			//Console.ReadKey();
		}

		private static void DrawRectangle(int width, int height)
		{
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (y == 0 || x == 0 || y == height - 1 || x == width - 1)
					{
						DrawCursor(x, y, '█', ConsoleColor.DarkYellow);
					}
				}
			}
		}
		private static void ChangeDirection(ref int step, ref Direction dir)
		{
			//if (step == 0)
			//{
			//	dirs = new Direction[] { Direction.Down, Direction.Left, Direction.Right, Direction.Up };
			//	dir = dirs[rnd.Next(dirs.Length)];
			//	step = rnd.Next(2, 10);
			//}
			//else
			//{
			//	step--;
			//}

			if (Console.KeyAvailable)
			{
				switch (Console.ReadKey(true).Key)
				{
					case ConsoleKey.Escape:
						exit = true;
						break;
					case ConsoleKey.RightArrow:
						dir = Direction.Right;
						break;
					case ConsoleKey.LeftArrow:
						dir = Direction.Left;
						break;
					case ConsoleKey.UpArrow:
						dir = Direction.Up;
						break;
					case ConsoleKey.DownArrow:
						dir = Direction.Down;
						break;
					default:
						break;
				}
			}
		}
		private static void CalculatePosition(ref int x, ref int y, ref Direction dir)
		{

			switch (dir)
			{
				case Direction.Up:
					if (y > 1)
					{
						y--;
					}
					else
					{
						dirs = new Direction[] { Direction.Down, Direction.Left, Direction.Right };
						dir = dirs[rnd.Next(dirs.Length)];
					}
					break;
				case Direction.Down:
					if (y < height - 2)
					{
						y++;
					}
					else
					{
						dirs = new Direction[] { Direction.Up, Direction.Left, Direction.Right };
						dir = dirs[rnd.Next(dirs.Length)];
					}
					break;
				case Direction.Left:
					if (x > 1)
					{
						x--;
					}
					else
					{
						dirs = new Direction[] { Direction.Down, Direction.Up, Direction.Right };
						dir = dirs[rnd.Next(dirs.Length)];
					}
					break;
				case Direction.Right:
					if (x < width - 2)
					{
						x++;
					}
					else
					{
						dirs = new Direction[] { Direction.Down, Direction.Left, Direction.Up };
						dir = dirs[rnd.Next(dirs.Length)];
					}
					break;
				default:
					break;
			}
		}
		private static void DrawCursor(int x, int y, char face, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.SetCursorPosition(x + offsetX, y + offsetY);
			Console.Write(face);
		}
	}

	public enum Direction { Up, Down, Left, Right }
}
