using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2024_B
{
			class GameManager
			{
						private static Random rnd = new Random();
						private Size size;
						private Model model;
						private View view;
						private GameState state;
						private Position nextStep, temp;
						private int speed, superFoodCounter;

						public GameManager(Size size)
						{
									this.size = size;
									model = new Model(size);
									view = new View(new Position()
									{
												X = Console.WindowWidth / 2 - size.W / 2,
												Y = Console.WindowHeight / 2 - size.H / 2
									}, size);
									state = GameState.Run;
									speed = 300;
						}

						internal void Start()
						{
									view.Draw(model.MyBoard);
									model.MyBoard.Set(model.MySnake.Body[0], GameObject.Snake);
									view.Draw(model.MySnake);
									DropObject(GameObject.Food);
									DropObject(GameObject.SuperFood);
									model.MyBoard.IsSuperFood = true;
									Loop();
						}

						private void Loop()
						{
									superFoodCounter = rnd.Next(20, 40);
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
																		case ConsoleKey.RightArrow:
																					if (model.MySnake.Dir != Direction.Left)
																					{
																								model.MySnake.Dir = Direction.Right;
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
																		default:
																					break;
															}
												}
												#endregion
												#region Billentyűzet puffer ürítés
												while (Console.KeyAvailable)
												{
															Console.ReadKey(true);
												}
												#endregion
												#region Mozgatás /Ütközés vizsgálat
												nextStep = NextStep();
												switch (model.MyBoard.Map[nextStep.X, nextStep.Y])
												{
															case GameObject.Free:
																		//simán lép
																		SnakeMove();
																		break;
															case GameObject.Wall:
																		state = GameState.Wall;
																		break;
															case GameObject.Wall2:
																		if (model.MySnake.IsSuperFood)
																		{
																					model.MySnake.IsSuperFood = false;
																					SnakeMove();
																		}
																		else
																		{
																					state = GameState.Wall;
																		}
																		break;
															case GameObject.Snake:
																		state = GameState.Bite;
																		break;
															case GameObject.Food:
																		speed -= 10;
																		model.MySnake.Score += 50;
																		// növekszik és lép
																		model.MySnake.Grown();
																		//régi food leszedése
																		SnakeMove();
																		//új food dobás
																		DropObject(GameObject.Food);
																		break;
															case GameObject.SuperFood:
																		model.MySnake.IsSuperFood = true;
																		model.MyBoard.IsSuperFood = false;
																		SnakeMove();
																		break;
															default:
																		break;
												}
												#endregion
												SuperFoodStatus();
												view.Status(model.MySnake.Score, speed);
									} while (state == GameState.Run);
									ProcessExit();
						}

						private void SnakeMove()
						{
									temp = model.MySnake.Body[model.MySnake.Body.Length - 1];
									model.MySnake.MoveManager(nextStep);
									view.Draw(model.MySnake);
									model.MyBoard.Set(model.MySnake.Body[0], GameObject.Snake);
									view.Draw(temp, GameObject.Free);
									model.MyBoard.Set(temp, GameObject.Free);
						}

						private void SuperFoodStatus()
						{
									if (!model.MySnake.IsSuperFood && !model.MyBoard.IsSuperFood)
									{
												if (superFoodCounter == 0)
												{
															DropObject(GameObject.SuperFood);
															model.MyBoard.IsSuperFood = true;
															superFoodCounter = rnd.Next(20, 40);
												}
												else
												{
															superFoodCounter--;
												}
									}

						}

						private Position NextStep()
						{
									Position result = new Position();
									switch (model.MySnake.Dir)
									{
												case Direction.Up:
															result = new Position() { X = model.MySnake.Body[0].X, Y = model.MySnake.Body[0].Y - 1 };
															break;
												case Direction.Right:
															result = new Position() { X = model.MySnake.Body[0].X + 1, Y = model.MySnake.Body[0].Y };
															break;
												case Direction.Down:
															result = new Position() { X = model.MySnake.Body[0].X, Y = model.MySnake.Body[0].Y + 1 };
															break;
												case Direction.Left:
															result = new Position() { X = model.MySnake.Body[0].X - 1, Y = model.MySnake.Body[0].Y };
															break;
												default:
															break;
									}
									return result;
						}

						private void ProcessExit()
						{
									switch (state)
									{
												case GameState.Wall:
															view.Message("Játék vége, falnak ütköztél!");
															break;
												case GameState.Bite:
															view.Message("Játék vége, a kígyó önmagába harapott!");
															break;
												case GameState.Win:
															view.Message("Játék vége, nyertél!");
															break;
												case GameState.Exit:
															view.Message("Játék vége, kiléptél!");
															break;
												default:
															break;
									}
									Console.ReadKey();
						}

						private void DropObject(GameObject gameObject)
						{
									Position p;
									do
									{
												p = new Position() { X = rnd.Next(1, size.W), Y = rnd.Next(1, size.H) };
									} while (model.MyBoard.Map[p.X, p.Y] != GameObject.Free);
									//----------------------------------------
									model.MyBoard.Set(p, gameObject);
									view.Draw(p, gameObject);
						}
			}
}
