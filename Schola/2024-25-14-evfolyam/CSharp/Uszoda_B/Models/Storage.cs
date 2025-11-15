using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uszoda_B.Models
{
	public class Storage
	{
		static int _id = 1;
		public int ID { get; }
		public StorageType Type { get; set; }
		public bool Free
		{
			get => free;
			set
			{
				free = value;
				Label.Free = free;
			}
		}
        public MyLabel Label { get; private set; }
        private bool free;

		public Storage(StorageType _type)
		{
			ID = _id++;
			Type = _type;
			
			Label = new MyLabel(ID);
			Free = true;
		}
	}

	public enum StorageType {Box, Cabine }
}
