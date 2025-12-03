using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2024_A
{
	internal class GameManager
	{
		private static Random rnd = new Random();
		private Model model;
		private View view;
		private GameState state;
		private int speed, superFoodCounter;

		public GameManager(Size size)
		{
			model = new Model(size);
			view = new View(new Position()
			{
				X = Console.WindowWidth / 2 - size.W / 2,
				Y = Console.WindowHeight / 2 - size.H / 2
			}, size);
			state = GameState.Run;
			speed = 300;
		}

		internal void Run()
		{
			Register_Snake();
			DropFood(GameObject.Food);
			DropFood(GameObject.SuperFood);
			model.MyBoard.IsSuperPower = true;
			view.Draw(model.MyBoard);
			superFoodCounter = rnd.Next(20, 40);
			Loop();
		}
		private void Loop()
		{
			Position np, tail;
			do
			{
				System.Threading.Thread.Sleep(speed);
				#region Billentyűzet kezelés
				if (Console.KeyAvailable)
				{
					switch (Console.ReadKey(true).Key)
					{
						case ConsoleKey.Escape:
							state = GameState.Exit;
							break;
						case ConsoleKey.UpArrow:
							if (model.MySnake.Dir != Direction.Down)
							{
								model.MySnake.Dir = Direction.Up;
							}
							break;
						case ConsoleKey.DownArrow:
							if (model.MySnake.Dir != Direction.Up)
							{
								model.MySnake.Dir = Direction.Down;
							}
							break;
						case ConsoleKey.LeftArrow:
							if (model.MySnake.Dir != Direction.Right)
							{
								model.MySnake.Dir = Direction.Left;
							}
							break;
						case ConsoleKey.RightArrow:
							if (model.MySnake.Dir != Direction.Left)
							{
								model.MySnake.Dir = Direction.Right;
							}
							break;
						default:
							break;
					}
				}
				#endregion

				np = NextPosition();
				switch (model.MyBoard.Map[np.X, np.Y])
				{
					case GameObject.Free:
						SnakeMove(np);
						break;
					case GameObject.Wall2:
						if (model.MySnake.IsSuperPower)
						{
							SnakeMove(np);
							model.MySnake.IsSuperPower = false;
						}
						else
						{
							state = GameState.Wall;
						}
						break;
					case GameObject.Wall:
						state = GameState.Wall;
						break;
					case GameObject.Food:
						model.MySnake.Grown();
						SnakeMove(np);
						DropFood(GameObject.Food);
						speed -= 10;
						model.MySnake.Score += 50;
						break;
					case GameObject.SuperFood:
						SnakeMove(np);
						model.MySnake.IsSuperPower = true;
						model.MyBoard.IsSuperPower = false;
						break;
					case GameObject.Snake:
						state = GameState.Bite;
						break;
					default:
						break;
				}
				SuperFoodManager();
				view.Status(model.MySnake.Score, speed);
			} while (state == GameState.Run);
			ProcessExit();
		}

		private void SuperFoodManager()
		{
			if (!model.MySnake.IsSuperPower && !model.MyBoard.IsSuperPower)
			{
				if (superFoodCounter == 0)
				{
					DropFood(GameObject.SuperFood);
					model.MyBoard.IsSuperPower = true;
					superFoodCounter = rnd.Next(20, 40);
				}
				else
				{
					superFoodCounter--;
				}
			}
		}
		private void SnakeMove(Position np)
		{
			//elmentjük a kígyó végét
			Position tail = model.MySnake.Body[model.MySnake.Body.Length - 1];
			//átmozgatjuk a kígyót
			model.MySnake.MoveManager(np);
			//kirajzoljuk + regisztráljuk az új helyen
			view.Draw(model.MySnake);
			model.MyBoard.Map[np.X, np.Y] = GameObject.Snake;
			//töröljük + regisztráljuk a régi helyen
			view.Draw(tail, GameObject.Free);
			model.MyBoard.Map[tail.X, tail.Y] = GameObject.Free;
		}
		private Position NextPosition()
		{
			switch (model.MySnake.Dir)
			{
				case Direction.Up:
					return new Position()
					{
						X = model.MySnake.Body[0].X,
						Y = model.MySnake.Body[0].Y - 1
					};
				case Direction.Right:
					return new Position()
					{
						X = model.MySnake.Body[0].X + 1,
						Y = model.MySnake.Body[0].Y
					};
				case Direction.Down:
					return new Position()
					{
						X = model.MySnake.Body[0].X,
						Y = model.MySnake.Body[0].Y + 1
					};
				case Direction.Left:
					return new Position()
					{
						X = model.MySnake.Body[0].X - 1,
						Y = model.MySnake.Body[0].Y
					};
				default:
					return new Position()
					{
						X = model.MySnake.Body[0].X,
						Y = model.MySnake.Body[0].Y
					};
			}
		}
		private void ProcessExit()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			switch (state)
			{
				case GameState.Wall:
					view.Message("Játék vége! Falnak ütköztél.");
					break;
				case GameState.Bite:
					view.Message("Játék vége! A kígyó magába harapott.");
					break;
				case GameState.Win:
					break;
				case GameState.Exit:
					view.Message("Játék vége! Kiléptél.");
					break;
				default:
					break;
			}
		}
		private void DropFood(GameObject gO)
		{
			int x, y;
			do
			{
				x = rnd.Next(1, model.MyBoard.Size.W - 1);
				y = rnd.Next(1, model.MyBoard.Size.H - 1);
			} while (model.MyBoard.Map[x, y] != GameObject.Free);
			model.MyBoard.Map[x, y] = gO;
			view.Draw(new Position() { X = x, Y = y }, gO);
		}
		private void Register_Snake()
		{
			//snake regisztrálása a Map-be	
			model.MyBoard.Map[model.MySnake.Body[0].X, model.MySnake.Body[0].Y] = GameObject.Snake;
		}
	}
}
