using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_SHOP_2024_B.Models
{
	public class ShopIndexModel
	{
		public List<Category> Categories { get; set; }
		public List<Product> Products { get; set; }
		public int SelectedCategory { get; set; }
		public User LoggedUser { get; set; }

		public ShopIndexModel()
		{
			Categories = new List<Category>();
			Products = new List<Product>();
			LoggedUser = new User();
		}
	}
}