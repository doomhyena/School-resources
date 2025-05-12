using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2024_B
{
			class View
			{
						private Position offset;
						private Size size;
						private readonly Dictionary<GameObject, char> goChar = new Dictionary<GameObject, char>() {
						{GameObject.Free,' ' },
						{ GameObject.Wall,'█'}, { GameObject.Wall2,'█'},
						{ GameObject.Food,'#'},	{ GameObject.SuperFood,'☻'},
						{ GameObject.Snake,'█'}
						};
						private readonly Dictionary<GameObject, ConsoleColor> goColor = new Dictionary<GameObject, ConsoleColor>() {
						{GameObject.Free,ConsoleColor.Black },
						{ GameObject.Wall,ConsoleColor.White}, { GameObject.Wall2,ConsoleColor.Gray},
						{ GameObject.Food,ConsoleColor.Green},{ GameObject.SuperFood,ConsoleColor.DarkRed},
						{ GameObject.Snake,ConsoleColor.Yellow}
						};
						public View(Position _offset, Size _size)
						{
									Console.CursorVisible = false;
									offset = _offset;
									size = _size;
						}

						internal void Draw(Snake mySnake)
						{
									Console.SetCursorPosition(mySnake.Body[0].X + offset.X, mySnake.Body[0].Y + offset.Y);
									Console.BackgroundColor = goColor[GameObject.Free];
									Console.ForegroundColor = mySnake.IsSuperFood?goColor[GameObject.SuperFood]: goColor[GameObject.Snake];
									Console.Write(goChar[GameObject.Snake]);
						}
						internal void Draw(Position p, GameObject gO)
						{
									Console.SetCursorPosition(p.X + offset.X, p.Y + offset.Y);
									Console.BackgroundColor = goColor[GameObject.Free];
									Console.ForegroundColor = goColor[gO];
									Console.Write(goChar[gO]);
						}
						public void Draw(Board _board)
						{
									Console.BackgroundColor = goColor[GameObject.Free];
									for (int y = 0; y < _board.Size.H; y++)
									{
												for (int x = 0; x < _board.Size.W; x++)
												{
															Console.SetCursorPosition(offset.X + x, offset.Y + y);
															Console.ForegroundColor = goColor[_board.Map[x, y]];
															Console.Write(goChar[_board.Map[x, y]]);
												}
									}
						}
						public void Message(String msg)
						{
									int x = size.W / 2 - msg.Length / 2;
									int y = size.H / 2;
									Console.SetCursorPosition(x + offset.X, y + offset.Y);
									Console.BackgroundColor = goColor[GameObject.Free];
									Console.ForegroundColor = ConsoleColor.Red;
									Console.Write(msg);
						}
						internal void Status(int score, int speed)
						{
									int x = 0;
									int y = 0;
									Console.SetCursorPosition(x + offset.X, y + offset.Y);
									Console.BackgroundColor = goColor[GameObject.Wall];
									Console.ForegroundColor = ConsoleColor.Blue;
									Console.Write($"Score: {score,5}");
									y = size.H - 1;
									Console.SetCursorPosition(x + offset.X, y + offset.Y);
									Console.BackgroundColor = goColor[GameObject.Wall];
									Console.ForegroundColor = ConsoleColor.Blue;
									Console.Write($"Speed: {speed,3}");
						}
			}
}
