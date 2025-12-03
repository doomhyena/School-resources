using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_2025_B
{
	class Program
	{
		static void Main(string[] args)
		{
			/* - Választék lekérdezése          * 
          * - Választás
          * - Apró beadás
          * - Visszaadás kérdése
          * - Termék kiadása
          */
			Dictionary<Product, int> storage = new Dictionary<Product, int>() {
				{new Product("Presszó kávé",180), 100},
				{new Product("Hosszú kávé",150), 200},
				{new Product("Capuchino",600), 150},
				{new Product("Ásványvíz",200), 100},
				{new Product("Hell energia ital",350), 100}
			};
			Console.Clear();

			Automata a = new Automata(AutomataType.Drink, storage, new Wallet(0, 0, 0, 0, 0, 0));
			do
			{
				Console.Clear() ;
				//Console.WriteLine($"Cassa: {a.cassa}");
				DisplaySelection(a.PriceList());
				int selected = GetSelection(a);
				Wallet inserted = GetCoins();
				Product product = a.Purchase(selected, inserted);
				if (product != null)
				{
					Console.WriteLine($"Sikeres vásárlás! Visszajáró:{a.CoinBox}");
				}
				else
				{
					Console.WriteLine($"Sikertelen vásárlás! Visszajáró:{a.CoinBox}");
				}
				Console.ReadKey();
			} while (true);
			//---------------------
			
		}

		private static Wallet GetCoins()
		{
			Wallet result;
			Console.WriteLine("------------------------------------");
			Console.Write("Sorold fel a bedobott érmék darabszámát vesszővel elválasztva:");
			result = new Wallet(Console.ReadLine());
			Console.WriteLine($"A bedobott érmék összege: {result.Sum}");
			return result;
		}

		private static int GetSelection(Automata a)
		{
			Console.Write("Add meg a kiválasztott termék azonosítóját:");
			bool success = false;
			int result;
			do
			{
				int.TryParse(Console.ReadLine(), out result);
				if (a.ProductIsExits(result))
				{
					success = true;
				}
			} while (!success);
			return result;
		}

		private static void DisplaySelection(List<Product> products)
		{
			Console.WriteLine("------------SELECTION---------------");
			foreach (var p in products)
			{
				Console.WriteLine($"{p.ID} {p.Name,-20} {p.Price,4} Ft");
			}
			Console.WriteLine("------------------------------------");
		}
	}
}
