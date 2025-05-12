using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN_B
{
	class GameManager
	{
		private static Random rnd = new Random();
		private static Direction[] Dirs = new Direction[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left };
		private Model myModel;
		private View myView;
		private GameState gameState;

		public GameManager()
		{
			Size mazeSize = new Size() { W = 50, H = 25 };
			myModel = new Model(mazeSize);
			int menuWidth = myModel.MyMenu.Items.Max(q => q.Name.Length);
			myView = new View(mazeSize, menuWidth + 10);
			gameState = GameState.Menu;
		}
		internal void Start()
		{
			myView.Draw(myModel.MyBoard);
			myView.DrawMenuFrame();
			StartMenu();
		}
		#region Menu
		private void StartMenu()
		{
			myView.Draw(myModel.MyMenu);
			myView.DrawScore(0, 4, myModel.MyBoard.PointCount);
			do
			{
				if (Console.KeyAvailable)
				{
					switch (Console.ReadKey(true).Key)
					{
						case ConsoleKey.UpArrow:
							if (myModel.MyMenu.Selected > myModel.MyMenu.MinID)
							{
								myModel.MyMenu.Selected--;
							}
							else
							{
								myModel.MyMenu.Selected = myModel.MyMenu.MaxID;
							}
							myView.Draw(myModel.MyMenu);
							break;
						case ConsoleKey.DownArrow:
							if (myModel.MyMenu.Selected < myModel.MyMenu.MaxID)
							{
								myModel.MyMenu.Selected++;
							}
							else
							{
								myModel.MyMenu.Selected = myModel.MyMenu.MinID;
							}
							myView.Draw(myModel.MyMenu);
							break;
						case ConsoleKey.Enter:
							MenuSelect();
							break;
						default:
							break;
					}
				}
			} while (gameState == GameState.Menu);
		}
		private void MenuSelect()
		{
			switch (myModel.MyMenu.Selected)
			{
				case 1: // New
					gameState = GameState.Game;
					NewGame();
					break;
				case 2: // Load
					break;
				case 3: // Save
					break;
				case 4: // Exit
					gameState = GameState.Exit;
					break;
				default:
					break;
			}
		}
		#endregion
		private void NewGame()
		{
			Position nP;
			ResetState();
			do
			{
				Get_KeyPress();
				foreach (var actor in myModel.Actors)
				{
					nP = actor.NextPosition(actor.Dir);
					Collision_Detector(nP, actor);
					if (gameState == GameState.Game)
					{
						GameObject_Check(nP, actor);
						UIUpdate(actor);
					}
				}
				System.Threading.Thread.Sleep(15);
			} while (gameState == GameState.Game);
			System.Diagnostics.Debug.WriteLine(gameState);
			ProcessExit();
		}

		private void ResetState()
		{
			myModel.MyBoard = new Board(myModel.MyBoard.Size);
			myView.Draw(myModel.MyBoard);
			CreateActors();
			myView.Draw(myModel.Actors);
		}

		private void UIUpdate(IActor actor)
		{
			if (actor.UpdateRequired)
			{
				switch (actor.MyType)
				{
					case GameObject.PacMan:
						myView.Draw(actor);
						myView.Clear(actor);
						actor.UpdateRequired = false;
						break;
					case GameObject.Ghost:
						myView.Draw(actor);
						myView.Draw(actor.TempPos, myModel.MyBoard.Map[actor.TempPos.X, actor.TempPos.Y]);
						actor.UpdateRequired = false;
						break;
					default:
						break;
				}
			}
		}
		private void ProcessExit()
		{
			string msg = string.Empty;
			switch (gameState)
			{
				case GameState.Collision:
					msg = "Játék vége! Elkapott a Ghost!";
					gameState = GameState.Menu;
					break;
				case GameState.Win:
					msg = "Játék vége! Nyertél!";
					gameState = GameState.Menu;
					break;
				case GameState.Escape:
					msg = "Játék vége kiléptél!";
					gameState = GameState.Menu;
					break;
				default:
					break;
			}
			if (msg.Length > 0)
			{
				myView.DrawMessage(msg);
			}
		}
		private void GameObject_Check(Position nP, IActor actor)
		{
			switch (actor.MyType)
			{
				case GameObject.PacMan:
					switch (myModel.MyBoard.Map[nP.X, nP.Y])
					{
						case GameObject.Point:
							(actor as PacMan).Score += 50;
							myModel.MyBoard.Map[nP.X, nP.Y] = GameObject.Free;
							actor.Move(nP);
							myView.DrawScore((actor as PacMan).Score, myModel.MyBoard.FruitCount, myModel.MyBoard.PointCount);
							if (--myModel.MyBoard.PointCount == 0 && myModel.MyBoard.FruitCount == 0)
							{
								gameState = GameState.Win;
							}
							break;
						case GameObject.Free:
							actor.Move(nP);
							break;
						case GameObject.Fruit:
							(actor as PacMan).Score += 200;
							myModel.MyBoard.Map[nP.X, nP.Y] = GameObject.Free;
							actor.Move(nP);
							myView.DrawScore((actor as PacMan).Score, myModel.MyBoard.FruitCount, myModel.MyBoard.PointCount);
							if (--myModel.MyBoard.FruitCount == 0 && myModel.MyBoard.PointCount == 0)
							{
								gameState = GameState.Win;
							}
							break;
						default:
							break;
					}
					break;
				case GameObject.Ghost:
					switch (myModel.MyBoard.Map[nP.X, nP.Y])
					{
						case GameObject.Point:
							actor.Move(nP);
							break;
						case GameObject.Free:
							actor.Move(nP);
							break;
						case GameObject.Fruit:
							actor.Move(nP);
							break;
						case GameObject.Wall:
							actor.ChangeDirection(GetRandomDirection(actor, myModel.MyBoard.Map));
							break;
						default:
							break;
					}
					break;
				default:
					break;
			}
		}
		private void Collision_Detector(Position nP, IActor actor)
		{
			switch (actor.MyType)
			{
				case GameObject.PacMan:
					if (GetGOType(nP) == GameObject.Ghost)
					{
						gameState = GameState.Collision;
					}
					break;
				case GameObject.Ghost:
					if (GetGOType(nP) == GameObject.PacMan)
					{
						gameState = GameState.Collision;
					}
					break;
				default:
					break;
			}
		}
		private GameObject GetGOType(Position nP)
		{
			if (myModel.Actors.Any(q => q.Pos.Equals(nP)))
			{
				return myModel.Actors.First(q => q.Pos.Equals(nP)).MyType;
			}
			return GameObject.Free;
		}
		private void Get_KeyPress()
		{
			Position nP;
			if (Console.KeyAvailable)
			{
				switch (Console.ReadKey(true).Key)
				{
					case ConsoleKey.UpArrow:
						nP = myModel.PacMan.NextPosition(Direction.Up);
						if (myModel.MyBoard.Map[nP.X, nP.Y] != GameObject.Wall)
						{
							myModel.PacMan.ChangeDirection(Direction.Up);
						}
						break;
					case ConsoleKey.RightArrow:
						nP = myModel.PacMan.NextPosition(Direction.Right);
						if (myModel.MyBoard.Map[nP.X, nP.Y] != GameObject.Wall)
						{
							myModel.PacMan.ChangeDirection(Direction.Right);
						}
						break;
					case ConsoleKey.DownArrow:
						nP = myModel.PacMan.NextPosition(Direction.Down);
						if (myModel.MyBoard.Map[nP.X, nP.Y] != GameObject.Wall)
						{
							myModel.PacMan.ChangeDirection(Direction.Down);
						}
						break;
					case ConsoleKey.LeftArrow:
						nP = myModel.PacMan.NextPosition(Direction.Left);
						if (myModel.MyBoard.Map[nP.X, nP.Y] != GameObject.Wall)
						{
							myModel.PacMan.ChangeDirection(Direction.Left);
						}
						break;
					case ConsoleKey.Escape:
						gameState = GameState.Escape;
						break;
					default:
						break;
				}
			}
		}
		private void CreateActors()
		{
			Position pos;
			Direction dir;
			Ghost ghost;
			myModel.Actors.Clear();
			pos = GetFreePosition();
			myModel.PacMan = new PacMan(pos, 5);
			dir = GetRandomDirection(myModel.PacMan, myModel.MyBoard.Map);
			myModel.PacMan.ChangeDirection(dir);
			myModel.Actors.Add(myModel.PacMan);
			for (int i = 0; i < 4; i++)
			{
				pos = GetFreePosition();
				ghost = new Ghost(pos, rnd.Next(3, 8), myModel.MyBoard);
				dir = GetRandomDirection(ghost, myModel.MyBoard.Map);
				ghost.ChangeDirection(dir);
				//
				//myModel.Actors.Add(ghost);
			}
		}
		public static Direction GetRandomDirection(IActor _actor, GameObject[,] _map)
		{
			Direction dir;
			Position nP;
			do
			{
				dir = Dirs[rnd.Next(Dirs.Length)];
				nP = _actor.NextPosition(dir);
			} while (_map[nP.X, nP.Y] == GameObject.Wall);
			return dir;
		}
		private Position GetFreePosition()
		{
			int x = 0, y = 0;
			bool find = false;
			do
			{
				x = rnd.Next(1, myModel.MyBoard.Size.W);
				y = rnd.Next(1, myModel.MyBoard.Size.H);
				if (myModel.MyBoard.Map[x, y] == GameObject.Free || myModel.MyBoard.Map[x, y] == GameObject.Point)
				{
					if (!myModel.Actors.Any(q => q.Pos.X == x && q.Pos.Y == y))
					{
						find = true;
					}
				}
			} while (!find);
			return new Position() { X = x, Y = y };
		}
	}
}
