using Microsoft.AspNetCore.Mvc;
using ShopData;
using System.Diagnostics;
using WebShop.Models;

namespace WebShop.Controllers
{
	public class WebShopController : Controller
	{
		WebShopModel model;

		public WebShopController()
		{
			model = new WebShopModel();
		}
		public IActionResult Index()
		{
			model.Layout.Title = "Home";
			model.ShopIndex.Categories = DAL.Get_Categories();
			return View(model);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
