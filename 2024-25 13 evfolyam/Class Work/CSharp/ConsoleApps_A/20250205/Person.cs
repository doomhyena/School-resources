using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250205
{
	internal class Person
	{
		public string Name { get; }
		public Person(string _name)
		{
			Name = _name;
		}

		private void Hack_Name(string _name)
		{
			Name= _name;
		}
	}
}
