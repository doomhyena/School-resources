using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN_B
{
	class Board
	{
		private static Random rnd = new Random();
		public Size Size { get; private set; }
		public GameObject[,] Map { get; set; }
		public int PointCount { get; set; }
		public int FruitCount { get; set; }
		public Board(Size _size)
		{
			FruitCount = 4;
			Size = _size;
			Map = new GameObject[Size.W, Size.H];
			CreateMap();
			CreateFruits(FruitCount);
			CountPoints();
		}

		private void CountPoints()
		{
			for (int y = 0; y < Size.H; y++)
			{
				for (int x = 0; x < Size.W; x++)
				{
					if (Map[x, y] == GameObject.Point)
					{
						PointCount++;
					}
				}
			}			
		}
		private void CreateMap()
		{
			#region Külső fal
			CreateFrame(Size.W, Size.H, 0, 0, false);
			#endregion

			#region Belső falak
			for (int i = 0; i < 3; i++)
			{
				CreateFrame(Size.W - (4 + i * 4), Size.H - (4 + i * 4), 2 + (i * 2), 2 + (i * 2), true);
			}
			#endregion
		}
		private void CreateFrame(int w, int h, int offX, int offY, bool gateway)
		{
			for (int y = 0; y < h; y++)
			{
				for (int x = 0; x < w; x++)
				{
					if (y == 0 || x == 0 || y == h - 1 || x == w - 1)
					{
						if (gateway && (y != h / 2 && x != w / 2))
						{
							Map[x + offX, y + offY] = GameObject.Wall;
						}
						else if (!gateway)
						{
							Map[x + offX, y + offY] = GameObject.Wall;
						}
					}
				}
			}
		}
		public void CreateFruits(int fruitCount)
		{
			int x, y;
			for (int i = 0; i < fruitCount; i++)
			{
				do
				{
					x = rnd.Next(1, Size.W - 1);
					y = rnd.Next(1, Size.H - 1);
				} while (Map[x, y] != GameObject.Point);
				Map[x, y] = GameObject.Fruit;
			}
		}
	}
}
