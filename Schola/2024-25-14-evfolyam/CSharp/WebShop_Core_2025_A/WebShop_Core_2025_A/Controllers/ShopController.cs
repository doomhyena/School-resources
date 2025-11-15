using DB;
using Microsoft.AspNetCore.Mvc;
using WebShop_Core_2025_A.Models;

namespace WebShop_Core_2025_A.Controllers
{
	public class ShopController : Controller
	{
		WebShopModel wsm;
		public ShopController()
		{
			wsm = new WebShopModel();
		}
		public IActionResult Index()
		{
			wsm.ShopIndexModel.Categories = DAL.Get_Categories();
			return View(wsm);
		}
	}
}
