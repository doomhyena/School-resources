using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursor_OOP
{
			class Control
			{
						private bool end;
						private Model model;
						private View view;

						public Control()
						{
									end = false;
									model = new Model();
									view = new View(new Position() { x = 5, y = 2 });
						}
						public void Start()
						{
									view.DrawFrame(model.myBoard.size);
									//view.Draw(model.myCursor);
									foreach (var item in model.myCursors)
									{
												view.Draw(item);
									}
									Loop();
						}
						private void Loop()
						{
									Position nextPosition;

									do
									{
												if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
												{
															end = true;
												}
												else
												{
															foreach (var myCursor in model.myCursors)
															{
																		if (myCursor.stepCounter > 0)
																		{
																					myCursor.stepCounter--;
																		}
																		else
																		{
																					myCursor.ChangeDirection();
																					myCursor.ResetStepCounter();
																		}

																		nextPosition = myCursor.NextPosition();
																		if (model.myBoard.Check(nextPosition))
																		{
																					myCursor.Move(nextPosition);
																					view.Draw(myCursor);
																					view.Draw(myCursor.tempPos.x, myCursor.tempPos.y, ' ');
																					
																		}
																		else
																		{
																					myCursor.ChangeDirection();
																		} 
															}
															System.Threading.Thread.Sleep(10);
												}
									} while (!end);
						}
			}
}
