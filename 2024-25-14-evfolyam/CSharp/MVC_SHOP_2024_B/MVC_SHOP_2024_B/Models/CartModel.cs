using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_SHOP_2024_B.Models
{
	public class CartModel
	{
		public List<Product> Products { get; set; }
		public CartModel()
		{
			Products = new List<Product>();
		}
	}
}