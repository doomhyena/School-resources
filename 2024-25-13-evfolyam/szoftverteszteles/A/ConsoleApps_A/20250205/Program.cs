using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20250205
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Person p1 = new Person("Cserép Virág");
			Person p2 = new Person("Bazalt Bálint");

			Console.WriteLine(p1.Name);

			p2.Name = "Gipsz Jakab";

		}
	}


}
