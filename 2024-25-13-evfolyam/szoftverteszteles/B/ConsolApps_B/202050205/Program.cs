using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _202050205
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Person p1 = new Person(23);
			//p1.name = "Gipsz Jakab";
			p1.Set_Name("Gipsz Jakab");
			p1.Age = 21;

			Person p2=new Person(47);



			Console.WriteLine($"p1 name={p1.Get_Name()}");
			Console.WriteLine($"p1 age={p1.Age}");

			//------------------
			Console.ReadKey();
		}
	}


}
