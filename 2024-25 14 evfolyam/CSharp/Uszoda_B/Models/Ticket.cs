using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uszoda_B.Models
{
	public class Ticket
	{
		static int _id = 1000;
		public int ID { get; }
		public StorageType Type { get; }
		public decimal Price { get; }

		public Ticket(StorageType type)
		{
			ID = _id++;
			Type = type;
		}
	}
}
