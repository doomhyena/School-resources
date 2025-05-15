using DB.Models;

namespace WebShop_Core_2025_A.Models
{
	public class ShopIndexModel
	{
		public List<Category> Categories { get; set; }

		public ShopIndexModel()
		{
			Categories = new List<Category>();
		}
	}
}
