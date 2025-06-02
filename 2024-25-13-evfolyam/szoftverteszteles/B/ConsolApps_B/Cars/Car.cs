using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
	class Car
	{
		ConsoleColor[] colors = new ConsoleColor[] { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.DarkBlue, ConsoleColor.DarkGreen, ConsoleColor.DarkGray, ConsoleColor.DarkMagenta, ConsoleColor.DarkYellow, ConsoleColor.Cyan, ConsoleColor.Gray, ConsoleColor.Magenta, ConsoleColor.White };
		static Random rnd = new Random();
		public Position Position { get; set; }
		public Position Last { get; set; }
		public int Speed { get; set; }
		public int SpeedOrig { get; private set; }
		public bool TakeOver { get; set; }

		public ConsoleColor Color { get; set; }

		public Car(int _lane)
		{
			Position = Last = new Position() { X = 0, Y = _lane };
			SpeedOrig = Speed = rnd.Next(3, 10);
			Color = colors[rnd.Next(colors.Length)];
		}
	}
}
