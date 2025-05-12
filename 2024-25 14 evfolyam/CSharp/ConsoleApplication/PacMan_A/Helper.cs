using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_A
{
	public struct Size
	{
		public int W { get; set; }
		public int H { get; set; }

	}

	public struct Position
	{
		public int X { get; set; }
		public int Y { get; set; }
	}

	public enum Direction { Up, Right, Down, Left }
	public enum GameObject { Point, Free, Wall, Fruit, Ghost, PacMan }
	public enum GameState { Menu, Game, Win, Exit, Kill,
		Escape
	}
}
