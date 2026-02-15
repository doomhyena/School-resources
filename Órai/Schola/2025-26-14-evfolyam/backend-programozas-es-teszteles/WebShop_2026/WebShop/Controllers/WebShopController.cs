using DATA;
using DATA.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
	public class WebShopController : Controller
	{
		WebShopModel webShopModel;
		SessionData sd;

		public WebShopController()
		{
			sd = new SessionData();

			;
		}

		[HttpGet]
		public IActionResult Index(string? id)
		{
			sd.Load(this.HttpContext);
			webShopModel = new WebShopModel(sd);

			if (id != null && id == sd.SelectedCategory)
			{
				id = null;
				sd.SelectedCategory = string.Empty;
				sd.Save(HttpContext);
			}

			webShopModel.ShopIndexModel.Categories = DAL.Get_Categories();
			if (id is null || (id != null && !webShopModel.ShopIndexModel.Categories.Any(c => c.CategoryName == id)))
			{
				webShopModel.ShopIndexModel.Products = DAL.Get_Products();
			}
			else
			{
				webShopModel.ShopIndexModel.Products = DAL.Get_Products(id);
				webShopModel.ShopIndexModel.SelectedCategory = id;
				sd.SelectedCategory = id;
				sd.Save(HttpContext);
			}

			return View(webShopModel);
		}

		[Route("{controller}/{action}/{prodid:int}")]
		public IActionResult AddToCart(int prodid)
		{
			sd.Load(this.HttpContext);
			webShopModel = new WebShopModel(sd);
			if (DAL.ProductIsValid(prodid))
			{
				if (!sd.Cart.ContainsKey(prodid))
				{
					sd.Cart.Add(prodid, 0);
				}
				sd.Cart[prodid]++;
				sd.Save(HttpContext);
			}
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Login()
		{
			sd.Load(HttpContext);
			webShopModel = new WebShopModel(sd);
			if (sd.EmployeeID > 0)
			{
				sd.EmployeeID = 0;
				sd.LoginTime = null;
				sd.Cart = new Dictionary<int, decimal>();
				sd.Save(HttpContext);
				return RedirectToAction("Index");
			}
			return View(webShopModel);
		}

		[HttpPost]
		public IActionResult Login(WebShopModel model)
		{
			sd.Load(HttpContext);
			webShopModel = new WebShopModel(sd);
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			else
			{
				//belépési folyamat
				int empID;
				if ((empID = DAL.UserIsValid(model.LoginModel.UserName, model.LoginModel.Password)) != null)
				{
					sd.EmployeeID = empID;
					sd.LoginTime = DateTime.Now;
					sd.Save(HttpContext);
					return RedirectToAction("Index");
				}
				else
				{
					//nem sikerült az ellenőrzés
				}
			}
			return RedirectToAction("Index");
		}
	}
}
