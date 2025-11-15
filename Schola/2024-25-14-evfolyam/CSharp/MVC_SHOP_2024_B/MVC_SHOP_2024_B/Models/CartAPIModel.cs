using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_SHOP_2024_B.Models
{
	public class CartAPIModel
	{
		public Dictionary<int,int> Quantity { get; set; }
		public Dictionary<int,decimal> UnitPrice { get; set; }
		public int CartCount { get; set; }
		public decimal SubTotal { get; set; }

		public CartAPIModel()
		{
			Quantity = new Dictionary<int, int>();
			UnitPrice = new Dictionary<int,decimal>();
		}
	}
}