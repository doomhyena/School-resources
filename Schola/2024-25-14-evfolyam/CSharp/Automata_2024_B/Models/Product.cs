using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automata_2024_B.Models
{
	public class Product
	{
		static int id = 1;
		public int ID { get; }
		public string Name { get; }
		public decimal Price { get; set; }
		public ProductType Type { get; }

		public Product(string _name, ProductType _type)
		{
			ID = id++;
			Name = _name;
			Type = _type;
		}
				
	}

	public enum ProductType { Food, Drink }
}
