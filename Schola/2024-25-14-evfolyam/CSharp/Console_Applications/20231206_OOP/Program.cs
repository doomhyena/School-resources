using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231206_OOP
{
			class Program
			{
						static void Main(string[] args)
						{
									Person p1 = new Person() {name="Aladár" };
									Person p2 = p1.Copy();

									p1.name = "Dezső";

									Console.WriteLine(p2.name);
									//-------------------------------
									Console.WriteLine("- VÉGE -");
									Console.ReadKey();
						}
			}

			public class Person
			{
						public string name;

						public Person()
						{
						}
						public Person(string _name)
						{
									name = _name;
						}
						public Person Copy()
						{
									return new Person(this.name);
						}
			}
}
