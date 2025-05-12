using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_A
{
	internal class Board
	{
		static Random rnd = new Random();
		public Size Size { get; private set; }
		public GameObject[,] Map { get; set; }
		public int FruitCount { get; set; }
		public int PointCount { get; set; }
		public Board(Size _size)
		{
			Size = _size;
			Map = new GameObject[_size.W, _size.H];
			CreateMap(3);
			FruitCount = 5;
			CreateFruits();
			PointCounter();
		}

		private void CreateFruits()
		{
			int x, y;
			for (int i = 0; i < FruitCount; i++)
			{
				do
				{
					x = rnd.Next(1, Size.W - 1);
					y = rnd.Next(1, Size.H - 1);
				} while (Map[x, y] != GameObject.Point);
				Map[x, y] = GameObject.Fruit;
			}
		}
		public void CreateMap(int n)
		{
			#region Külső fal
			FrameMaker(Size.W, Size.H, 0, 0, false);
			#endregion

			#region Belső fal
			for (int i = 1; i <= n; i++)
			{
				FrameMaker(Size.W - i * 4, Size.H - i * 4, i * 2, i * 2, true);
			}

			#endregion
		}
		private void FrameMaker(int w, int h, int offX, int offY, bool gateway)
		{
			for (int y = 0; y < h; y++)
			{
				for (int x = 0; x < w; x++)
				{
					if (x == 0 || x == w - 1 || y == 0 || y == h - 1)
					{
						if (gateway && (x != w / 2 && y != h / 2))
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
		public void PointCounter()
		{
			PointCount = 0;
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
	}
}
