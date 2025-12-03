using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uszoda.Models
{
	public class Ticket
	{
		static int _id = 1000;
		public int ID { get; }
		public TicketType TicketType { get; set; }
		public int Price { get; }

		public bool Discount { get;}

		public Ticket(TicketType _type, int _price, bool _discount)
		{
			TicketType = _type;
			Price = _price;
			ID = _id++;
			Discount = _discount;
		}
	}
}
