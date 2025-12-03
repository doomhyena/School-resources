using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_SHOP_2024_B.Models
{
	public class LayoutModel
	{
		public string LoginButton { get; set; }

		public LayoutModel()
		{
			LoginButton = "Login";
		}
	}
}