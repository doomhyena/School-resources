using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgTetelek
{
			internal class Program
			{
						static Random rnd = new Random();
						static void Main(string[] args)
						{
									#region Összegzés
									int[] t = new int[100];
									for (int i = 0; i < t.Length; i++)
									{
												t[i] = rnd.Next(101);
									}
									int osszeg = Osszegzes(t);
									Console.WriteLine($"A t tömb összege= {osszeg}");
									#endregion

									#region Megszámolás
									//int[] t = new int[100];
									//for (int i = 0; i < t.Length; i++)
									//{
									//			t[i] = rnd.Next(101);
									//}
									//// hány olyan elem van, amelyik nagyobb mint 50
									//int szamlalo = 0;
									//for (int i = 0; i < t.Length; i++)
									//{
									//			if (t[i]>50)
									//			{
									//						szamlalo++;
									//			}
									//}
									//Console.WriteLine($"A t tömbben {szamlalo} db 50-nél nagyobb elem van.");
									#endregion

									#region Eldöntés
									//int[] t = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
									//int keresett = 100;
									//int i = 0;
									//while (i<t.Length && t[i]!=keresett)
									//{
									//			i++;
									//}
									//if (i==t.Length)
									//{
									//			Console.WriteLine("A keresett elem nincs benne a t tömbben.");
									//}
									//else
									//{
									//			Console.WriteLine("A keresett elem benne van a t tömbben.");
									//}
									#endregion

									#region Kiválasztás
									//int[] t = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
									//int keresett = 8;
									//int i = 0;
									//while (i < t.Length && t[i] != keresett)
									//{
									//			i++;
									//}
									//Console.WriteLine($"A keresett elem indexe: {i}");									
									#endregion

									#region Másolás
									int[] a = new int[100];
									for (int i = 0; i < a.Length; i++)
									{
												a[i] = rnd.Next(101);
									}
									double[] b = new double[a.Length];
									for (int i = 0; i < a.Length; i++)
									{
												b[i] = a[i] * 1.27;
									}

									#endregion


									//-------------------------------------
									Console.WriteLine("---- VÉGE ----");
									Console.ReadKey();
						}

						static int Osszegzes(int[] a)
						{
									int result = 0;
									for (int i = 0; i < a.Length; i++)
									{
												result += a[i];
									}
									return result;
						}
			}
}
