using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2025_A
{
	class View
	{
		Size size;
		Position offset;
		static Dictionary<GameObject, char> chars = new Dictionary<GameObject, char>()
		{
			{ GameObject.Empty,' ' },
			{ GameObject.Wall, '█'},
			{ GameObject.Snake, '█'},
			{ GameObject.Snack,'#'}

		};
		static Dictionary<GameObject, ConsoleColor> colors = new Dictionary<GameObject, ConsoleColor>()
		{
			{ GameObject.Empty,ConsoleColor.Black },
			{ GameObject.Wall, ConsoleColor.White},
			{ GameObject.Snake, ConsoleColor.Yellow},
			{ GameObject.Snack,ConsoleColor.Green}
		};

		public View(Size _size)
		{
			size = _size;
			offset = new Position()
			{
				X = Console.WindowWidth / 2 - size.Width / 2,
				Y = Console.WindowHeight / 2 - size.Height / 2
			};
		}
		public void Draw(Map map)
		{
			for (int y = 0; y < size.Height; y++)
			{
				for (int x = 0; x < size.Width; x++)
				{
					//                    GameObject                GameObject
					Draw(x, y, chars[map.Matrix[x, y]], colors[map.Matrix[x, y]]);
				}
			}
		}
		private void Draw(int x, int y, char c, ConsoleColor color)
		{
			Console.SetCursorPosition(offset.X + x, offset.Y + y);
			Console.ForegroundColor = color;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Write(c);
		}

		internal void Draw(Position nP, GameObject gO)
		{
			Console.SetCursorPosition(offset.X + nP.X, offset.Y + nP.Y);
			Console.ForegroundColor = colors[gO];
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Write(chars[gO]);
		}

		internal void Message(string msg)
		{
			Console.SetCursorPosition(offset.X + size.Width / 2 - msg.Length / 2, offset.Y + size.Height / 2);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Write(msg);
		}

		internal void WriteScore(int score)
		{
			string msg = $"SCORE: {score,4}";
			Console.SetCursorPosition(offset.X + size.Width / 2 - msg.Length / 2, offset.Y);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.BackgroundColor = ConsoleColor.White;
			Console.Write(msg);
		}
	}
}
