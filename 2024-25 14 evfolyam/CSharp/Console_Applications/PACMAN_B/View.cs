using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN_B
{
	class View
	{
		private Size mazeSize;
		private int menuWidth;
		private Position scorePosition, pointPosition,fruitPosition;
		private readonly Dictionary<GameObject, char> goChar = new Dictionary<GameObject, char>() {
						{GameObject.Free,' ' },
						{ GameObject.Wall,'█'},
						{ GameObject.Point,'•'},
						{ GameObject.Fruit,'¤'},
						{ GameObject.Ghost,'☺'}, { GameObject.PacMan,'☻'},
						};
		private readonly Dictionary<GameObject, ConsoleColor> goColor = new Dictionary<GameObject, ConsoleColor>() {
						{GameObject.Free,ConsoleColor.Black },
						{ GameObject.Wall,ConsoleColor.White},
						{ GameObject.Point,ConsoleColor.White},
						{ GameObject.Fruit,ConsoleColor.Green},{ GameObject.Ghost,ConsoleColor.Red},
						{ GameObject.PacMan,ConsoleColor.Yellow}
						};
		public View(Size _mazeSize, int _menuWidth)
		{
			Console.CursorVisible = false;
			Console.OutputEncoding = Encoding.UTF8;
			Console.SetWindowSize(_mazeSize.W + _menuWidth, _mazeSize.H);
			Console.SetBufferSize(_mazeSize.W + _menuWidth, _mazeSize.H + 1);
			mazeSize = _mazeSize;
			menuWidth = _menuWidth;
			scorePosition = new Position() { X = mazeSize.W + menuWidth / 2 - 6, Y = mazeSize.H - 2 };
			pointPosition = new Position() { X = mazeSize.W + menuWidth / 2 - 6, Y = mazeSize.H - 4 };
			fruitPosition= new Position() { X = mazeSize.W + menuWidth / 2 - 4, Y = mazeSize.H - 6 };
		}
		public void DrawScore(int score, int fruitCount, int pointCount)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(fruitPosition.X, fruitPosition.Y);
			Console.Write($"FRUIT : {fruitCount}");

			Console.SetCursorPosition(pointPosition.X, pointPosition.Y);
			Console.Write($"POINT : {pointCount,5}");

			Console.SetCursorPosition(scorePosition.X, scorePosition.Y);			
			Console.Write($"SCORE : {score,5}");
		}
		internal void Draw(Board myBoard)
		{
			for (int y = 0; y < myBoard.Size.H; y++)
			{
				for (int x = 0; x < myBoard.Size.W; x++)
				{
					Console.SetCursorPosition(x, y);
					Console.ForegroundColor = goColor[myBoard.Map[x, y]];
					Console.Write(goChar[myBoard.Map[x, y]]);
				}
			}
		}
		public void DrawMenuFrame()
		{
			for (int y = 0; y < mazeSize.H; y++)
			{
				for (int x = mazeSize.W; x < mazeSize.W + menuWidth; x++)
				{
					if (y == 0 || y == mazeSize.H - 1 || x == mazeSize.W || x == mazeSize.W + menuWidth - 1)
					{
						Console.SetCursorPosition(x, y);
						Console.ForegroundColor = goColor[GameObject.Wall];
						Console.Write(goChar[GameObject.Wall]);
					}
				}
			}
			Console.SetCursorPosition(mazeSize.W + menuWidth / 2 - 2, 0);
			Console.ForegroundColor = ConsoleColor.Black;
			Console.BackgroundColor = goColor[GameObject.Wall];
			Console.Write("MENU");

		}
		internal void Draw(Menu myMenu)
		{
			int x = mazeSize.W, y = 2;
			foreach (var item in myMenu.Items.OrderBy(q => q.ID))
			{
				Console.SetCursorPosition(x + (menuWidth / 2 - item.Name.Length / 2), y);
				Console.ForegroundColor = item.ID == myMenu.Selected ? ConsoleColor.White : ConsoleColor.DarkMagenta;
				Console.BackgroundColor = item.ID == myMenu.Selected ? ConsoleColor.DarkMagenta : goColor[GameObject.Free];
				Console.Write(item.Name);
				y += 2;
			}
		}
		internal void Draw(List<IActor> actors)
		{
			foreach (var item in actors)
			{
				Draw(item);
			}
		}
		internal void Clear(IActor actor)
		{
			Console.SetCursorPosition(actor.TempPos.X, actor.TempPos.Y);
			Console.ForegroundColor = goColor[GameObject.Free];
			Console.Write(goChar[GameObject.Free]);
		}
		internal void Draw(Position tP, GameObject gO)
		{
			Console.SetCursorPosition(tP.X, tP.Y);
			Console.ForegroundColor = goColor[gO];
			Console.Write(goChar[gO]);
		}
		public void Draw(IActor actor)
		{
			Console.SetCursorPosition(actor.Pos.X, actor.Pos.Y);
			Console.ForegroundColor = goColor[actor.MyType];
			Console.Write(goChar[actor.MyType]);
		}
		internal void DrawMessage(string msg)
		{
			Console.SetCursorPosition(mazeSize.W/2 - msg.Length / 2, mazeSize.H / 2);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(msg);
		}
	}
}
