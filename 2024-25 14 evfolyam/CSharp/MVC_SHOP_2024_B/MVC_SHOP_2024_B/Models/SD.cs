using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_SHOP_2024_B.Models
{
	public class SD //SessionData
	{
		public Authentic LoggedUser { get; set; }
		public Dictionary<int, int> Cart { get; set; }
		public int SelectedCategory { get; set; }

		public SD()
		{
			LoggedUser = new Authentic();
			Cart = new Dictionary<int, int>();
		}

		public void Save(HttpContext context)
		{
			context.Session["SessionData"] = this;
		}

		public void Load(HttpContext context)
		{
			if (context.Session["SessionData"] != null)
			{
				SD temp = context.Session["SessionData"] as SD;
				LoggedUser = temp.LoggedUser;
				Cart = temp.Cart;
				SelectedCategory = temp.SelectedCategory;

				temp = null;
			}
		}
	}
}