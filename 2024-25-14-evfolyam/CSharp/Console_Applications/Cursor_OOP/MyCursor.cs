using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursor_OOP
{
			class MyCursor
			{
						private static Random rnd = new Random();
						private Direction[] dirs = new Direction[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left };
						public Position position, tempPos;
						public Direction direction;
						public char face;
						public ConsoleColor color;
						public int stepCounter;
						private int speed, speed0;

						public MyCursor(char _face = '☻', ConsoleColor _color = ConsoleColor.Green, int _speed = 10)
						{
									position = new Position() { x = 1, y = 1 };
									direction = Direction.Right;
									face = _face;
									color = _color;
									speed = speed0 = _speed;
									ResetStepCounter();
						}

						public void Move(Position nP)
						{
									if (speed==0)
									{
												tempPos = position;
												position = nP;
												speed = speed0;
									}
									else
									{
												speed--;
									}
						}

						public void ChangeDirection()
						{
									direction = dirs[rnd.Next(dirs.Length)];
						}

						public void ResetStepCounter()
						{
									stepCounter = rnd.Next(3, 20);
						}
						public Position NextPosition()
						{
									switch (direction)
									{
												case Direction.Up:
															return new Position() { x = position.x, y = position.y - 1 };

												case Direction.Right:
															return new Position() { x = position.x + 1, y = position.y };

												case Direction.Down:
															return new Position() { x = position.x, y = position.y + 1 };

												case Direction.Left:
															return new Position() { x = position.x - 1, y = position.y };

												default:
															return position;

									}
						}
			}
}
