using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift_2024_B.Models
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
				if (value)
				{
					callElevator(ID); 
				}
			}
		}
		private Action<int> callElevator;		
		private bool isCalling;

		public Level(int _id, Action<int> _callElevator)
		{
			ID = _id;
			People = new List<Person>();
			callElevator = _callElevator;
		}

		public void CallButton()
		{
			
		}
	}
}
