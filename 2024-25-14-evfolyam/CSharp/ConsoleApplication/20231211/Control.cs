using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231211
{
			internal class Control
			{
						private Model model;
						private View view;
						private bool end;

						public Control()
						{
									model = new Model();
									view = new View(new Position() { x = 5, y = 2 });
									end = false;
						}
						internal void Start()
						{
									view.Draw_Frame(model.size);
									view.Draw(model.myCursor);
									Loop();
						}

						private void Loop()
						{
									do
									{
												if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
												{
															end = true;
												}
												else
												{
															if (model.myCursor.step > 0)
															{
																		model.myCursor.step--; //lépésszámláló csökkentése
															}
															else
															{ // irányváltás + lépésszámláló resetelése
																		model.myCursor.ChangeDirection();
																		model.myCursor.ResetStep();
																		}
															if (Check(model.myCursor.position, model.myCursor.direction))
															{
																		model.myCursor.Move();
																		view.Draw(model.myCursor);
																		view.Draw(model.myCursor.positionT, ' ');
																		System.Threading.Thread.Sleep(50);
															}
															else
															{
																		model.myCursor.ChangeDirection();
															}
												}

									} while (!end);
						}
						private bool Check(Position cursor, Direction direction)
						{
									Position p = model.myCursor.NextPosition(cursor, direction);
									return (p.x > 0 && p.x < model.size.width - 1 && p.y > 0 && p.y < model.size.height - 1);
						}
					
			}
}
