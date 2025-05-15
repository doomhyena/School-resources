using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;



namespace Automata_2024_B.Models
{
	public class Automata
	{
		public Dictionary<Product, int> products;
		public Wallet mainWallet, insertedCoins;
		public Wallet CoinBackBox { get; set; }
		public List<int> Queue { get; private set; }

		private Timer tmr_Queue;
		public Automata(Dictionary<Product, int> products, Wallet wallet)
		{
			this.products = products;
			this.mainWallet = wallet;
			this.CoinBackBox = new Wallet();
			insertedCoins = new Wallet();
			Queue = new List<int>();
			tmr_Queue = new Timer(2000);
			tmr_Queue.Elapsed += Tmr_Queue_Elapsed;
			tmr_Queue.Start();
		}

		private void Tmr_Queue_Elapsed(object sender, ElapsedEventArgs e)
		{
			tmr_Queue.Stop();

			tmr_Queue.Start();
		}

		internal bool Start()
		{
			System.Diagnostics.Debug.WriteLine(mainWallet);
			bool result = false;
			/*
			 * - választék megjelenítése
			 * - pénz bedobálása
			 * - termék kiválasztása
			 * - termék kód megadása
			 * - vásárlás realizálása
			 */
			Console.Clear();
			DisplayProducts();
			insertedCoins = GetCoins();
			Product p = GetProduct();
			if (p != null)
			{
				result = Purchase(p, insertedCoins);
				if (result)
				{
					Console.WriteLine($"Sikeres vásárlás.");
				}
				else
				{
					Console.WriteLine($"Sikertelen vásárlás.");
				}
				Console.WriteLine($"Visszajáró összeg:{CoinBackBox}");
				Console.ReadKey();
			}
			return result;
		}

		private bool Purchase(Product p, Wallet insertedCoins)
		{
			bool result = false;
			if (insertedCoins.Sum == p.Price)
			{
				// pont annyi pénz
				mainWallet.Add(insertedCoins);
				insertedCoins = new Wallet();
				products[p]--;
				result = true;
			}
			else if (insertedCoins.Sum > p.Price && IsPayBack(insertedCoins.Sum - p.Price))
			{
				// több a pénz de tudunk visszaadni
				mainWallet.Add(insertedCoins);
				CoinBackBox = PayBack(insertedCoins.Sum - p.Price);
				insertedCoins = new Wallet();
				products[p]--;
				result = true;
			}
			else if (insertedCoins.Sum > p.Price && !IsPayBack(insertedCoins.Sum - p.Price))
			{
				// több a pénz és nem tudunk visszaadni
				CoinBackBox = insertedCoins;
				insertedCoins = new Wallet();
				result = false;
			}
			else
			{
				// nem elég a pénz
				CoinBackBox = insertedCoins;
				insertedCoins = new Wallet();
				result = false;
			}
			return result;
		}

		private Wallet PayBack(decimal v)
		{
			Wallet result = new Wallet();
			do
			{
				if (v >= 200 && mainWallet._200 > 0)
				{
					v -= 200;
					result._200++;
					mainWallet._200--;
				}
				else if (v >= 100 && mainWallet._100 > 0)
				{
					v -= 100;
					result._100++;
					mainWallet._100--;
				}
				else if (v >= 50 && mainWallet._50 > 0)
				{
					v -= 50;
					result._50++;
					mainWallet._50--;
				}
				else if (v >= 20 && mainWallet._20 > 0)
				{
					v -= 20;
					result._20++;
					mainWallet._20--;
				}
				else if (v >= 10 && mainWallet._10 > 0)
				{
					v -= 10;
					result._10++;
					mainWallet._10--;
				}
				else if (v >= 5 && mainWallet._5 > 0)
				{
					v -= 5;
					result._5++;
					mainWallet._5--;
				}
			} while (v > 0);
			return result;
		}

		private bool IsPayBack(decimal v)
		{
			//70Ft

			Wallet w = new Wallet();
			w.Copy(mainWallet);
			w.Add(insertedCoins);
			bool change;
			do
			{
				change = false;
				if (v >= 200 && w._200 > 0)
				{
					v -= 200;
					w._200--;
					change = true;
				}
				else if (v >= 100 && w._100 > 0)
				{
					v -= 100;
					w._100--;
					change = true;
				}
				else if (v >= 50 && w._50 > 0)
				{
					v -= 50;
					w._50--;
					change = true;
				}
				else if (v >= 20 && w._20 > 0)
				{
					v -= 20;
					w._20--;
					change = true;
				}
				else if (v >= 10 && w._10 > 0)
				{
					v -= 10;
					w._10--;
					change = true;
				}
				else if (v >= 5 && w._5 > 0)
				{
					v -= 5;
					w._5--;
					change = true;
				}

			} while (v > 0 && change);

			return v == 0;
		}

		private Product GetProduct()
		{
			Product result = null;
			int productID;
			Console.Write("Add meg a kiválasztott termék azonosítóját: ");
			if (int.TryParse(Console.ReadLine(), out productID) &&
				products.Keys.Any(q => q.ID == productID))
			{
				result = products.Keys.Single(q => q.ID == productID);
			}
			if (result != null)
			{
				Console.WriteLine($"Kiválasztott termék: {result.Name}");
			}
			Console.WriteLine("--------------------------------------------------------");
			return result;
		}

		private Wallet GetCoins()
		{
			Wallet result = new Wallet();
			int coin = 0;
			do
			{
				Console.WriteLine($"Eddig bedobott összeg: {result.Sum:C0}");
				Console.Write("Dobj be egy érmét [5/10/20/50/100/200 vagy 0=kilép]: ");
				int.TryParse(Console.ReadLine(), out coin);
				switch (coin)
				{
					case 5:
						result._5++;
						break;
					case 10:
						result._10++;
						break;
					case 20:
						result._20++;
						break;
					case 50:
						result._50++;
						break;
					case 100:
						result._100++;
						break;
					case 200:
						result._200++;
						break;
					default:
						break;
				}
			} while (coin != 0);
			Console.WriteLine("--------------------------------------------------------");
			return result;
		}

		private void DisplayProducts()
		{
			foreach (var p in products.Where(q => q.Value > 0))
			{
				Console.WriteLine($"{p.Key.ID,2} {p.Key.Name,-30} {p.Key.Price:C0}");
			}
			Console.WriteLine("--------------------------------------------------------");
		}

		public List<Product> API_GetProductsList()
		{
			return products.Where(q => q.Value > 0).Select(q => q.Key).ToList();
		}

		public void API_InsertCoins(Wallet _insertedCoins)
		{
			insertedCoins = _insertedCoins;
		}

		public bool Get_Product(Product product)
		{
			return Purchase(product, insertedCoins);
		}

		public void API_UseAutomata(int _id, Action callBack)
		{
			Queue.Add(_id);
		}
	}

}
