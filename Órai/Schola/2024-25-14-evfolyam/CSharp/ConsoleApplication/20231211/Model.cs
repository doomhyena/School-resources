using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231211
{
			internal class Model
			{
						public MyCursor myCursor;
						public Size size;
						public static readonly Direction[] dirs=new Direction[] { Direction.Left, Direction.Right, Direction.Up, Direction.Down };
						public Model()
						{
									myCursor = new MyCursor();
									size = new Size() { width = 40, height = 20 };								
						}
			}
			public struct Position
			{
						public int x;
						public int y;
			}
			public struct Size
			{
						public int width;
						public int height;
			}
			public enum Direction { Up, Right, Down, Left }
}
