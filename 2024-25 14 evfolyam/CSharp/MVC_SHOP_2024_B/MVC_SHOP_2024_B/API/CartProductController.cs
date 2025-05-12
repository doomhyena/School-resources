using MVC_SHOP_2024_B.Models;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MVC_SHOP_2024_B.API
{
	public class CartProductController : ApiController
	{
		SD sd;
		CartAPIModel model;
		public CartProductController()
		{
			model = new CartAPIModel();
			var session = HttpContext.Current.Session;
			if (session != null && session["SessionData"] != null)
			{
				sd = session["SessionData"] as SD;
			}
			else
			{
				sd = new SD();
			}


		}

		// GET api/<controller>/5
		public CartAPIModel Get(int id)
		{
			// product plus
			if (sd.Cart.ContainsKey(id))
			{
				sd.Cart[id]++;
				HttpContext.Current.Session["SessionData"] = sd;
				UpdateAPIModel();
			}
			return model;
		}

		// POST api/<controller>
		public CartAPIModel Post([FromBody] int id)
		{
			// product minus
			if (sd.Cart.ContainsKey(id))
			{
				if (sd.Cart[id] > 1)
				{
					sd.Cart[id]--;
				}
				else
				{
					sd.Cart.Remove(id);
				}

				HttpContext.Current.Session["SessionData"] = sd;
				UpdateAPIModel();
			}
			return model;
		}

		// PUT api/<controller>/5
		public CartAPIModel Put(int id, [FromBody] int quantity)
		{
			// product direct quantity
			if (sd.Cart.ContainsKey(id))
			{
				sd.Cart[id] = quantity;
				HttpContext.Current.Session["SessionData"] = sd;
				UpdateAPIModel();
			}
			return model;
		}

		// DELETE api/<controller>/5
		public CartAPIModel Delete(int id)
		{
			if (sd.Cart.ContainsKey(id))
			{
				sd.Cart.Remove(id);
				HttpContext.Current.Session["SessionData"] = sd;
				UpdateAPIModel();
			}

			return model;
		}

		private void UpdateAPIModel()
		{
			model.Quantity = sd.Cart;
			model.UnitPrice = DAL.GetProducts(sd.Cart.Keys.ToArray()).ToDictionary(p => p.ProductID, p => (decimal)p.UnitPrice);
			model.CartCount = sd.Cart.Sum(c => c.Value);
			model.SubTotal = sd.Cart.Sum(kv => kv.Value * model.UnitPrice[kv.Key]);
		}
	}
}