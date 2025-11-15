using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2025
{
	internal class Map
	{
		public MapObject[,] Data { get; set; }
		public Size Size { get; set; }

		public Map(Size size)
		{
			Size = size;
			Data = new MapObject[size.Width, size.Height];
			CreateWall();
		}

		private void CreateWall()
		{
			for (int y = 0; y < Size.Height; y++)
			{
				for (int x = 0; x < Size.Width; x++)
				{
					if (y == 0 || x == 0 || y == Size.Height - 1 || x == Size.Width - 1)
					{
						Data[x, y] = MapObject.Wall;
					}
				}
			}
		}
	}
}
