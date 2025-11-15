using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2024_A
{
			internal class Snake
			{
						public int Score { get; set; }
						public Position[] Body { get; private set; }
						public Direction Dir { get; set; }
						public bool IsSuperPower { get; set; }
						private int superFoodStepCounter;

						public Snake(Position _p)
						{
									Body = new Position[] { _p };
									Dir = Direction.Right;
									IsSuperPower = false;
									superFoodStepCounter = 0;
						}
						public void MoveManager(Position p)
						{
									Move(p);
									SuperFoodManager();
						}
						private void Move(Position p)
						{
									for (int i = Body.Length - 1; i > 0; i--)
									{
												Body[i] = Body[i - 1];
									}
									Body[0] = p;
						}
						private void SuperFoodManager()
						{
									if (IsSuperPower)
									{
												if (superFoodStepCounter == 10)
												{
															IsSuperPower = false;
															superFoodStepCounter = 0;
												}
												else
												{
															superFoodStepCounter++;
												}
									}
						}
						public void Grown()
						{
									Position[] newBody = new Position[Body.Length + 1];
									for (int i = 0; i < Body.Length; i++)
									{
												newBody[i] = Body[i];
									}
									Body = newBody;
									Body[Body.Length - 1] = Body[Body.Length - 2];
						}
			}
}
