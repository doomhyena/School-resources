using ShopData;
using ShopData.Models;

namespace WebShop.Models
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
