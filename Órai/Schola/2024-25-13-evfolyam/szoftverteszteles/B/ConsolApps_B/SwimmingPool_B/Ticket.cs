using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingPool_B
{
	internal class Ticket
	{
		private static int _id = 1;
		public int ID { get; }
		public TicketType TicketType { get; }

		public Ticket(TicketType ticketType)
		{
			ID = _id++;
			TicketType = ticketType;
		}
	}

	public enum TicketType { Box, Cabin }
}
