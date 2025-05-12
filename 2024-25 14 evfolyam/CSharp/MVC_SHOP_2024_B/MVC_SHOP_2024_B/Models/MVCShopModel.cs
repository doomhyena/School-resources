using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_SHOP_2024_B.Models
{
	public class MVCShopModel
	{
		//public AuthModel AuthModel { get; set; }
		public Authentic Authentic { get; set; }
		public IndexModel IndexModel { get; set; }
		public LayoutModel LayoutModel { get; set; }
		public CartModel CartModel { get; set; }
		public SD SessionData { get; set; }
		public bool IsLogged
		{
			get
			{
				return SessionData.LoggedUser.UserName != null;
			}
		}
		public int CartCount
		{
			get
			{
				return SessionData.Cart.Sum(c => c.Value);
			}
		}
		public bool SignUp { get; set; }

		public MVCShopModel(SD _sessionData)
		{
			Authentic = new Authentic();
			IndexModel = new IndexModel();
			LayoutModel = new LayoutModel();
			CartModel = new CartModel();
			SessionData = _sessionData;

			//---------------------------------
			LayoutModel.LoginButton = SessionData.LoggedUser.UserName.Length>0 ? "Logout" : "Login";
		}
		public MVCShopModel()
		{
			Authentic = new Authentic();
			IndexModel = new IndexModel();
			LayoutModel = new LayoutModel();
			CartModel = new CartModel();
			SessionData = new SD();
		}
	}
}