using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN_B
{
	class Ghost : IActor
	{
		static Random rnd = new Random();
		private int speed, speed0, stepCounter;
		public Position Pos { get; private set; }
		public Position TempPos { get; private set; }
		public Direction Dir { get; private set; }
		public GameObject MyType { get; private set; }
		public bool UpdateRequired { get; set; }
		private Board board;
		public Ghost(Position _pos, int _speed, Board _board)
		{
			MyType = GameObject.Ghost;
			Pos = TempPos = _pos;
			board = _board;
			speed = speed0 = _speed;
			stepCounter = rnd.Next(3, 8);
		}
		public void Move(Position _nP)
		{
			if (speed == 0)
			{
				if (stepCounter > 0)
				{
					TempPos = Pos;
					Pos = _nP;
					speed = speed0;
					UpdateRequired = true;
					stepCounter--;
				}
				else
				{
					stepCounter = rnd.Next(3, 8);
					Dir = GameManager.GetRandomDirection(this, board.Map);
				}
			}
			else
			{
				speed--;
				UpdateRequired = false;
			}
		}
		public Position NextPosition(Direction _dir)
		{
			Position result = new Position();
			switch (_dir)
			{
				case Direction.Up:
					result = new Position() { X = Pos.X, Y = Pos.Y - 1 };
					break;
				case Direction.Right:
					result = new Position() { X = Pos.X + 1, Y = Pos.Y };
					break;
				case Direction.Down:
					result = new Position() { X = Pos.X, Y = Pos.Y + 1 };
					break;
				case Direction.Left:
					result = new Position() { X = Pos.X - 1, Y = Pos.Y };
					break;
				default:
					break;
			}
			return result;
		}
		public void ChangeDirection(Direction _dir)
		{
			Dir = _dir;
		}
	}
}
