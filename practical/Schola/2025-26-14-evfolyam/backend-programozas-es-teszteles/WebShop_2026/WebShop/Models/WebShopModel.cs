using DATA.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace WebShop.Models
{
	public class WebShopModel
	{
		public ShopIndexModel ShopIndexModel { get; set; }
		public LayoutModel LayoutModel { get; set; }
		public LoginModel LoginModel { get; set; }
		public bool IsLogin { get; set; }

		public WebShopModel()
		{
			ShopIndexModel = new ShopIndexModel();
			LayoutModel = new LayoutModel();
			LoginModel = new LoginModel();
		}

		public WebShopModel(SessionData _sd)
		{
			ShopIndexModel = new ShopIndexModel();
			LayoutModel = new LayoutModel();
			LoginModel = new LoginModel();
			LayoutModel.LoginButton = _sd.EmployeeID > 0 ? "Logout" : "Login";

			if (_sd.EmployeeID > 0)
			{
				LayoutModel.LoginButton = "Logout";
				IsLogin = _sd.EmployeeID > 0;
				ShopIndexModel.Cart = _sd.Cart;
				ShopIndexModel.SelectedCategory= _sd.SelectedCategory;
			}
			else
			{
				LayoutModel.LoginButton = "Login";
			}

		}
	}
}
