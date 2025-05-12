using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebShop_2024_A.Models;

namespace WebShop_2024_A.API
{
	public class AddProductController : ApiController
	{
		// GET api/<controller>/5
		public CartModel Get(int id)
		{
			if (HttpContext.Current.Session != null && HttpContext.Current.Session["CartModel"] != null && DAL.IsProductValid(id))
			{
				CartModel cartModel = HttpContext.Current.Session["CartModel"] as CartModel;
				if (!cartModel.Cart.ContainsKey(id))
				{
					cartModel.Cart.Add(id, 1);
					cartModel.Products = DAL.GetProductsByID(cartModel.Cart.Keys.ToArray());
				}
				else
				{
					cartModel.Cart[id]++;
				}

				HttpContext.Current.Session["CartModel"] = cartModel;
				return cartModel;
			}
			return null;
		}

	}
}