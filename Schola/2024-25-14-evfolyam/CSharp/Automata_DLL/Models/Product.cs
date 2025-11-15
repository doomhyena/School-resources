
namespace Automata_DLL.Models
{
	public class Product
	{
		static int id = 1;
		public int ID { get; }
		public string Name { get; private set; }
		public decimal Price { get; set; }
		public ProductType Type { get; set; }
		public Product(string _name, decimal _price, ProductType _type)
		{
			ID = id++;
			Name = _name;
			Price = _price;
			Type = _type;
		}
	}

	public enum ProductType { Food, Drink }
}
