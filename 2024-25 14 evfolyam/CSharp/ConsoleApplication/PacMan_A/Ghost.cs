using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_A
{
	class Ghost : IActor
	{
		static Random rnd = new Random();
		private static Direction[] directions = new Direction[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left };
		private int speed, speed0, stepCounter;
		public Position Pos { get; private set; }
		public Position TempPos { get; private set; }
		public Direction Dir { get; private set; }
		public GameObject MyType { get; private set; }
		public bool UpdateRequired { get; set; }
		private Board board;

		public Ghost(Position _pos, int _speed, Board _board)
		{
			board = _board;
			Pos = TempPos = _pos;
			speed = speed0 = _speed;
			MyType = GameObject.Ghost;
			UpdateRequired = false;
			stepCounter = rnd.Next(5, 12);
		}

		public void ChangeDirection(Direction _dir)
		{
			Dir = _dir;
		}

		public void Move(Position _nP)
		{
			if (speed == 0)
			{
				if (stepCounter > 0)
				{
					TempPos = Pos;
					Pos = _nP;
					UpdateRequired = true;
					speed = speed0;
					stepCounter--;
				}
				else
				{
					Direction dir;
					Position nP;
					do
					{
						dir = directions[rnd.Next(directions.Length)];
						nP = NextStep(dir);
					} while (board.Map[nP.X, nP.Y] == GameObject.Wall);
					ChangeDirection(dir);
					stepCounter = rnd.Next(5, 12);
				}
			}
			else
			{
				speed--;
			}
		}

		public Position NextStep(Direction _dir)
		{
			switch (_dir)
			{
				case Direction.Up:
					return new Position() { X = Pos.X, Y = Pos.Y - 1 };
				case Direction.Right:
					return new Position() { X = Pos.X + 1, Y = Pos.Y };
				case Direction.Down:
					return new Position() { X = Pos.X, Y = Pos.Y + 1 };
				case Direction.Left:
					return new Position() { X = Pos.X - 1, Y = Pos.Y };
				default:
					return new Position();
			}
		}
	}
}
