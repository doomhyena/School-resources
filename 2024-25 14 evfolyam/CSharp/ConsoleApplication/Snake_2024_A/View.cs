using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2024_A
{
			internal class View
			{
						private Size size;
						private Position offset;
						private readonly Dictionary<GameObject, char> goChar = new Dictionary<GameObject, char>() {
						{GameObject.Food,'#' },
						{ GameObject.Free,' '},
						{ GameObject.Snake,'█'},
						{ GameObject.Wall,'█'},
						{ GameObject.Wall2,'█'},
						{ GameObject.SuperFood,'☻'}
						};
						private readonly Dictionary<GameObject, ConsoleColor> goColor = new Dictionary<GameObject, ConsoleColor>() {
						{GameObject.Food,ConsoleColor.Green },
						{ GameObject.Free,ConsoleColor.Black},
						{ GameObject.Snake,ConsoleColor.Yellow},
						{ GameObject.Wall,ConsoleColor.White},
						{ GameObject.Wall2,ConsoleColor.Gray},
						{ GameObject.SuperFood,ConsoleColor.DarkRed}
						};
						public View(Position position, Size _size)
						{
									this.offset = position;
									Console.CursorVisible = false;
									size = _size;
						}

						public void Draw(Board board)
						{
									for (int y = 0; y < board.Size.H; y++)
									{
												for (int x = 0; x < board.Size.W; x++)
												{
															switch (board.Map[x, y])
															{
																		case GameObject.Wall:
																		case GameObject.Wall2:
																		case GameObject.Food:
																		case GameObject.Snake:
																					Console.SetCursorPosition(offset.X + x, offset.Y + y);
																					Console.ForegroundColor = goColor[board.Map[x, y]];
																					Console.Write(goChar[board.Map[x, y]]);
																					break;
																		default:
																					break;
															}
												}
									}
						}
						public void Draw(Snake mySnake)
						{
									Console.SetCursorPosition(offset.X + mySnake.Body[0].X, offset.Y + mySnake.Body[0].Y);
									Console.ForegroundColor = mySnake.IsSuperPower ? goColor[GameObject.SuperFood] : goColor[GameObject.Snake];
									Console.Write(goChar[GameObject.Snake]);
						}
						internal void Draw(Position np, GameObject gameObject)
						{
									Console.SetCursorPosition(offset.X + np.X, offset.Y + np.Y);
									Console.ForegroundColor = goColor[gameObject];
									Console.Write(goChar[gameObject]);
						}
						public void Message(String msg)
						{
									int x = size.W / 2 - msg.Length / 2;
									int y = size.H / 2;
									Console.SetCursorPosition(x + offset.X, y + offset.Y);
									Console.ForegroundColor = ConsoleColor.Red;
									Console.Write(msg);
						}
						public void Status(int score, int speed)
						{
									int x = 0;
									int y = size.H;

									Console.SetCursorPosition(x + offset.X, y + offset.Y);
									Console.ForegroundColor = ConsoleColor.Blue;
									Console.Write($"Score: {score,5}");

									string txt = $"Speed: {speed,3}";
									x = size.W - txt.Length;
									Console.SetCursorPosition(x + offset.X, y + offset.Y);
									Console.Write(txt);
						}
			}
}
