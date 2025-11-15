using Automata_DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uszoda.Models
{
	public class Uszoda
	{
		public List<Person> People { get; private set; }
		public List<Ticket> Tickets { get; private set; }
		public List<Storage> Storages { get; private set; }
		public int Box { get; private set; }
		public int Cabine { get; private set; }
		public Automata MyAutomata { get; private set; }
		private Action Refresh_UX;

		public Uszoda(int _box, int _cabine, Action _refresh_UX)
		{
			People = new List<Person>();
			Tickets = new List<Ticket>();
			Box = _box;
			Cabine = _cabine;
			Storages = new List<Storage>();
			SetStorages();
			MyAutomata = new Automata(
				new Dictionary<Product, int>() {
				{new Product("Kávé",200,ProductType.Drink),10 },
				{new Product("Tea",100,ProductType.Drink),50 },
				{new Product("Balaton szelet",250,ProductType.Food),10 },
				{new Product("Mars szelet",200,ProductType.Food),20 },
				{new Product("Hell energiaital",300,ProductType.Drink),30 }},
				new Wallet() { _5 = 1, _10 = 1, _20 = 1, _50 = 1, _100 = 1, _200 = 1 }
				);
			Refresh_UX = _refresh_UX;
		}

		private void SetStorages()
		{
			for (int i = 0; i < Cabine; i++)
			{
				Storages.Add(new Storage(TicketType.Cabine));
			}
			for (int i = 0; i < Box; i++)
			{
				Storages.Add(new Storage(TicketType.Box));
			}
		}

		public Ticket GetTicket(int _price, TicketType _type, int _age)
		{
			Ticket result = null;
			bool discount = _age <= 14;
			switch (_type)
			{
				case TicketType.Box:
					if (Box - People.Count(q => q.Ticket.TicketType == TicketType.Box) > 0)
					{
						result = new Ticket(_type, GetPrice(TicketType.Box, _age), discount);
						Tickets.Add(result);
					}
					break;
				case TicketType.Cabine:
					if (Cabine - People.Count(q => q.Ticket.TicketType == TicketType.Cabine) > 0)
					{
						result = new Ticket(_type, GetPrice(TicketType.Cabine, _age), discount);
						Tickets.Add(result);
					}
					break;
				default:
					break;
			}
			return result;
		}
		public int GetPrice(TicketType _ticketType, int _age)
		{
			int result = 0;
			switch (_ticketType)
			{
				case TicketType.Box:
					result = 1000;
					break;
				case TicketType.Cabine:
					result = 1500;
					break;
				default:
					return 0;
			}
			if (_age <= 14)
			{
				result /= 2;
			}
			return result;
		}

		internal void Enter(Person p)
		{
			People.Add(p);
			Storage st = Storages.First(q => q.Type == p.Ticket.TicketType && q.Free);
			st.Free = false;
			p.StorageID = st.ID;
		}
		internal void Leave(Person person)
		{
			if (People.Contains(person))
			{
				People.Remove(person);
				Storage st = Storages.First(q => q.ID == person.StorageID);
				st.Free = true;
			}
		}
		public void Update_GUI()
		{
			Refresh_UX();
		}
	}
}
