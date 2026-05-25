using DATA.Models;

namespace WebShop.Models
{
	public class ShopIndexModel
	{
		public List<Category> Categories { get; set; }
		public List<Product> Products { get; set; }
		public string SelectedCategory { get; set; }
		public Dictionary<int,decimal> Cart { get; set; }

		public ShopIndexModel()
		{
			SelectedCategory = string.Empty;
			Categories = new List<Category>();
			Products = new List<Product>();
			Cart = new Dictionary<int,decimal>();
		}
	}
}
