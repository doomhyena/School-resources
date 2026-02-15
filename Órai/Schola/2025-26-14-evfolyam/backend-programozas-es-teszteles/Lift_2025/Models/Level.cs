using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift_2025.Models
{
	public class Level
	{
		public int ID { get; }
		public List<Person> People { get;}
		Action<int> AddToProgram;

		public Level(int _id, Action<int> _addToProgram)
		{
			ID = _id;
			People = new List<Person>();
			AddToProgram = _addToProgram;
		}

		public void AddToPeople(Person person)
		{
			People.Add(person);
		}

		public void RemoveFromPeople(Person person)
		{
			People.Remove(person);	
		}

		internal void CallElevator()
		{
			if (AddToProgram != null)
			{
				AddToProgram(ID);
			}
		}
	}
}
