using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2024_B
{
			public class Model
			{
						public Board MyBoard { get; set; }
						public Snake MySnake { get; set; }

						public Model(Size _size)
						{
									MyBoard = new Board(_size);
									MySnake = new Snake(new Position() { X = _size.W / 4, Y = _size.H / 4 });
						}
			}
}
