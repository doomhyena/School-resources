using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop_2024_A.Models
{
	public class CartModel
	{
		public Dictionary<int, Product> Products { get; set; }
		public Dictionary<int, int> Cart { get; set; }
		public decimal Sum
		{
			get
			{
				if (Cart != null)
				{
					return Products.Select(p => p.Value).Sum(p => (decimal)p.UnitPrice * Cart[p.ProductID]);
				}
				return 0;
			}
		}
		public decimal TotalQ
		{
			get
			{
				if (Cart != null && Cart.Count > 0)
				{
					return Cart.Sum(c => c.Value);
				}
				return 0;
			}
		}

		public CartModel(Dictionary<int, int> _cart)
		{
			Products = DAL.GetProductsByID(_cart.Keys.ToArray());
			Cart = _cart;
		}
	}
}