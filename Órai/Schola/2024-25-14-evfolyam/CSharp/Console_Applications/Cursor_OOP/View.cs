using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursor_OOP
{
			class View
			{
						private Position offset;
						public View(Position _offset)
						{
									offset = _offset;
									Console.CursorVisible = false;
						}
						public void DrawFrame(Size size)
						{
									for (int y = 0; y < size.height; y++)
									{
												for (int x = 0; x < size.width; x++)
												{
															if (y == 0 || x == 0 || y == size.height - 1 || x == size.width - 1)
															{
																		Draw(x, y, '█');
															}
												}
									}
						}

						internal void Draw(MyCursor myCursor)
						{
									Console.ForegroundColor = myCursor.color;
									Draw(myCursor.position.x,myCursor.position.y,myCursor.face);
						}

						public void Draw(int x, int y, char v)
						{
									Console.SetCursorPosition(offset.x + x, offset.y + y);
									Console.Write(v);
						}
			}
}
