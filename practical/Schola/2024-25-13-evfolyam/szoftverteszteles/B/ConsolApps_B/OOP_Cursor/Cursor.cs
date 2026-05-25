using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Cursor
{
	internal class Cursor
	{
		static ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.DarkBlue, ConsoleColor.DarkGreen, ConsoleColor.DarkCyan, ConsoleColor.DarkRed, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, ConsoleColor.Gray, ConsoleColor.DarkGray, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.White };
		static Random rnd = new Random();
		public char Face { get; }
		public Position Position { get; set; }
		public Position PrevPos { get; set; }
		public ConsoleColor Color { get; }
		public Direction Dir { get; set; }
		public bool Food { get; set; }
		public bool IsMove
		{
			get
			{
				return !Position.Equals(PrevPos);
			}
		}
		public int Speed { get; set; }
		int step, _speed;
		Direction[] dirs;
		

		public Cursor(char _face, Position _start)
		{
			ChangeDirection();
			Position = _start;
			Speed = rnd.Next(1, 10);
			_speed = Speed;
			PrevPos = Position;
			Color = colors[rnd.Next(colors.Length)];
			Face = _face;
			step = rnd.Next(2, 10);			
		}

		public void Move(Position _next)
		{
			if (Speed==0)
			{
				Speed = _speed;
				PrevPos = Position;
				if (step == 0)
				{
					ChangeDirection();
					step = rnd.Next(2, 10);
				}
				else
				{
					step--;
					Position = _next;					
				}
			}
			else
			{
				Speed--;
			}
		}

		public void ChangeDirection()
		{
			dirs = new Direction[] { Direction.Up, Direction.Down, Direction.Left, Direction.Right };
			Dir = dirs[rnd.Next(dirs.Length)];

			//-------------

		}
	}
}
