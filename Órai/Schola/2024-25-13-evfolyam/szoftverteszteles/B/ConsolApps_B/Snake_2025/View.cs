using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2025
{
	internal class View
	{
		Position offset, gameOver, newGame;
		Size size;
		static Dictionary<MapObject, char> faces = new Dictionary<MapObject, char>()
		{
			{MapObject.Empty,' ' },
			{MapObject.Wall,'█' },
			{MapObject.Snake,'█' },
			{ MapObject.Food,'$'}
		};
		static Dictionary<MapObject, ConsoleColor> colors = new Dictionary<MapObject, ConsoleColor>()
		{
			{MapObject.Empty,ConsoleColor.Black },
			{MapObject.Wall,ConsoleColor.White },
			{MapObject.Snake,ConsoleColor.Yellow },
			{MapObject.Food,ConsoleColor.Green }
		};

		public View(Position _offset, Size _size)
		{
			offset = _offset;
			size = _size;

		}

		public void Draw(Map map)
		{
			for (int y = 0; y < map.Size.Height; y++)
			{
				for (int x = 0; x < map.Size.Width; x++)
				{
					Draw(x, y, faces[map.Data[x, y]], colors[map.Data[x, y]]);
				}
			}
		}

		public void Draw(int x, int y, char v, ConsoleColor color)
		{
			Console.SetCursorPosition(offset.X + x, offset.Y + y);
			Console.ForegroundColor = color;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Write(v);
		}

		public void Draw(Position p, MapObject mo)
		{
			Draw(p.X, p.Y, faces[mo], colors[mo]);
		}

		internal void EndProcess(string msg)
		{
			Console.SetCursorPosition(offset.X + size.Width / 2 - msg.Length / 2, offset.Y + size.Height / 2);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(msg);
		}

		internal bool NewGame()
		{
			string msg = "New Game [Y/N]";
			char result = '.';
			Console.SetCursorPosition(offset.X + size.Width / 2 - msg.Length / 2, offset.Y + size.Height / 2 + 1);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(msg);

			do
			{
				if (Console.KeyAvailable)
				{
					result = Console.ReadKey().KeyChar;
				}
			} while (result == '.' && !"YyNn".Contains(result));

			return "Yy".Contains(result);
		}

		public void Score(int score)
		{
			string msg = $"Score: {score,4}";
			Console.SetCursorPosition(offset.X + size.Width - msg.Length, offset.Y + size.Height);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Blue;
			Console.Write($"Score: {score,4}");
		}
	}
}

