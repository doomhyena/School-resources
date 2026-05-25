using System;
using System.Linq;

namespace Snake_2025
{
	internal class Snake
	{
		public Position[] Body { get; set; }
		public Direction Dir { get; set; }
		public Position Tail { get; set; }
		public int Score { get; set; }
		Position[] temp;

		public Snake(Position head, Direction dir)
		{
			Body = new Position[] { head };
		}

		public void Move(Position newHead)
		{
			Tail = Body.Last();

			for (int i = Body.Length - 1; i > 0; i--)
			{
				Body[i] = Body[i - 1];
			}
			Body[0] = newHead;
		}

		public void Grown()
		{
			temp = new Position[Body.Length + 1];
			Array.Copy(Body, 0, temp, 0, Body.Length);
			Body = temp;
			Body[Body.Length - 1] = Body[Body.Length - 2];

		}

		public Position NextStep()
		{
			Position result = new Position();
			switch (Dir)
			{
				case Direction.Up:
					result = new Position() { X = Body[0].X, Y = Body[0].Y - 1 };
					break;
				case Direction.Down:
					result = new Position() { X = Body[0].X, Y = Body[0].Y + 1 };
					break;
				case Direction.Left:
					result = new Position() { X = Body[0].X - 1, Y = Body[0].Y };
					break;
				case Direction.Right:
					result = new Position() { X = Body[0].X + 1, Y = Body[0].Y };
					break;
				default:
					break;
			}
			return result;
		}
	}
}