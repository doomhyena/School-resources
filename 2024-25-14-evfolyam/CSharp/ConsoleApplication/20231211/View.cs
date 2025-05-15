using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231211
{
			internal class View
			{
						public Position offset;

						public View(Position _offset)
						{
									offset = _offset;
									Console.CursorVisible = false;
						}
						public void Draw_Frame(Size size)
						{
									int x = 0, y = 0;

									for (x = 0; x < size.width; x++)
									{
												Draw(x, y, '█');
												Draw(x, y + size.height - 1, '█');
									}
									x = 0;
									for (y = 0; y < size.height; y++)
									{
												Draw(x, y, '█');
												Draw(x + size.width - 1, y, '█');
									}
						}

						public void Draw(Position p, char c)
						{
									Console.SetCursorPosition(offset.x + p.x, offset.y + p.y);
									Console.Write(c);
						}
						public void Draw(int x, int y, char c)
						{
									Console.SetCursorPosition(offset.x + x, offset.y + y);
									Console.Write(c);
						}
						public void Draw(MyCursor mc)
						{
									//Console.SetCursorPosition(offset.x + mc.position.x, offset.y + mc.position.y);
									//Console.ForegroundColor = mc.color;
									//Console.Write(mc.face);
									Console.ForegroundColor = mc.color;
									Draw(mc.position,mc.face);
						}
			}
}
