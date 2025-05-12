using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2024_A
{
			internal class Board
			{
						public Size Size { get; }
						public GameObject[,] Map { get; set; }
						public bool IsSuperPower { get; set; }

						public Board(Size _size)
						{
									Size = _size;
									Map = new GameObject[_size.W, _size.H];
									IsSuperPower = false;
									CreateWall();
									CreateWall2();
						}

						private void CreateWall2()
						{
									//vízszintes 			
									for (int x = 1; x < Size.W - 1; x++)
									{
												if (x != Size.W / 4 && x != Size.W / 4 * 3)
												{
															Map[x, Size.H / 2] = GameObject.Wall2;
												}
									}
									//függőleges
									for (int y = 1; y < Size.H - 1; y++)
									{
												if (y != Size.H / 4 && y != Size.H / 4 * 3)
												{
															Map[Size.W / 2, y] = GameObject.Wall2;
												}
									}
						}

						private void CreateWall()
						{
									for (int y = 0; y < Size.H; y++)
									{
												for (int x = 0; x < Size.W; x++)
												{
															if (x == 0 || x == Size.W - 1 || y == 0 || y == Size.H - 1)
															{
																		Map[x, y] = GameObject.Wall;
															}
												}
									}
						}
			}
}
