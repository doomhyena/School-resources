using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uszoda.Models
{
	public class Storage
	{
		static int _id = 1;
		public int ID { get; }
		public TicketType Type { get; }
		public bool Free { get; set; }

		public Storage(TicketType _type)
		{
			ID = _id++;
			Type = _type;
			Free = true;
		}
	}
}
