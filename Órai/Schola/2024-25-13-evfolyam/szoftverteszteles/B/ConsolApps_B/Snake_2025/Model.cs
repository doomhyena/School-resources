using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2025
{
	internal class Model
	{
		static Random rnd = new Random();
		public Map Map { get; set; }
		public Snake Snake { get; set; }
		public Position FP { get; set; }

		public Model(Size size)
		{
			Map = new Map(size);
			Snake = new Snake(new Position()
			{
				X = rnd.Next(2, size.Width - 2),
				Y = rnd.Next(2, size.Height - 2)
			},
			new Direction[] { Direction.Up, Direction.Down, Direction.Left, Direction.Right }[rnd.Next(4)]
			);

		}

		internal void DropFood()
		{
			do
			{
				FP = new Position() { X = rnd.Next(1, Map.Size.Width - 1), Y = rnd.Next(Map.Size.Height - 1) };
			} while (Map.Data[FP.X, FP.Y] != MapObject.Empty);
			Map.Data[FP.X, FP.Y] = MapObject.Food;
		}
	}
}
