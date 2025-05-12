using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_2025_A
{
	class Controller
	{
		View view;
		Model model;
		GameState gameState;
		int speed;
		int score;

		public Controller(Size size)
		{
			model = new Model(size);
			view = new View(size);
			speed = 200;
		}

		internal void Run()
		{
			Init();
			Start();
		}

		private void Start()
		{
			Position nP;
			do
			{
				KeyboardCheck();
				nP = model.Snake.NextStep();
				switch (model.Map.Matrix[nP.X, nP.Y])
				{
					case GameObject.Empty:
						model.Snake.Move(nP);
						view.Draw(nP, GameObject.Snake); // kígyó fejének új helyen kirajzolása
						model.Map.Registration(nP, GameObject.Snake); // kígyó fejének beregisztrálása
						view.Draw(model.Snake.Tail, GameObject.Empty); // kígyó végének törlése a consolról
						model.Map.Registration(model.Snake.Tail, GameObject.Empty); //kígyó végének törlése a MAP-ből
						break;
					case GameObject.Wall:
						gameState = GameState.Collision;
						break;
					case GameObject.Snake:
						gameState = GameState.SelfBite;
						break;
					case GameObject.Snack:
						model.Map.Registration(nP, GameObject.Empty);
						model.Snake.Grown();

						model.Snake.Move(nP);
						view.Draw(nP, GameObject.Snake); // kígyó fejének új helyen kirajzolása
						model.Map.Registration(nP, GameObject.Snake); // kígyó fejének beregisztrálása
						view.Draw(model.Snake.Tail, GameObject.Empty); // kígyó végének törlése a consolról
						model.Map.Registration(model.Snake.Tail, GameObject.Empty); //kígyó végének törlése a MAP-ből

						model.DropSnack();
						view.Draw(model.Snack, GameObject.Snack);
						speed -= 10;
						score += 50;
						view.WriteScore(score);
						break;
					default:
						break;
				}
				System.Threading.Thread.Sleep(speed);
			} while (gameState == GameState.Run);
			ProcessEnd();
		}

		private void ProcessEnd()
		{
			string msg = string.Empty;
			switch (gameState)
			{
				case GameState.Escape:
					msg = "Játék vége! Kiléptél.";
					break;
				case GameState.Collision:
					msg = "Játék vége! Nekimentél a falnak.";
					break;
				case GameState.SelfBite:
					msg = "Játék vége! A kígyó önmagába harapott.";
					break;
				case GameState.Win:
					msg = "Nyertél!";
					break;
				default:
					break;
			}
			view.Message(msg);
		}

		private void KeyboardCheck()
		{
			if (Console.KeyAvailable)
			{
				switch (Console.ReadKey(true).Key)
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
					case ConsoleKey.RightArrow:
						if (model.Snake.Dir != Direction.Left)
						{
							model.Snake.Dir = Direction.Right;
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
					default:
						break;
				}
			}
		}

		private void Init()
		{
			model.Map.CreateWalls();
			model.Map.Registration(model.Snake.Body[0], GameObject.Snake);
			model.DropSnack();
			view.Draw(model.Map);
			gameState = GameState.Run;
			score = 0;
			view.WriteScore(score);
		}
	}
}
