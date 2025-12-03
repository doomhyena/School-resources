using Automata_2024_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Uszoda_B.Models
{
	public class Person
	{
		static Random rnd = new Random();
		static int _id = 1;
		public int ID { get; }
		public decimal Cash { get; private set; }
		public Wallet Wallet { get; private set; }
		public Ticket Ticket { get; private set; }
		public int StorageID { get; private set; }
		public bool Hungry
		{
			get => hungry;
			set
			{
				hungry = value;
				if (value)
				{
					UseAutomata(ProductType.Food);
				}
			}
		}
		public bool Thirsty
		{
			get => thirsty;
			set
			{
				thirsty = value;
				if (value)
				{
					UseAutomata(ProductType.Drink);
				}
			}
		}
		public List<Product> MyProducts { get; private set; }

		Timer leaveTimer;
		Uszoda uszoda;
		private bool hungry;
		private bool thirsty;

		public Person(decimal cash, Wallet wallet)
		{
			ID = _id++;
			Cash = cash;
			Wallet = wallet;
			leaveTimer = new Timer();
			leaveTimer.Tick += LeaveTimer_Tick;
			MyProducts = new List<Product>();
		}
		private void UseAutomata(ProductType prodType)
		{
			List<Product> products = uszoda.MyAutomata.API_GetProductsList()
				.Where(q => q.Type == prodType)
				.ToList();
			Product p = products[rnd.Next(products.Count)];
			if (p.Price <= Wallet.Sum)
			{
				uszoda.MyAutomata.API_InsertCoins(Wallet);
				bool success = uszoda.MyAutomata.Get_Product(p);
				if (success)
				{
					MyProducts.Add(p);
					uszoda.GUI_Update();
					switch (prodType)
					{
						case ProductType.Food:
							hungry = false;

							break;
						case ProductType.Drink:
							thirsty = false;
							break;
						default:
							break;
					}
					System.Diagnostics.Debug.WriteLine($"PersonID:{ID} | Sikeres vásárlás! | Product:{p.Name}");
				}
				Wallet.Add(uszoda.MyAutomata.CoinBackBox);
				uszoda.MyAutomata.CoinBackBox = new Wallet();
			}
		}
		private void LeaveTimer_Tick(object sender, EventArgs e)
		{
			leaveTimer.Stop();
			uszoda.Leave(this);
		}
		internal void Buy_Ticket(Uszoda uszoda)
		{
			StorageType tt;
			switch (rnd.Next(2))
			{
				case 0:
					tt = StorageType.Box;
					break;
				case 1:
					tt = StorageType.Cabine;
					break;
				default:
					tt = StorageType.Box;
					break;
			}
			decimal price = uszoda.PriceList[tt];
			if (Cash >= price)
			{
				Ticket = uszoda.Get_Ticket(tt, price);
				if (Ticket != null)
				{
					Cash -= price;
				}
			}

		}
		public void Enter(Uszoda _uszoda, int _storageID)
		{
			this.uszoda = _uszoda;
			StorageID = _storageID;
			leaveTimer.Interval = rnd.Next(30000, 120000);
			leaveTimer.Start();
		}
	}
}
