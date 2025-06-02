using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangles
{
	internal class Program
	{
		static Random rnd = new Random();
		static void Main(string[] args)
		{
			#region Változók

			#endregion


			Console.Clear();
			Console.SetCursorPosition(0, 0);
			Console.CursorVisible = false;
			Console.WindowWidth = 120;
			Console.OutputEncoding = Encoding.UTF8;
			ConsoleColor[] colors = new ConsoleColor[] {
			ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue,ConsoleColor.DarkBlue,ConsoleColor.DarkGreen,ConsoleColor.DarkGray,
			ConsoleColor.DarkMagenta,ConsoleColor.DarkYellow,ConsoleColor.Cyan,ConsoleColor.Gray,ConsoleColor.Magenta,ConsoleColor.White
			};

			int x, y, width, height, s1=0,s2=0;

			#region Console input
			//Console.Write("X :");
			//int.TryParse(Console.ReadLine(), out x);
			//Console.Write("Y :");
			//int.TryParse(Console.ReadLine(), out y);
			//Console.Write("Width :");
			//int.TryParse(Console.ReadLine(), out width);
			//Console.Write("Height :");
			//int.TryParse(Console.ReadLine(), out height); 
			#endregion

			do
			{
				x = rnd.Next(0, Console.WindowWidth - 2);
				y = rnd.Next(0, Console.WindowHeight - 2);
				width = rnd.Next(2, Console.WindowWidth);
				height = rnd.Next(2, Console.WindowHeight);
				if (x + width < Console.WindowWidth - 1 && y + height < Console.WindowHeight - 1)
				{
					Console.ForegroundColor = colors[rnd.Next(colors.Length)];
					Draw(x, y, width, height);
					s1++;
				}
				else
				{
					s2++;
				}
				System.Diagnostics.Debug.WriteLine($"Sikeres: {s1,8} | Sikertelen: {s2,8}");
			} while (true);
			//---------------------------------------------
			Console.ReadKey();
		}

		private static void Draw(int x, int y, int width, int height)
		{
			for (int y2 = 0; y2 < height; y2++)
			{
				for (int x2 = 0; x2 < width; x2++)
				{
					if (x2 == 0 || y2 == 0 || y2 == height - 1 || x2 == width - 1)
					{
						Console.SetCursorPosition(x + x2, y + y2);
						Console.Write('█');
					}
				}
			}
		}
	}
}
