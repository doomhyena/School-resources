using Automata_2025_B;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingPool_B
{
	internal class SwimmingPool
	{
		public Dictionary<TicketType, int> PriceList { get; private set; }
		public List<Person> People { get; set; }
		public List<Storage> Storages { get; set; }
		public List<Ticket> Tickets { get; set; }
		public List<IAutomata> Automatas { get; set; }
		public Wallet Cassa { get; private set; }
		Storage storage;

		public SwimmingPool(int _cabine, int _box)
		{
			People = new List<Person>();
			Storages = new List<Storage>();
			Tickets = new List<Ticket>();
			Cassa = new Wallet();
			Automatas = new List<IAutomata>();
			PriceList = new Dictionary<TicketType, int>() {
				{TicketType.Cabin,6000 },
				{TicketType.Box, 5000 }
			};
			Init_Storages(_cabine, _box);
		}

		private void Init_Storages(int cabine, int box)
		{
			for (int i = 0; i < cabine; i++)
			{
				Storages.Add(new Storage(TicketType.Cabin));
			}
			for (int i = 0; i < box; i++)
			{
				Storages.Add(new Storage(TicketType.Box));
			}
		}
		public Ticket Buy(TicketType _type, Wallet _price)
		{
			Ticket result = null;
			if (_price.Sum == PriceList[_type])
			{
				result = new Ticket(_type);
				Tickets.Add(result);
				Cassa.Add(_price);
			}
			return result;
		}
		public void Enter(Person _person)
		{
			People.Add(_person);
		}
		internal Storage ReserveStorage(TicketType ticketType)
		{
			storage = Storages.First(s => s.StorageType == ticketType && s.IsFree);
			storage.IsFree = false;
			return storage;
		}
		public void Exit(Person _person)
		{
			Storages.Single(s => s.ID == _person.Storage.ID).IsFree = true;
			People.Remove(_person);
		}
	}
}
