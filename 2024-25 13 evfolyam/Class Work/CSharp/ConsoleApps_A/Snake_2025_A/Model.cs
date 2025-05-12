using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2025_A
{
	class Model
	{
		static Random rnd = new Random();
		public Map Map { get; set; }
		public Snake Snake { get; set; }
		public Position Snack { get; set; }

		public Model(Size _size)
		{
			Map = new Map(_size);
			Snake = new Snake(new Position()
			{
				X = rnd.Next(2, _size.Width - 2),
				Y = rnd.Next(2, _size.Height - 2)
			},
			new Direction[] { Direction.Up, Direction.Right, Direction.Down, Direction.Left }[rnd.Next(4)]
			);
		}

		internal void DropSnack()
		{
			do
			{
				Snack = new Position(rnd.Next(1, Map.Size.Width), rnd.Next(1, Map.Size.Height));
			} while (Map.Matrix[Snack.X, Snack.Y] != GameObject.Empty);
			Map.Registration(Snack, GameObject.Snack);
		}

	}

	public struct Size
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public Size(int width, int height)
		{
			Width = width;
			Height = height;
		}
	}
	public struct Position
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Position(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
	public enum Direction { Up, Right, Down, Left }
	public enum GameState { Run, Escape, Collision, SelfBite, Win }
	public enum GameObject { Empty, Wall, Snake, Snack }
}
