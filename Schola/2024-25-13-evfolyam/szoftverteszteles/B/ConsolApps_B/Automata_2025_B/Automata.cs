using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automata_2025_B
{
	public class Automata : IAutomata
	{
		private Dictionary<Product, int> storage;
		public AutomataType AutomataType { get; }
		public bool IsFree { get; set; }
		public Wallet CoinBox { get; set; }
		
		private Wallet cassa;
		public Automata(AutomataType _type, Dictionary<Product, int> _storage, Wallet _cassa)
		{
			AutomataType = _type;
			storage = _storage;
			this.cassa = _cassa;
			CoinBox = new Wallet();
			IsFree = true;
		}
		public List<Product> PriceList()
		{
			return storage
				.Where(s => s.Value > 0)
				.Select(s => s.Key)
				.ToList();
		}
		public bool ProductIsExits(int pID)
		{
			return storage.Any(s => s.Value > 0 && s.Key.ID == pID);
		}
		public Product Purchase(int selected, Wallet inserted)
		{
			bool result = false;

			CoinBox.Clear();
			//Product = null;			

			Product p = storage.Single(q => q.Key.ID == selected).Key;
			if (inserted.Sum == p.Price)
			{
				result = true;
			}
			else if (inserted.Sum > p.Price)
			{
				bool canChange = CanChange(inserted.Sum - p.Price);
				if (canChange)
				{
					Change(inserted.Sum - p.Price);
					result = true;
				}
				else
				{
					CoinBox = inserted;
				}
			}
			else
			{
				CoinBox = inserted;
			}

			//---------------------
			if (result)
			{
				storage[p]--;
				cassa.Add(inserted);
				return p;
				
			}

			return null;
		}
		private void Change(int v)
		{
			do
			{
				if (v >= 200 && cassa._200 > 0)
				{
					v -= 200;
					cassa._200--;
					CoinBox._200++;
				}
				else if (v >= 100 && cassa._100 > 0)
				{
					v -= 100;
					cassa._100--;
					CoinBox._100++;
				}
				else if (v >= 50 && cassa._50 > 0)
				{
					v -= 50;
					cassa._50--;
					CoinBox._50++;
				}
				else if (v >= 20 && cassa._20 > 0)
				{
					v -= 20;
					cassa._20--;
					CoinBox._20++;
				}
				else if (v >= 10 && cassa._10 > 0)
				{
					v -= 10;
					cassa._10--;
					CoinBox._10++;
				}
				else if (v >= 5 && cassa._5 > 0)
				{
					v -= 5;
					cassa._5--;
					CoinBox._5++;
				}
			} while (v > 0);
		}
		private bool CanChange(int v)
		{
			Wallet temp = cassa.Clone();
			bool change;
			do
			{
				change = false;
				if (v >= 200 && temp._200 > 0)
				{
					v -= 200;
					temp._200--;
					change = true;
				}
				else if (v >= 100 && temp._100 > 0)
				{
					v -= 100;
					temp._100--;
					change = true;
				}
				else if (v >= 50 && temp._50 > 0)
				{
					v -= 50;
					temp._50--;
					change = true;
				}
				else if (v >= 20 && temp._20 > 0)
				{
					v -= 20;
					temp._20--;
					change = true;
				}
				else if (v >= 10 && temp._10 > 0)
				{
					v -= 10;
					temp._10--;
					change = true;
				}
				else if (v >= 5 && temp._5 > 0)
				{
					v -= 5;
					temp._5--;
					change = true;
				}
			} while (v > 0 && change);
			return v == 0;
		}
	}

	public enum AutomataType { Food, Drink }
}
