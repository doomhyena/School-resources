using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2024_B
{
			public class Snake
			{
						public int Score { get; set; }
						public Position[] Body { get; private set; }
						public Direction Dir { get; set; }
						public bool IsSuperFood { get; set; }
						private int stepCounter;
						private Position[] newBody;

						public Snake(Position p)
						{
									Body = new Position[] { p };
									Dir = Direction.Right;
									IsSuperFood = false;
						}

						public void MoveManager(Position newHead)
						{
									Move(newHead);
									StepCounterManager();
						}
						private void Move(Position newHead)
						{
									for (int i = Body.Length - 1; i > 0; i--)
									{
												Body[i] = Body[i - 1];
									}
									Body[0] = newHead;
						}

						private void StepCounterManager()
						{
									if (IsSuperFood)
									{
												if (stepCounter >= 10)
												{
															IsSuperFood = false;
															stepCounter = 0;
												}
												else
												{
															stepCounter++;
												}
									}
						}

						public void Grown()
						{
									newBody = new Position[Body.Length + 1];
									for (int i = 0; i < Body.Length; i++)
									{
												newBody[i] = Body[i];
									}
									newBody[newBody.Length - 1] = Body[Body.Length - 1];
									Body = newBody;
						}

			}
}
