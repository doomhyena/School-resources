using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2025_A
{
	class Map
	{
		static Random rnd = new Random();
		public Size Size { get; private set; }
		public GameObject[,] Matrix { get; set; }

		public Map(Size _size)
		{
			Size = _size;
			Matrix = new GameObject[Size.Width, Size.Height];
		}

		public void CreateWalls()
		{
			for (int y = 0; y < Size.Height; y++)
			{
				for (int x = 0; x < Size.Width; x++)
				{
					if (x == 0 || y == 0 || x == Size.Width - 1 || y == Size.Height - 1)
					{
						Matrix[x, y] = GameObject.Wall;
					}
				}
			}
		}

		public void Registration(Position p, GameObject go)
		{
			Matrix[p.X, p.Y] = go;
		}

		
	}
}
