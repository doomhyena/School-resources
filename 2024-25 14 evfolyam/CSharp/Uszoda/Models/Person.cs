using Automata_DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uszoda.Models
{
	public class Person
	{
		static Random rnd = new Random();
		static int _id = 1000;
		public int ID { get; }
		int cash;
		Wallet coins;
		public int Age { get; private set; }
		public Ticket Ticket { get; private set; }
		public int StorageID { get; set; }
		public bool Hungry
		{
			get => hungry;
			set
			{
				hungry = value;
				TryUseAutomata(ProductType.Food);
			}
		}
		public bool Thirsty
		{
			get => thirsty;
			set
			{
				thirsty = value;
				TryUseAutomata(ProductType.Drink);
			}
		}
		Timer exitTimer;
		Uszoda uszoda;
		private bool hungry;
		List<Product> shopList;
		private bool thirsty;

		public Person(int _cash, Wallet _wallet, int _exitTime)
		{
			ID = _id++;
			Age = rnd.Next(5, 100);
			this.cash = _cash;
			exitTimer = new Timer();
			exitTimer.Interval = _exitTime;
			exitTimer.Tick += ExitTimer_Tick;
			coins = _wallet;
			shopList = new List<Product>();
		}
		private void ExitTimer_Tick(object sender, EventArgs e)
		{
			Leave();
		}
		private void Leave()
		{
			uszoda.Leave(this);
		}
		internal void BuyTicket(Uszoda uszoda)
		{
			TicketType ticketType;
			int ticketPrice = 0;

			if (rnd.Next(2) == 0)
			{
				ticketType = TicketType.Box;
			}
			else
			{
				ticketType = TicketType.Cabine;
			}

			ticketPrice = uszoda.GetPrice(ticketType, Age);
			if (cash >= ticketPrice)
			{
				Ticket = uszoda.GetTicket(ticketPrice, ticketType, Age);
				if (Ticket != null)
				{
					cash -= ticketPrice;
				}
			}
		}
		internal void Enter(Uszoda _uszoda)
		{
			uszoda = _uszoda;
			uszoda.Enter(this);
			exitTimer.Start();
		}
		private void TryUseAutomata(ProductType pt)
		{
			var list = uszoda.MyAutomata.API_GetProducts(pt);
			Product selectedProduct;
			bool success;

			if (list != null && list.Count > 0)
			{
				selectedProduct = list[rnd.Next(list.Count)];
				success = uszoda.MyAutomata.API_Purchase(selectedProduct, coins);
				if (uszoda.MyAutomata.ChangeCoins.Sum > 0)
				{
					coins = uszoda.MyAutomata.ChangeCoins;
					uszoda.MyAutomata.ChangeCoins = new Wallet();
				}
				if (success)
				{
					switch (pt)
					{
						case ProductType.Food:
							Hungry = false;
							break;
						case ProductType.Drink:
							Thirsty = false;
							break;
						default:
							break;
					}
					shopList.Add(selectedProduct);
					uszoda.Update_GUI();
				}
			}
		}

	}
}
