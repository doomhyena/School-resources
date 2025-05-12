using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _20231211
{
			internal class MyCursor
			{
						private static Random rnd = new Random();
						public Position position;
						public Position positionT;
						public Direction direction;
						public ConsoleColor color;
						public char face;
						public int step;

						public MyCursor()
						{
									position = new Position() { x = 1, y = 1 };
									direction = Direction.Right;
									color = ConsoleColor.Green;
									face = '☻';
									ResetStep();
						}

						public void Move()
						{
									positionT = position;
									position = NextPosition(position, direction);
						}
						public void ChangeDirection()
						{
									direction = Model.dirs[rnd.Next(Model.dirs.Length)];
						}
						public Position NextPosition(Position cursor, Direction direction)
						{
									Position p = new Position();
									switch (direction)
									{
												case Direction.Up:
															p = new Position() { x = cursor.x, y = cursor.y - 1 };
															break;
												case Direction.Right:
															p = new Position() { x = cursor.x + 1, y = cursor.y };
															break;
												case Direction.Down:
															p = new Position() { x = cursor.x, y = cursor.y + 1 };
															break;
												case Direction.Left:
															p = new Position() { x = cursor.x - 1, y = cursor.y };
															break;
												default:
															break;
									}
									return p;
						}
						public void ResetStep()
						{
									step = rnd.Next(3, 8);
						}
			}
}
