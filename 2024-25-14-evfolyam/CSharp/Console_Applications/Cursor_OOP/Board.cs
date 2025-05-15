using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursor_OOP
{
			class Board
			{
						public Size size;
						public bool Check(Position nP)
						{
									if (nP.x > 0 && nP.x < size.width - 1 && nP.y > 0 && nP.y < size.height - 1)
									{
												return true;
									}
									return false;
						}
			}
}
