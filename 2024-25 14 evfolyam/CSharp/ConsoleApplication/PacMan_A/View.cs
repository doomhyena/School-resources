using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_A
{
	internal class View
	{
		private Position scorePosition;
		private Size boardSize;
		private int menuWidth;
		private readonly Dictionary<GameObject, char> goChar = new Dictionary<GameObject, char>() {
						{GameObject.Fruit,'☼' },
						{ GameObject.Free,' '},
						{ GameObject.Point,'•'},
						{ GameObject.Wall,'█'},
						{GameObject.PacMan,'☻' },
						{ GameObject.Ghost,'☺'}
						};
		private readonly Dictionary<GameObject, ConsoleColor> goColor = new Dictionary<GameObject, ConsoleColor>() {
						{GameObject.Fruit,ConsoleColor.Yellow },
						{ GameObject.Free,ConsoleColor.Black},
						{ GameObject.Point,ConsoleColor.White},
						{ GameObject.Wall,ConsoleColor.White},
						{ GameObject.PacMan,ConsoleColor.Blue},
						{ GameObject.Ghost,ConsoleColor.Red},
						};
		public View(Size _boardSize, int _menuWidth)
		{
			menuWidth = _menuWidth;
			boardSize = _boardSize;
			Console.CursorVisible = false;
			Console.SetWindowSize(boardSize.W + menuWidth, boardSize.H);
			Console.SetBufferSize(boardSize.W + menuWidth, boardSize.H + 1);
			Console.OutputEncoding = Encoding.UTF8;
			scorePosition = new Position()
			{
				X = boardSize.W + (menuWidth / 2 - 6), //"SCORE: 99999"
				Y = boardSize.H - 2
			};
		}
		public void DrawScore(int score, int fruitCount, int pointCount)
		{
			Console.ForegroundColor = ConsoleColor.Green;

			Console.SetCursorPosition(scorePosition.X, scorePosition.Y - 4);
			Console.Write($"POINT: {pointCount,5}");

			Console.SetCursorPosition(scorePosition.X, scorePosition.Y - 2);
			Console.Write($"FRUIT: {fruitCount,5}");


			Console.SetCursorPosition(scorePosition.X, scorePosition.Y);
			Console.Write($"SCORE: {score,5}");
		}
		public void Draw(Board board)
		{
			for (int y = 0; y < board.Size.H; y++)
			{
				for (int x = 0; x < board.Size.W; x++)
				{
					Console.SetCursorPosition(x, y);
					Console.ForegroundColor = goColor[board.Map[x, y]];
					Console.Write(goChar[board.Map[x, y]]);
				}
			}
		}
		public void DrawMenuBorder()
		{
			Console.ForegroundColor = goColor[GameObject.Wall];

			for (int y = 0; y < boardSize.H; y++)
			{
				for (int x = 0; x <= menuWidth; x++)
				{
					if (x == 0 || y == 0 || x == menuWidth || y == boardSize.H - 1)
					{
						Console.SetCursorPosition(x + boardSize.W - 1, y);
						Console.Write(goChar[GameObject.Wall]);
					}
				}
			}
			// MENU felirat
			Console.SetCursorPosition(boardSize.W + (menuWidth / 2 - 2), 0);
			Console.ForegroundColor = (goColor[GameObject.Free]);
			Console.BackgroundColor = goColor[GameObject.Wall];
			Console.Write("MENU");
		}
		internal void Draw(Menu menu)
		{
			int x = boardSize.W, y = 2;
			foreach (var item in menu.Items)
			{
				Console.SetCursorPosition(x + (menuWidth / 2 - item.Text.Length / 2), y);
				if (item.Id == menu.Selected)
				{
					Console.ForegroundColor = (goColor[GameObject.Free]);
					Console.BackgroundColor = (goColor[GameObject.Wall]);
				}
				else
				{
					Console.ForegroundColor = (goColor[GameObject.Wall]);
					Console.BackgroundColor = (goColor[GameObject.Free]);
				}

				Console.Write(item.Text);
				y += 2;
			}
		}
		internal void Clear(IActor actor)
		{
			Console.SetCursorPosition(actor.TempPos.X, actor.TempPos.Y);
			Console.ForegroundColor = (goColor[GameObject.Free]);
			Console.Write(goChar[GameObject.Free]);
		}
		internal void Draw(List<IActor> actors)
		{
			foreach (var actor in actors)
			{
				Draw(actor);
			}
		}
		public void Draw(IActor actor)
		{
			Console.SetCursorPosition(actor.Pos.X, actor.Pos.Y);
			Console.ForegroundColor = (goColor[actor.MyType]);
			Console.Write(goChar[actor.MyType]);
		}
		internal void DrawMessage(string msg)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.SetCursorPosition(boardSize.W / 2 - msg.Length / 2, boardSize.H / 2);
			Console.Write(msg);
		}
		internal void Draw(Position _pos, GameObject _gO)
		{
			Console.SetCursorPosition(_pos.X, _pos.Y);
			Console.ForegroundColor = (goColor[_gO]);
			Console.Write(goChar[_gO]);
		}

	}
}
