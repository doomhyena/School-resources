using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _202050205
{
	public class Person
	{
		private string name;
		private int age;

		public int Age
		{
			get
			{
				return age;
			}
			set
			{
				age = value;
			}
		}

		public Person(int _age)
		{
			Age = _age;
		}

		public string Get_Name()
		{
			return name;
		}

		public void Set_Name(string _name)
		{
			name = _name;
		}

		private void Set_Age()
		{
			Age = 23;
		}
	}
}
