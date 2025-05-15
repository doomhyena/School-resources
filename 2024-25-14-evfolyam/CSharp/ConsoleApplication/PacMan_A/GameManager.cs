using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_A
{
	internal class GameManager
	{
		static Random rnd = new Random();
		Direction[] dirs = new Direction[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left };
		Model model;
		View view;
		GameState state;
		public GameManager(Size _size)
		{
			model = new Model(_size);
			int menuWidth = model.Menu.Items.Max(q => q.Text.Length);
			view = new View(_size, menuWidth + 8);
			state = GameState.Menu;
		}
		internal void Start()
		{
			view.Draw(model.Board);
			StartMenu();
		}
		#region Menu
		private void StartMenu()
		{
			view.DrawMenuBorder();
			view.Draw(model.Menu);
			view.DrawScore(0, model.Board.FruitCount, model.Board.PointCount);
			do
			{
				if (Console.KeyAvailable)
				{
					switch (Console.ReadKey(true).Key)
					{
						case ConsoleKey.Enter:
							MenuSelect();
							break;
						case ConsoleKey.UpArrow:
							if (model.Menu.Selected > model.Menu.MinID)
							{
								model.Menu.Selected--;
							}
							else
							{
								model.Menu.Selected = model.Menu.MaxID;
							}
							view.Draw(model.Menu);
							break;
						case ConsoleKey.DownArrow:
							if (model.Menu.Selected < model.Menu.MaxID)
							{
								model.Menu.Selected++;
							}
							else
							{
								model.Menu.Selected = model.Menu.MinID;
							}
							view.Draw(model.Menu);
							break;
						default:
							break;
					}
				}
			} while (state == GameState.Menu);
		}
		private void MenuSelect()
		{
			switch (model.Menu.Selected)
			{
				case 1: //New
					state = GameState.Game;
					NewGame();
					break;
				case 2: // Load
					break;
				case 3: // Save
					break;
				case 4: // Exit
					state = GameState.Exit;
					break;
				default:
					break;
			}
		}
		#endregion
		private void NewGame()
		{
			model.Board = new Board(model.Board.Size);
			view.Draw(model.Board);
			model.Actors.Clear();
			CreateActors();
			view.Draw(model.Actors);
			Position nP;
			do
			{
				#region Keyboard press process
				GetKeyPress();
				#endregion
				foreach (var actor in model.Actors)
				{
					nP = actor.NextStep(actor.Dir);
					// Collision detect
					CollisonDetect(nP, actor);
					if (state == GameState.Game)
					{
						GameObject_Check(nP, actor);
						if (actor.UpdateRequired)
						{
							switch (actor.MyType)
							{
								case GameObject.Ghost:
									view.Draw(actor);
									view.Draw(actor.TempPos, model.Board.Map[actor.TempPos.X, actor.TempPos.Y]);
									actor.UpdateRequired = false;
									break;
								case GameObject.PacMan:
									view.Draw(actor);
									view.Clear(actor);
									actor.UpdateRequired = false;
									break;
								default:
									break;
							}
						}
					}
				}
				System.Threading.Thread.Sleep(15);
			} while (state == GameState.Game);
			ProcessExit();
		}
		private void ProcessExit()
		{
			string msg = string.Empty;
			switch (state)
			{
				case GameState.Win:
					msg = "Vége a játéknak. Nyertél!";
					state = GameState.Menu;
					break;
				case GameState.Escape:
					msg = "Vége a játéknak. Kiléptél!";
					state = GameState.Menu;
					break;
				case GameState.Kill:
					msg = "Vége a játéknak. Elkapott a szellem!";
					state = GameState.Menu;
					break;
				default:
					break;
			}
			if (msg.Length > 0)
			{
				view.DrawMessage(msg);
			}
		}
		private void GameObject_Check(Position nP, IActor actor)
		{
			switch (actor.MyType)
			{
				case GameObject.Ghost:
					switch (model.Board.Map[nP.X, nP.Y])
					{
						case GameObject.Point:
							actor.Move(nP);
							break;
						case GameObject.Free:
							actor.Move(nP);
							break;
						case GameObject.Wall:
							// új irányt kell keresni
							actor.ChangeDirection(GetRandomDirection(actor));
							break;
						case GameObject.Fruit:
							actor.Move(nP);
							break;
						default:
							break;
					}
					break;
				case GameObject.PacMan:
					switch (model.Board.Map[nP.X, nP.Y])
					{
						case GameObject.Point:
							actor.Move(nP);
							if (actor.UpdateRequired)
							{
								(actor as PacMan).Score += 20;
								//model.Board.PointCount--;
								model.Board.Map[nP.X, nP.Y] = GameObject.Free;
								view.DrawScore((actor as PacMan).Score, model.Board.FruitCount, --model.Board.PointCount);
								if (model.Board.FruitCount == 0 && model.Board.PointCount == 0)
								{
									state = GameState.Win;
								}
							}
							break;
						case GameObject.Free:
							actor.Move(nP);
							break;
						case GameObject.Fruit:
							actor.Move(nP);
							if (actor.UpdateRequired)
							{
								(actor as PacMan).Score += 100;
								model.Board.FruitCount--;
								model.Board.Map[nP.X, nP.Y] = GameObject.Free;
								view.DrawScore((actor as PacMan).Score, model.Board.FruitCount, model.Board.PointCount);
								if (model.Board.FruitCount == 0 && model.Board.PointCount == 0)
								{
									state = GameState.Win;
								}
							}
							break;
						default:
							break;
					}
					break;
				default:
					break;
			}
		}
		private void CollisonDetect(Position nP, IActor actor)
		{
			if (model.Actors.Any(q => q.Pos.Equals(nP)))
			{
				switch (actor.MyType)
				{
					case GameObject.Ghost:
						if (model.Actors.Single(q => q.MyType == GameObject.PacMan).Pos.Equals(nP))
						{
							state = GameState.Kill;
						}
						break;
					case GameObject.PacMan:
						state = GameState.Kill;
						break;
					default:
						break;
				}
			}
		}
		private void GetKeyPress()
		{
			Position nP;
			if (Console.KeyAvailable)
			{
				switch (Console.ReadKey(true).Key)
				{
					case ConsoleKey.Escape:
						state = GameState.Escape;
						break;
					case ConsoleKey.UpArrow:
						nP = model.PacMan.NextStep(Direction.Up);
						if (model.Board.Map[nP.X, nP.Y] != GameObject.Wall)
						{
							model.PacMan.ChangeDirection(Direction.Up);
						}
						break;
					case ConsoleKey.DownArrow:
						nP = model.PacMan.NextStep(Direction.Down);
						if (model.Board.Map[nP.X, nP.Y] != GameObject.Wall)
						{
							model.PacMan.ChangeDirection(Direction.Down);
						}
						break;
					case ConsoleKey.LeftArrow:
						nP = model.PacMan.NextStep(Direction.Left);
						if (model.Board.Map[nP.X, nP.Y] != GameObject.Wall)
						{
							model.PacMan.ChangeDirection(Direction.Left);
						}
						break;
					case ConsoleKey.RightArrow:
						nP = model.PacMan.NextStep(Direction.Right);
						if (model.Board.Map[nP.X, nP.Y] != GameObject.Wall)
						{
							model.PacMan.ChangeDirection(Direction.Right);
						}
						break;
					default:
						break;
				}
			}
		}
		private void CreateActors()
		{
			model.PacMan = new PacMan(GetFreePosition(), 5);
			model.PacMan.ChangeDirection(GetRandomDirection(model.PacMan));
			model.Actors.Add(model.PacMan);
			Ghost ghost;
			for (int i = 0; i < 4; i++)
			{
				ghost = new Ghost(GetFreePosition(), rnd.Next(3, 5), model.Board);
				ghost.ChangeDirection(GetRandomDirection(ghost));
				model.Actors.Add(ghost);
			}
		}
		private Direction GetRandomDirection(IActor _actor)
		{
			Direction dir;
			Position nP;
			do
			{
				dir = dirs[rnd.Next(dirs.Length)];
				nP = _actor.NextStep(dir);
			} while (model.Board.Map[nP.X, nP.Y] == GameObject.Wall);

			return dir;
		}
		private Position GetFreePosition()
		{
			int x, y;
			bool found = false;
			Position result = new Position();
			do
			{
				x = rnd.Next(1, model.Board.Size.W);
				y = rnd.Next(1, model.Board.Size.H);
				if (model.Board.Map[x, y] == GameObject.Point || model.Board.Map[x, y] == GameObject.Free)
				{
					result = new Position() { X = x, Y = y };
					if (!model.Actors.Any(q => q.Pos.Equals(result)))
					{
						found = true;
					}
				}
			} while (!found);
			return result;
		}
	}
}
