using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN_B
{
			public struct Position
			{
						public int X { get; set; }
						public int Y { get; set; }
			}
			public struct Size
			{
						public int W { get; set; }
						public int H { get; set; }
			}
			public enum Direction { Up, Right, Down, Left }
			public enum GameObject { Point ,Free, Wall, Fruit, PacMan, Ghost }
			public enum GameState { Game, Collision, Menu, Exit,
		Win,
		Escape
	}
}
