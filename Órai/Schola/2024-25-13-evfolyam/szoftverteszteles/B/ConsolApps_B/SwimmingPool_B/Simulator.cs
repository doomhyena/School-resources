using Automata_2025_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace SwimmingPool_B
{
	internal class Simulator
	{
		static Random rnd = new Random();
		Timer personGenTimer;
		SwimmingPool sp;
		Person person;
		TicketType ticketType;
		int ticketPrice;
		Ticket ticket;
		Storage storage;

		public Simulator()
		{
			personGenTimer = new Timer();
			personGenTimer.Elapsed += PersonGenTimer_Elapsed;
			sp = new SwimmingPool(50, 100);
			
			#region Automata hozzáadása			
			Dictionary<Product, int> storage = new Dictionary<Product, int>() {
				{new Product("Presszó kávé",180), 100},
				{new Product("Hosszú kávé",150), 200},
				{new Product("Capuchino",600), 150},
				{new Product("Ásványvíz",200), 100},
				{new Product("Hell energia ital",350), 100}
			};

			sp.Automatas.Add(
				new Automata(AutomataType.Drink, storage, new Wallet(1000, 1000, 1000, 1000, 1000, 1000))
				); 
			#endregion

		}

		internal void Start()
		{
			personGenTimer.Interval = rnd.Next(1000, 8000);
			personGenTimer.Start();
			do
			{
				Console.Clear();
				Console.WriteLine($"Személyek száma:          {sp.People.Count}");
				Console.WriteLine($"Foglalt kabinok száma:    {sp.Storages.Count(s => s.StorageType == TicketType.Cabin && !s.IsFree)}");
				Console.WriteLine($"Foglalt szekrények száma: {sp.Storages.Count(s => s.StorageType == TicketType.Box && !s.IsFree)}");
				Console.WriteLine($"Bevétel:                  {sp.Cassa.Sum:N} Ft");
				System.Threading.Thread.Sleep(1000);
			} while (true);
		}

		private void PersonGenTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			personGenTimer.Stop();
			//---------------
			PersonGenerator();
			//---------------
			personGenTimer.Interval = rnd.Next(800, 3000);
			personGenTimer.Start();
		}

		private void PersonGenerator()
		{
			person = new Person(new Automata_2025_B.Wallet(
							rnd.Next(5, 10), // 5
							rnd.Next(5, 10), //10
							rnd.Next(5, 10), //20
							rnd.Next(5, 10), //50
							rnd.Next(10, 30), //100
							rnd.Next(20, 50)  //200				
							));
			ticketType = rnd.Next(2) == 1 ? TicketType.Box : TicketType.Cabin;
			ticketPrice = sp.PriceList[ticketType];
			if (person.Wallet.Sum >= ticketPrice)
			{
				// van pénz
				if (sp.Storages.Count(s => s.StorageType == ticketType && s.IsFree) > 0)
				{
					ticket = sp.Buy(ticketType, person.GiveMoney(ticketPrice));
					if (ticket != null)
					{
						storage = sp.ReserveStorage(ticketType);
						person.Enter(ticket, storage, sp.Exit, sp.Automatas);
						sp.Enter(person);
					}
				}
			}
		}
	}
}
