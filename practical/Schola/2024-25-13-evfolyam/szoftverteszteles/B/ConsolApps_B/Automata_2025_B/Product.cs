using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_2025_B
{
    public class Product
    {
		static int _id = 1000;
		public int ID { get; }
		public string Name { get; private set; }
		public int Price { get; private set; }

		public Product(string _name, int _price)
		{
			ID = _id++;
			Name = _name;
			Price = _price;
		}
	}
}
