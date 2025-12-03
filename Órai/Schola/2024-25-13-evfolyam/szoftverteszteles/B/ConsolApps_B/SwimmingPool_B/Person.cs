using Automata_2025_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SwimmingPool_B
{
	internal class Person
	{
		private static Random rnd = new Random();
		private static int _id = 1000;
		public int ID { get; }
		public Wallet Wallet { get; private set; }
		public Ticket Ticket { get; private set; }
		public Storage Storage { get; set; }
		public List<Product> MyProducts { get; private set; }
		public TicketType Choose
		{
			get
			{
				return rnd.Next(0, 2) == 0 ? TicketType.Cabin : TicketType.Box;
			}
		}
		public bool Hungry { get; private set; }
		public bool Thirsty { get; private set; }
		private Timer leaveTimer, needsTimer;
		private Action<Person> Exit;
		private List<IAutomata> automatas;

		public Person(Wallet _startWallet)
		{
			ID = _id++;
			Wallet = _startWallet;
			MyProducts = new List<Product>();
			leaveTimer = new Timer();
			leaveTimer.Elapsed += LeaveTimer_Elapsed;

			needsTimer = new Timer();
			needsTimer.Elapsed += NeedsTimer_Elapsed;
		}

		private void NeedsTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			needsTimer.Stop();
			EatOrDrink();
			needsTimer.Interval = rnd.Next(20000, 30000);
			needsTimer.Start();
		}

		private void EatOrDrink()
		{
			AutomataType at;
			IAutomata a = null;
			if (!(Hungry || Thirsty)) //korábbi állapot
			{
				at = new AutomataType[] { AutomataType.Food, AutomataType.Drink }[rnd.Next(2)];
				switch (at)
				{
					case AutomataType.Food:
						Hungry = true;
						break;
					case AutomataType.Drink:
						Thirsty = true;
						break;
					default:
						break;
				}
			}

			if (Hungry)
			{
				if (automatas.Any(q => q.AutomataType == AutomataType.Food && q.IsFree))
				{
					a = automatas.First(q => q.AutomataType == AutomataType.Food && q.IsFree);
				}
			}
			else if (Thirsty)
			{
				if (automatas.Any(q => q.AutomataType == AutomataType.Drink && q.IsFree))
				{
					a = automatas.First(q => q.AutomataType == AutomataType.Drink && q.IsFree);
				}
			}
			if (a != null)
			{
				UseAutomata(a);
			}
		}

		private void UseAutomata(IAutomata a)
		{
			a.IsFree = false;
			Product[] products = a.PriceList().ToArray();
			Product p = a.Purchase(products[rnd.Next(products.Length)].ID, Wallet);
			if (p != null)
			{
				MyProducts.Add(p);
				Wallet = new Wallet(a.CoinBox);
				a.CoinBox.Clear();
				switch (a.AutomataType)
				{
					case AutomataType.Food:
						Hungry = false;
						break;
					case AutomataType.Drink:
						Thirsty = false;
						break;
					default:
						break;
				}
				System.Diagnostics.Debug.WriteLine($"Sikeres vásárlás: {p.Name} | PesronID: {ID}");
			}
			else
			{
				a.CoinBox.Clear();
				System.Diagnostics.Debug.WriteLine($"Sikertelen vásárlás, Type:{a.AutomataType}");
			}

			a.IsFree = true;
		}

		public void Enter(Ticket _ticket, Storage _storage, Action<Person> _exit, List<IAutomata> _automatas)
		{
			Ticket = _ticket;
			Storage = _storage;
			Exit = _exit;
			automatas = _automatas;

			leaveTimer.Interval = rnd.Next(30000, 90000);
			leaveTimer.Start();
			needsTimer.Interval = rnd.Next(20000, 30000);
			needsTimer.Start();
		}
		public void Leave()
		{
			if (Exit != null)
			{
				Exit(this);
			}
		}
		private void LeaveTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			leaveTimer.Stop();
			leaveTimer.Dispose();
			Leave();
		}

		internal Wallet GiveMoney(int price)
		{
			Wallet result = new Wallet();
			bool roundOk;
			int tPrice = price;
			do
			{
				roundOk = false;
				if (tPrice >= 200 && Wallet._200 >= 0)
				{
					Wallet._200--;
					tPrice -= 200;
					result._200++;
					roundOk = true;
				}
				else if (tPrice >= 100 && Wallet._100 >= 0)
				{
					Wallet._100--;
					tPrice -= 100;
					result._100++;
					roundOk = true;
				}
				else if (tPrice >= 50 && Wallet._50 >= 0)
				{
					Wallet._50--;
					tPrice -= 50;
					result._50++;
					roundOk = true;
				}
				else if (tPrice >= 20 && Wallet._20 >= 0)
				{
					Wallet._20--;
					tPrice -= 20;
					result._20++;
					roundOk = true;
				}
				else if (tPrice >= 10 && Wallet._10 >= 0)
				{
					Wallet._10--;
					tPrice -= 10;
					result._10++;
					roundOk = true;
				}
				else if (tPrice >= 5 && Wallet._5 >= 0)
				{
					Wallet._5--;
					tPrice -= 5;
					result._5++;
					roundOk = true;
				}
			} while (result.Sum != price && roundOk);
			return result;
		}
	}
}
