using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Cursor
{
	internal class Program
	{
		#region Deklarációk
		static Dictionary<MapObject, char> faces = new Dictionary<MapObject, char>()
		{
			{MapObject.Empty,' ' },
			{MapObject.Wall,'█' },
			{MapObject.Cursor,'☻' },
			{MapObject.InnerWall,'█'},
			{ MapObject.Food,'$'}
		};
		static Dictionary<MapObject, ConsoleColor> colors = new Dictionary<MapObject, ConsoleColor>()
		{
			{MapObject.Empty,ConsoleColor.Black },
			{MapObject.Wall,ConsoleColor.White },
			{MapObject.InnerWall,ConsoleColor.White },
			{MapObject.Food,ConsoleColor.Green }
		};
		static Random rnd = new Random();
		static Direction[] dirs;
		static bool exit = false;
		static Size playGround;
		static Position offset;
		//static Cursor cursor;
		static List<Cursor> cursors;
		static MapObject[,] map;
		#endregion

		static void Main(string[] args)
		{
			// console inicializálás
			Console.CursorVisible = false;
			Console.OutputEncoding = Encoding.UTF8;

			#region változók + objektumok init
			cursors = new List<Cursor>();
			playGround = new Size() { Width = 60, Height = 20 };
			map = new MapObject[playGround.Width, playGround.Height];
			offset = new Position()
			{
				X = Console.WindowWidth / 2 - playGround.Width / 2,
				Y = Console.WindowHeight / 2 - playGround.Height / 2
			};
			Position next;
			//InnerWalls();
			HomeWork();
			CreateWalls();
			CreateFoods(50);
			#endregion


			#region cursorok létrehozása listában
			for (int i = 0; i < 50; i++)
			{
				cursors.Add(new Cursor(
				'█', // Face
				FindFreePosition()
				//new Position()
				//{
				//	X = rnd.Next(1, playGround.Width-1),
				//	Y = rnd.Next(1, playGround.Height-1)
				//}    // 			
				));
			}
			#endregion

			// algoritmus
			DrawMap();
			do
			{
				foreach (Cursor c in cursors)
				{
					next = NextStep(c);

					switch (map[next.X, next.Y])
					{
						case MapObject.Empty:
							c.Move(next);
							break;
						case MapObject.Wall:
							c.ChangeDirection();
							break;
						case MapObject.Cursor:
							c.Move(next);
							break;
						case MapObject.Food:
							c.Food = true;
							map[next.X, next.Y] = MapObject.Empty;
							c.Move(next);
							break;
						case MapObject.InnerWall:
							if (c.Food)
							{
								map[next.X, next.Y] = MapObject.Empty;
								c.Move(next);
								c.Food = false;
							}
							else
							{
								c.ChangeDirection();
							}
							break;
						default:
							break;
					}

					if (c.IsMove)
					{
						Draw(c); // kurzor kirajzolása
						Draw(c.PrevPos.X, c.PrevPos.Y, ' ', ConsoleColor.Black); // törlés 
					}
				}

				System.Threading.Thread.Sleep(5); // várakoztatás
			} while (!exit);
		}

		private static void HomeWork()
		{
			int n = 2;
			CreateInnerBorcder(4);
		}

		private static void CreateInnerBorcder(int v)
		{
			try
			{
				for (int i = 1; i <= v; i++)
				{
					for (int y = 2 * i; y < playGround.Height - 2 * i; y++)
					{
						for (int x = 2 * i; x < playGround.Width - 2 * i; x++)
						{
							if (y == 2 * i || x == 2 * i || y == playGround.Height - 1 - 2 * i || x == playGround.Width - 1 - 2 * i)
							{
								map[x, y] = MapObject.Wall;
							}
						}
					}
				}
			}
			catch (IndexOutOfRangeException)
			{

				
			}
			catch (Exception)
			{
				
			}


		}

		private static void CreateFoods(int counter)
		{
			Position p;
			for (int i = 0; i < counter; i++)
			{
				p = FindFreePosition();
				map[p.X, p.Y] = MapObject.Food;
			}
		}

		private static Position FindFreePosition()
		{
			Position result = new Position();
			do
			{
				result = new Position()
				{
					X = rnd.Next(1, playGround.Width - 1),
					Y = rnd.Next(1, playGround.Height - 1)
				};
			} while (map[result.X, result.Y] != MapObject.Empty);

			return result;
		}

		private static Position NextStep(Cursor c)
		{
			Position result = new Position();
			switch (c.Dir)
			{
				case Direction.Up:
					result = new Position()
					{
						X = c.Position.X,
						Y = c.Position.Y - 1
					};
					break;
				case Direction.Down:
					result = new Position()
					{
						X = c.Position.X,
						Y = c.Position.Y + 1
					};
					break;
				case Direction.Left:
					result = new Position()
					{
						X = c.Position.X - 1,
						Y = c.Position.Y
					};
					break;
				case Direction.Right:
					result = new Position()
					{
						X = c.Position.X + 1,
						Y = c.Position.Y
					};
					break;
				default:
					break;
			}
			return result;
		}


		#region View
		private static void DrawMap()
		{
			for (int y = 0; y < playGround.Height; y++)
			{
				for (int x = 0; x < playGround.Width; x++)
				{
					Draw(x, y, faces[map[x, y]], colors[map[x, y]]);
				}
			}
		}
		private static void CreateWalls()
		{
			for (int y = 0; y < playGround.Height; y++)
			{
				for (int x = 0; x < playGround.Width; x++)
				{
					if (y == 0 || x == 0 || y == playGround.Height - 1 || x == playGround.Width - 1)
					{
						map[x, y] = MapObject.Wall;
					}
				}
			}
		}
		private static void InnerWalls()
		{
			for (int y = 0; y < playGround.Height; y++)
			{
				for (int x = 0; x < playGround.Width; x++)
				{
					if ((y == 0 || x == 0 || y == playGround.Height / 2 || x == playGround.Width / 2) &&
						x != playGround.Width / 4 &&
						x != playGround.Width / 4 * 3 &&
						y != playGround.Height / 4 &&
						y != playGround.Height / 4 * 3)
					{
						map[x, y] = MapObject.InnerWall;
					}
				}
			}
		}
		private static void Draw(int x, int y, char face, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.SetCursorPosition(x + offset.X, y + offset.Y);
			Console.Write(face);
		}
		private static void Draw(Cursor c)
		{
			Draw(c.Position.X, c.Position.Y, c.Face, c.Color);
		}

		#endregion
	}
	public enum Direction { Up, Down, Left, Right }
	public struct Size
	{
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
	}
	public enum MapObject { Empty, Wall, Cursor, InnerWall, Food }
}

