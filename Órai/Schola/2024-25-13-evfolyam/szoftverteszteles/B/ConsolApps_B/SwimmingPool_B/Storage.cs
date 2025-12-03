using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingPool_B
{
	internal class Storage
	{
		private static int _id=1000;
		public int ID { get; }
		public TicketType StorageType { get; }
		public bool IsFree { get; set; }
		public Storage(TicketType _type)
		{
			ID = _id++;
			StorageType = _type;
			IsFree = true;	
		}
	}
}
