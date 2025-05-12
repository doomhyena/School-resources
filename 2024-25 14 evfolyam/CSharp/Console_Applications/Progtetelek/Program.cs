using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progtetelek
{
			class Program
			{
						static Random rnd = new Random();
						static int r;
						static void Main(string[] args)
						{
									int[] a;
									int l, m, n;
									r = 6;
									#region Összegzés
									a = new int[] { 5, 67, 23, 56, 33, 88, 73, 12, 8, 42 };
									int osszeg = Osszegzes(a);
									
									
									
									//int s = 0;
									//for (int i = 0; i < a.Length; i++)
									//{
									//			s += a[i];
									//}
									//Console.Write($"Tömb elemei: ");
									//for (int i = 0; i < a.Length; i++)
									//{
									//			Console.Write(a[i]);
									//			if (i < 9)
									//			{
									//						Console.Write(",");
									//			}

									//}
									//Console.WriteLine();
									//Console.WriteLine($"Eredmény={s}");
									#endregion

									#region Megszámolás
									//a = new int[100];
									//for (int i = 0; i < a.Length; i++)
									//{
									//			a[i] = rnd.Next(101);
									//}
									//50 - nél kisebb számok száma
									//int darab = 0;
									//for (int i = 0; i < a.Length; i++)
									//{
									//			if (a[i] < 50)
									//			{
									//						darab++;
									//			}
									//}
									//Console.WriteLine($"Az a tömbben {darab} db 50-nél kisebb szám van.");
									#endregion

									#region Eldöntés
									//a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

									//int keresett = 1;
									//int i2 = 0;
									//while (i2 < a.Length && a[i2] != keresett)
									//{
									//			i2++;
									//}
									//if (i2 == a.Length)
									//{
									//			Console.WriteLine("A keresett elem nincs a tömbben.");
									//}
									//else
									//{
									//			Console.WriteLine("A keresett elem a tömbben van.");
									//}
									#endregion

									#region Kiválasztás
									//a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

									//int keresett = 5;
									//int i2 = 0;
									//while (i2 < a.Length && a[i2] != keresett)
									//{
									//			i2++;
									//}
									//Console.WriteLine($"A keresett elem indexe:{i2}");
									#endregion
									#region Keresés
									//a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

									//int keresett = 5;
									//int i2 = 0;
									//while (i2 < a.Length && a[i2] != keresett)
									//{
									//			i2++;
									//}
									//if (i2 == a.Length)
									//{
									//			Console.WriteLine("A keresett elem nincs a tömbben.");
									//}
									//else
									//{
									//			Console.WriteLine($"A keresett elem indexe:{i2}");
									//}
									#endregion

									#region Másolás
									//a = new int[] { 123, 64443, 324234, 7878, 23487 };
									//double[] b = new double[a.Length];
									//double afa = 1.27;
									//for (int i = 0; i < a.Length; i++)
									//{
									//			b[i] = a[i] * afa;
									//			;
									//}									
									#endregion

									#region Kiválogatás
									//a = new int[] { 43, 78, 183, 44, 57, 93, 2, 17 };
									//int[] b = new int[a.Length];
									//m = 0;
									//for (int i = 0; i < a.Length; i++)
									//{
									//			if (a[i]%2==0)
									//			{
									//						b[m++] = a[i];
									//			}
									//}
									#endregion
									#region MyRegion
									//for (int i = 0; i < length; i++)
									//{
									//			for (int j = 0; j < length; j++)
									//			{
									//						if (a[i]==b[j])
									//						{
									//									c[n++] = a[i];
									//						}
									//			}
									//}
									#endregion


									//--------------------------
									Console.WriteLine("--- VÉGE ---");
									Console.ReadKey();
						}
						static int Osszegzes(int[] tomb)
						{								
									r = 8;
									int result = 0;
									for (int i = 0; i < tomb.Length; i++)
									{
												result += tomb[i];
									}
									return result;
						}
			}
}
