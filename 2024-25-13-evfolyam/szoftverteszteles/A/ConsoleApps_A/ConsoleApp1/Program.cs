using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static Random rnd = new Random();
		static void Main(string[] args)
		{
			Console.Clear();
			Console.CursorVisible = false;

			Console.WindowWidth = 40;
			Console.WindowHeight = 20;
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.BackgroundColor = ConsoleColor.White;
			Console.WriteLine($"Width:{Console.WindowWidth}");
			Console.WriteLine($"Height:{Console.WindowHeight}");

			//for (int y = 0; y < Console.WindowHeight; y++)
			//{
			//	for (int x = 0; x < Console.WindowWidth; x++)
			//	{
			//		Console.SetCursorPosition(x, y);
			//		Console.Write('█');
			//	}
			//}
			int x, y;
			ConsoleColor[] colors = new ConsoleColor[] {
			ConsoleColor.Red,ConsoleColor.Green,ConsoleColor.Blue,ConsoleColor.Magenta,ConsoleColor.Cyan,
			ConsoleColor.Gray,ConsoleColor.White,ConsoleColor.White
			};

			do
			{
				x = rnd.Next(Console.WindowWidth);
				y = rnd.Next(Console.WindowHeight);
				Console.SetCursorPosition(x, y);
				Console.ForegroundColor = colors[rnd.Next(colors.Length)];
				Console.Write('█');
			} while (true);

			//----------------------------
			Console.ReadKey();
		}
	}
}
