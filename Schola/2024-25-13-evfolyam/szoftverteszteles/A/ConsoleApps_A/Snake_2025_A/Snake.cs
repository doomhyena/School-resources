using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2025_A
{
	class Snake
	{
		public Position[] Body { get; set; }
		public Position Tail { get; set; }
		public Direction Dir { get; set; }
		private Position[] temp;

		public Snake(Position _head, Direction _dir)
		{
			Body = new Position[] { _head };
			Dir = _dir;
			Tail = _head;
		}
		public void Move(Position _head)
		{
			Tail = Body.Last();
			for (int i = Body.Length - 1; i > 0; i--)
			{
				Body[i ] = Body[i-1];
			}
			Body[0] = _head;
		}
		public Position NextStep()
		{
			Position result = new Position();
			switch (Dir)
			{
				case Direction.Up:
					result = new Position() { X = Body[0].X, Y = Body[0].Y - 1 };
					break;
				case Direction.Right:
					result = new Position() { X = Body[0].X + 1, Y = Body[0].Y };
					break;
				case Direction.Down:
					result = new Position() { X = Body[0].X, Y = Body[0].Y + 1 };
					break;
				case Direction.Left:
					result = new Position() { X = Body[0].X - 1, Y = Body[0].Y };
					break;
				default:
					result = new Position();
					break;
			}
			return result;
		}
		public void Grown()
		{
			temp = new Position[Body.Length + 1];
			Array.Copy(Body, 0, temp, 0, Body.Length);
			Body = temp;
			Body[Body.Length - 1] = Body[Body.Length - 2];
		}
	}
}
