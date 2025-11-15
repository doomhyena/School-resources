using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursor_OOP
{
			class Model
			{
						private static Random rnd = new Random();
						//public MyCursor myCursor;
						public List<MyCursor> myCursors;
						public Board myBoard;

						public Model()
						{
									//myCursor = new MyCursor();
									myCursors = new List<MyCursor>();
									myBoard = new Board() { size = new Size() { width = 40, height = 20 } };
									MyCursorGenerator(7);
						}

						private void MyCursorGenerator(int v)
						{
									for (int i = 0; i < v; i++)
									{
												myCursors.Add(new MyCursor(_color: ConsoleColor.DarkRed, _speed: rnd.Next(13)));
									}
						}
			}

			public struct Position
			{
						public int x, y;
			}
			public struct Size
			{
						public int width, height;
			}
			public enum Direction { Up, Right, Down, Left }
}
