using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2024_B
{
			public class Board
			{
						public Size Size { get; }
						public GameObject[,] Map { get; set; }
						public bool IsSuperFood { get; set; }
						public Board(Size _size)
						{
									Size = _size;
									Map = new GameObject[Size.W, Size.H];
									IsSuperFood = false;
									CreateWall();
						}

						private void CreateWall()
						{
									#region Külső fal
									for (int y = 0; y < Size.H; y++)
									{
												for (int x = 0; x < Size.W; x++)
												{
															if (x == 0 || y == 0 || x == Size.W - 1 || y == Size.H - 1)
															{
																		Map[x, y] = GameObject.Wall;
															}
												}
									}
									#endregion

									#region Belső fal
									for (int x = 1; x < Size.W - 1; x++)
									{
												if (x != Size.W / 4 && x != Size.W / 4 * 3)
												{
															Map[x, Size.H / 2] = GameObject.Wall2;
												}
									}
									for (int y = 1; y < Size.H - 1; y++)
									{
												if (y != Size.H / 4 && y != Size.H / 4 * 3)
												{
															Map[Size.W/2, y] = GameObject.Wall2;
												}
									}
									#endregion
						}

						public void Set(Position p, GameObject go)
						{
									Map[p.X, p.Y] = go;
						}
			}
}
