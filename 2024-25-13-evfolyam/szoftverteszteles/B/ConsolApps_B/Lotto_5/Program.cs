using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto_5
{
	internal class Program
	{
		static Random rnd = new Random();
		static void Main(string[] args)
		{
			int[] eredmenyek = new int[5];
			int[] szelveny = new int[] { 13, 21, 42, 75, 88 };
			int[] kihuzott;
			int eredmeny;
			TombToOutput(szelveny);
			Console.Write("Hány szelvénnyel teszteljünk: ");
			if (int.TryParse(Console.ReadLine(), out int db))
			{
				for (int i = 0; i < db; i++)
				{
					kihuzott = SzelvenyGenerator();
					eredmeny = Talalatok(kihuzott, szelveny) - 1;
					if (eredmeny >= 0)
					{
						eredmenyek[eredmeny]++;
					}

					//switch (Talalatok(kihuzott, szelveny))
					//{
					//	case 1:
					//		eredmenyek[0]++;
					//		break;
					//	case 2:
					//		eredmenyek[1]++;
					//		break;
					//	case 3:
					//		eredmenyek[2]++;
					//		break;
					//	case 4:
					//		eredmenyek[3]++;
					//		break;
					//	case 5:
					//		eredmenyek[4]++;
					//		break;
					//	default:
					//		break;
					//}					
				}

				//eredmény kiíratása
				for (int i = 0; i < 5; i++)
				{
					Console.WriteLine($"{i + 1} találatos: {eredmenyek[i]}");
				}
			}
			//---------------------------------------------
			Console.WriteLine("- VÉGE -");
			Console.ReadKey();
		}

		private static int Talalatok(int[] kihuzott, int[] szelveny)
		{
			int result = 0;
			for (int i = 0; i < szelveny.Length; i++)
			{
				if (kihuzott.Contains(szelveny[i]))
				{
					result++;
				}
			}
			return result;
		}
		private static int[] SzelvenyGenerator()
		{
			int[] result = new int[5];
			for (int i = 0; i < result.Length; i++)
			{
				result[i] = SzamGenerator(result);
			}
			return result;
		}
		private static int SzamGenerator(int[] szelveny)
		{
			int result = 0;
			do
			{
				result = rnd.Next(1, 91);
			} while (szelveny.Contains(result));
			return result;
		}
		//private static bool BenneVan(int[] t, int v)
		//{
		//	//int i = 0;
		//	//bool talalat = false;
		//	//do
		//	//{
		//	//	if (t[i] == v)
		//	//	{
		//	//		talalat = true;
		//	//	}
		//	//	else
		//	//	{
		//	//		i++;
		//	//	}
		//	//} while (i < t.Length && !talalat);

		//	//return i < t.Length;
		//	return t.Contains(v);
		//}
		private static void TombToOutput(int[] t)
		{
			for (int i = 0; i < t.Length; i++)
			{
				System.Diagnostics.Debug.Write(t[i]);
				if (i < t.Length - 1)
				{
					System.Diagnostics.Debug.Write(",");
				}

			}
			System.Diagnostics.Debug.WriteLine("");
		}
	}
}
