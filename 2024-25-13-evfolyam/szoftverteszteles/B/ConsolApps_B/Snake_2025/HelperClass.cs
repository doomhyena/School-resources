using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2025
{
	public enum Direction { Up, Down, Left, Right }
	public enum MapObject { Empty, Wall, Snake, Food }
	public enum GameState { Run, Escape, Collision, SelfBite }
	public struct Size
	{
		public Size(int w, int h)
		{
			Width = w;
			Height = h;
		}
		public int Width { get; set; }
		public int Height { get; set; }
	}
	public struct Position
	{
		public int X { get; set; }
		public int Y { get; set; }

		public override bool Equals(object obj)
		{
			if (obj.GetType() == typeof(Position))
			{
				Position p = (Position)obj;
				return p.X == X && p.Y == Y;
			}
			return false;
		}
		public override string ToString()
		{
			return $"X={X,3} | Y={Y,3}";
		}
	}
}
