using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift_2024_A.Models
{
	public class Level
	{
		public int ID { get; }
		public List<Person> People { get; set; }
		public bool IsCalling
		{
			get => isCalling;
			set 
			{
				isCalling = value;
				if (IsCalling)
				{
					Calling(ID);
				}
			}
		}
		private Action<int> Calling;
		private bool isCalling;

		public Level(int id, Action<int> _calling)
		{
			ID = id;
			Calling = _calling;
			People = new List<Person>();
		}
	}
}
