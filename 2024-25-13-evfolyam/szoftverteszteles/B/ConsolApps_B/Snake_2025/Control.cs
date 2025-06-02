using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2025
{
	internal class Control
	{
		Model model;
		View view;
		GameState gameState;
		int speed;
		Position nP;


		public Control(Size size)
		{
			model = new Model(size);
			view = new View(
				new Position()
				{
					X = Console.WindowWidth / 2 - size.Width / 2,
					Y = Console.WindowHeight / 2 - size.Height / 2
				}, 
				size);
		}

		internal void Run()
		{
			Init();
			StartGame();
		}

		private void StartGame()
		{
			do
			{
				KeyHandler();
				nP = model.Snake.NextStep();
				switch (model.Map.Data[nP.X, nP.Y])
				{
					case MapObject.Empty:
						model.Snake.Move(nP);
						// fej rajzolás + regisztrálás
						view.Draw(nP, MapObject.Snake);
						MapObjectReg(nP, MapObject.Snake);
						// farok törlés + regisztrálás
						view.Draw(model.Snake.Tail, MapObject.Empty);
						System.Diagnostics.Debug.WriteLine($"{model.Snake.Tail} : {model.FP}");
						MapObjectReg(model.Snake.Tail, MapObject.Empty);
						break;
					case MapObject.Wall:
						gameState = GameState.Collision;
						break;
					case MapObject.Snake:
						gameState = GameState.SelfBite;
						break;
					case MapObject.Food:
						/*
						 * megevett kaja kiregisztrálása
						 * sebesség nő
						 * kígyó nő
						 * kígyó mozog
						 * új kaja
						 * 
						 */
						if (speed >= 5)
						{
							speed -= 5;
						}
						model.Map.Data[nP.X, nP.Y] = MapObject.Empty;
						model.Snake.Grown();
						model.Snake.Move(nP);
						// fej rajzolás + regisztrálás
						view.Draw(nP, MapObject.Snake);
						MapObjectReg(nP, MapObject.Snake);
						// farok törlés + regisztrálás
						view.Draw(model.Snake.Tail, MapObject.Empty);
						MapObjectReg(model.Snake.Tail, MapObject.Empty);

						model.DropFood();
						view.Draw(model.FP, MapObject.Food);

						model.Snake.Score += 50;
						view.Score(model.Snake.Score);
						break;
					default:
						break;
				}
				System.Threading.Thread.Sleep(speed);
			} while (gameState == GameState.Run);
			ExitProcess();
			NewGame();
		}

		private void NewGame()
		{
			bool newGame=view.NewGame();
			if (newGame)
			{
				Init();
				StartGame();
			}
		}

		private void ExitProcess()
		{
			string msg = string.Empty;
			switch (gameState)
			{
				case GameState.Escape:
					msg = "Játék vége! Kiléptél!";
					break;
				case GameState.Collision:
					msg = "Játék vége! Nekimentél a falnak!";
					break;
				case GameState.SelfBite:
					msg = "Játék vége! A kígyó önmagába harapott!";
					break;
				default:
					break;
			}
			view.EndProcess(msg);
		}

		private void KeyHandler()
		{
			if (Console.KeyAvailable)
			{
				switch (Console.ReadKey(false).Key)
				{
					case ConsoleKey.Escape:
						gameState = GameState.Escape;
						break;
					case ConsoleKey.UpArrow:
						if (model.Snake.Dir != Direction.Down)
						{
							model.Snake.Dir = Direction.Up;
						}
						break;
					case ConsoleKey.DownArrow:
						if (model.Snake.Dir != Direction.Up)
						{
							model.Snake.Dir = Direction.Down;
						}
						break;
					case ConsoleKey.LeftArrow:
						if (model.Snake.Dir != Direction.Right)
						{
							model.Snake.Dir = Direction.Left;
						}
						break;
					case ConsoleKey.RightArrow:
						if (model.Snake.Dir != Direction.Left)
						{
							model.Snake.Dir = Direction.Right;
						}
						break;
					default:
						break;
				}
			}
		}

		private void MapObjectReg(Position nP, MapObject mo)
		{
			model.Map.Data[nP.X, nP.Y] = mo;
		}

		private void Init()
		{
			model = new Model(model.Map.Size);
			model.Map.Data[model.Snake.Body[0].X, model.Snake.Body[0].Y] = MapObject.Snake;
			view.Draw(model.Map);
			view.Score(model.Snake.Score);

			gameState = GameState.Run;
			speed = 200;
			model.DropFood();
			view.Draw(model.FP, MapObject.Food);
		}
	}
}
