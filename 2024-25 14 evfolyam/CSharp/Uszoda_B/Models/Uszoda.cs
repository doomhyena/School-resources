using Automata_2024_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uszoda_B.Models
{
	public class Uszoda
	{
		public Dictionary<StorageType, decimal> PriceList { get; private set; }
        public List<Person> People { get; private set; }
        List<Ticket> tickets;
		public int MaxBox { get; }
		public int MaxCabine { get; }
		public int PeopleCount { get { return People.Count; } }
		public int LeaveCount { get; private set; }
		public int TicketCounter { get; private set; }
		public int BoxCount { get { return People.Count(q => q.Ticket.Type == StorageType.Box); } }
		public int CabineCount { get { return People.Count(q => q.Ticket.Type == StorageType.Cabine); } }
		public List<Storage> Storages { get; set; }
		public Automata MyAutomata { get; set; }
		public Action GUI_Update;


		public Uszoda(int _box, int _cabine, Action _GUI_Update)
		{
			People = new List<Person>();
			tickets = new List<Ticket>();
			PriceList = new Dictionary<StorageType, decimal>()
			{
				{ StorageType.Cabine, 5000 },
				{ StorageType.Box , 3000 }
			};
			MaxBox = _box;
			MaxCabine = _cabine;
			MyAutomata = new Automata(new Dictionary<Product, int>()
			{
				{new Product("Kávé",ProductType.Drink){Price=250 },50 },
				{new Product("Tea",ProductType.Drink){Price=100 },100 },
				{new Product("Hell energiaital",ProductType.Drink){Price=400 },80 },
				{new Product("Balaton szelet",ProductType.Food){Price=250 },100 },
				{new Product("Müzli szelet",ProductType.Food){Price=350 },100 }
			},
			new Wallet() { _5 = 10, _10 = 10, _20 = 10, _50 = 10, _100 = 10, _200 = 10 }
			);
			GUI_Update = _GUI_Update;

			#region Create Storages
			Storages = new List<Storage>();
			for (int i = 0; i < MaxBox; i++)
			{
				Storages.Add(new Storage(StorageType.Box));
			}
			for (int i = 0; i < MaxCabine; i++)
			{
				Storages.Add(new Storage(StorageType.Cabine));
			}
			#endregion
		}
		public Ticket Get_Ticket(StorageType type, decimal price)
		{
			Ticket result = null;
			switch (type)
			{
				case StorageType.Box:
					if (MaxBox >= People.Count(q => q.Ticket.Type == StorageType.Box))
					{
						result = new Ticket(type);
					}
					break;
				case StorageType.Cabine:
					if (MaxCabine >= People.Count(q => q.Ticket.Type == StorageType.Cabine))
					{
						result = new Ticket(type);
					}
					break;
				default:
					break;
			}
			TicketCounter += result != null ? 1 : 0;
			return result;
		}
		internal void Enter(Person p)
		{
			People.Add(p);
			Storage storage = Storages.Where(q => q.Type == p.Ticket.Type && q.Free).First();
			storage.Free = false;
			p.Enter(this, storage.ID);
		}
		internal void Leave(Person person)
		{
			People.Remove(person);
			LeaveCount++;
			Storages.Single(q=>q.ID==person.StorageID).Free = true;
			GUI_Update();
		}
	}

	
}
