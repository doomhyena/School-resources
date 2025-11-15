using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursorMove
{
	internal class Program
	{
		static Random rnd = new Random();
		static int x, y, step, xOld, yOld;
		static Direction dir;
		static Direction[] dirs = new Direction[] { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
		static int offsetX, offsetY;
		static int width, height;
		static bool exit = false;

		static void Main(string[] args)
		{
			Console.CursorVisible = false;

			//---------------------------------------
			width = 50;
			height = 25;
			dir = Direction.Right;
			x = xOld = width / 2;
			y = yOld = height / 2;
			step = rnd.Next(2, 9);
			offsetX = 10;
			offsetY = 3;

			Draw(x, y, '█', ConsoleColor.Green);
			DrawRectangle(width, height);
			do
			{
				// régi pozíció mentése
				xOld = x;
				yOld = y;
				// Irány változtatás
				ChangeDirection();
				//új pozíció számítás
				PositionCalculation();
				//várakoztatás
				System.Threading.Thread.Sleep(50);
				// kirajzolás
				Draw(x, y, '█', ConsoleColor.Green);
				// törlés
				Draw(xOld, yOld, ' ', ConsoleColor.Black);
				/*
				 * 1. kirajzolni a kurzort
				 * 2. letörölni a régi helyről
				 * 3. kitalálni az új koordinátát
				 * 4. várakoztatni
				 */
			} while (!exit);
		}

		private static void ChangeDirection()
		{
			if (step == 0)
			{
				dir = dirs[rnd.Next(dirs.Length)];
				step = rnd.Next(2, 9);
			}
			else {
				step--;
			}

		}
		private static void DrawRectangle(int width, int height)
		{
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
					{
						Draw(x, y, '█', ConsoleColor.Red);
					}
				}
			}
		}
		private static void PositionCalculation()
		{
			switch (dir)
			{
				case Direction.Left:
					if (x > 1)
					{
						xOld = x;
						x--;
					}
					else
					{
						dir = dirs[rnd.Next(dirs.Length)]; // új irány 
					}
					break;
				case Direction.Right:
					if (x < width - 2)
					{
						xOld = x;
						x++;
					}
					else
					{
						dir = dirs[rnd.Next(dirs.Length)]; // új irány 
					}
					break;
				case Direction.Up:
					if (y > 1)
					{
						yOld = y;
						y--;
					}
					else
					{
						dir = dirs[rnd.Next(dirs.Length)]; // új irány 
					}
					break;
				case Direction.Down:
					if (y < height - 2)
					{
						yOld = y;
						y++;
					}
					else
					{
						dir = dirs[rnd.Next(dirs.Length)]; // új irány 
					}
					break;
				default:
					break;
			}
			//if (step == 0)
			//{
			//	dir = dirs[rnd.Next(dirs.Length)];
			//	step = rnd.Next(2, 9);
			//}
			//else
			//{
			//	step--;
			//}
		}
		private static void Draw(int x, int y, char c, ConsoleColor color)
		{
			Console.SetCursorPosition(x + offsetX, y + offsetY);
			Console.ForegroundColor = color;
			Console.Write(c);
		}
	}

	public enum Direction { Left, Right, Up, Down }
}
