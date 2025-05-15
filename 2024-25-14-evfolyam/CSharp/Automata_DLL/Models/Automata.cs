using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_DLL.Models
{
	public class Automata
	{
		public Dictionary<Product, int> Products { get; private set; }
		//private Dictionary<Product, int> products;
		private Wallet mainWallet, insertedCoins;
		public Wallet ChangeCoins { get; set; }
		public Automata(Dictionary<Product, int> products, Wallet wallet)
		{
			this.Products = products;
			this.mainWallet = wallet;
			insertedCoins = new Wallet();
			ChangeCoins = new Wallet();
		}

		internal void Purchase()
		{
			/*
			 * - választéklista
			 * - pénzbedobás
			 * - választás
			 * - vásárlás
			 * - visszaadás
			 */
			ShowMenu();
			insertedCoins = Get_Coins();
			Product selectedProduct = SelectProduct();
			if (selectedProduct != null && insertedCoins.Sum >= selectedProduct.Price)
			{
				if (insertedCoins.Sum > selectedProduct.Price && IsMoneyBack(insertedCoins.Sum - selectedProduct.Price))
				{
					// kell visszaadni
					mainWallet.Add(insertedCoins);
					Wallet back = MoneyBack(insertedCoins.Sum - selectedProduct.Price);
					insertedCoins = new Wallet();
					Console.WriteLine(back);
				}
				else if (insertedCoins.Sum == selectedProduct.Price)
				{
					mainWallet.Add(insertedCoins);
					insertedCoins = new Wallet();
					Products[selectedProduct]--;
				}
			}
			;
		}
		private Wallet MoneyBack(decimal v)
		{
			Wallet result = new Wallet();
			do
			{
				if (v >= 200 && mainWallet._200 > 0)
				{
					v -= 200;
					mainWallet._200--;
					result._200++;
				}
				else if (v >= 100 && mainWallet._100 > 0)
				{
					v -= 100;
					mainWallet._100--;
					result._100++;
				}
				else if (v >= 50 && mainWallet._50 > 0)
				{
					v -= 50;
					mainWallet._50--;
					result._50++;
				}
				else if (v >= 20 && mainWallet._20 > 0)
				{
					v -= 20;
					mainWallet._20--;
					result._20++;
				}
				else if (v >= 10 && mainWallet._10 > 0)
				{
					v -= 10;
					mainWallet._10--;
					result._10++;
				}
				else if (v >= 5 && mainWallet._5 > 0)
				{
					v -= 5;
					mainWallet._5--;
					result._5++;
				}
			} while (v != 0);

			return result;
		}
		private bool IsMoneyBack(decimal v)
		{
			Wallet w = mainWallet;
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

			} while (v != 0 && change);
			return v == 0;
		}
		private Product SelectProduct()
		{
			Product result = null;
			int productID;
			Console.Write("A kiválasztott termék azonosítója: ");
			if (int.TryParse(Console.ReadLine(), out productID) && Products.Keys.Any(q => q.ID == productID))
			{
				result = Products.Keys.Single(q => q.ID == productID);
				Console.WriteLine($"Kiválasztott termék: {result.Name}");
			}
			Console.WriteLine("--------------------------------------------------------");
			return result;
		}
		private Wallet Get_Coins()
		{
			Wallet result = new Wallet();
			Console.WriteLine("Dobd be a kívánt termék árának megfelelő mennyiségű érmét:");
			Console.WriteLine("[5/10/20/50/100/200 Bedobás vége:0]");
			int coin = 0;
			do
			{
				Console.Write("Bedobott érme: ");
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
				if (coin != 0)
				{
					Console.WriteLine($"Eddig bedobott összeg: {result.Sum:C0}");
				}
			} while (coin != 0);
			Console.WriteLine("--------------------------------------------------------");
			return result;
		}
		private void ShowMenu()
		{
			Console.Clear();

			foreach (var p in Products.Where(q => q.Value > 0))
			{
				Console.WriteLine($"{p.Key.ID,3} {p.Key.Name,-30} {p.Key.Price,5:C0}");
			}
			Console.WriteLine("--------------------------------------------------------");
		}
		public List<Product> API_GetProducts(ProductType _type)
		{
			return Products.Where(q => q.Key.Type == _type && q.Value > 0).Select(q => q.Key).ToList();
		}
		public bool API_Purchase(Product p, Wallet insertedCoins)
		{
			if (insertedCoins.Sum >= p.Price)
			{
				if (insertedCoins.Sum > p.Price && IsMoneyBack(insertedCoins.Sum - p.Price))
				{
					// kell visszaadni
					mainWallet.Add(insertedCoins);
					ChangeCoins = MoneyBack(insertedCoins.Sum - p.Price);
					System.Diagnostics.Debug.WriteLine(ChangeCoins);
				}
				else if (insertedCoins.Sum == p.Price)
				{
					mainWallet.Add(insertedCoins);
				}
				Products[p]--;
				insertedCoins = new Wallet();
				return true;
			}
			return false;
		}
		public Wallet Get_MainWallet()
		{
			return mainWallet;
		}
	}
}
