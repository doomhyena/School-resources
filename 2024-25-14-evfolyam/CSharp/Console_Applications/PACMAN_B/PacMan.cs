using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN_B
{
	class PacMan : IActor
	{
		
		private int speed, speed0;
		public Position Pos { get; private set; }
		public Position TempPos { get; private set; }
		public Direction Dir { get; private set; }
		public GameObject MyType { get; private set; }
		public int Score { get; set; }
		public bool UpdateRequired { get; set; }
		public PacMan(Position _pos, int _speed)
		{
			Pos = TempPos = _pos;			
			speed = speed0 = _speed;
			MyType = GameObject.PacMan;
		}
		public void Move(Position _nP)
		{
			if (speed == 0)
			{
				TempPos = Pos;
				Pos = _nP;
				speed = speed0;
				UpdateRequired = true;
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
