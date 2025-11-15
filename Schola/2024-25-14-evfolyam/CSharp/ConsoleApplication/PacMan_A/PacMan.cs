using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_A
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

		public void ChangeDirection(Direction _dir)
		{
			Dir = _dir;
		}

		public void Move(Position _nP)
		{
			if (speed==0)
			{
				TempPos = Pos;
				Pos = _nP;
				UpdateRequired = true;
				speed = speed0;
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
