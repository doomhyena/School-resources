using MVC_SHOP_2024_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SessionCtx = System.Web.HttpContext;

namespace MVC_SHOP_2024_B.Controllers
{
	public class ShopController : Controller
	{
		SD sd;
		public ShopController()
		{
			sd = new SD();
			sd.Load(System.Web.HttpContext.Current);
		}
		// GET: Shop
		public ActionResult Index(int? id)
		{
			if (id != null && DAL.IsCategoryValid(id))
			{
				sd.SelectedCategory = (int)id;
				sd.Save(SessionCtx.Current);
			}

			IndexModel model = new IndexModel()
			{
				Categories = DAL.GetCategories(),
				SelectedCategory = sd.SelectedCategory,
				Products = DAL.GetProducts(sd.SelectedCategory),
				LoggedUser = sd.LoggedUser
			};

			MVCShopModel mvcModel = new MVCShopModel(sd);
			mvcModel.IndexModel = model;
			return View(mvcModel);
		}

		[HttpGet]
		public ActionResult LogIn()
		{
			if (sd.LoggedUser.UserName.Length > 0)
			{
				// Logout
				sd = new SD();
				sd.Save(System.Web.HttpContext.Current);

				return RedirectToAction("Index");
			}
			return View(new MVCShopModel());
		}

		[HttpPost]
		public ActionResult LogIn(MVCShopModel model)
		{
			if (ModelState.IsValid)
			{
				model.Authentic.UserName = model.Authentic.UserName.ToLower();
				if (DAL.CheckUserName(model.Authentic.UserName))
				{
					Authentic auth = DAL.Get_Auth(model.Authentic.UserName);

					if (auth.Password == DAL.PasswordHASH(model.Authentic.Password))
					{
						auth.Password = string.Empty;
						sd.LoggedUser = auth;
						sd.Save(System.Web.HttpContext.Current);
						return RedirectToAction("Index");
					}
				}
			}
			model.Authentic.Message = "Hibás bejelentkezési adatok!";
			return View(model);
		}

		[HttpPost]
		public ActionResult Signup(MVCShopModel model)
		{
			if (ModelState.IsValid)
			{
				model.Authentic.UserName = model.Authentic.UserName.ToLower();
				if (DAL.CheckEmployeeID(model.Authentic.EmployeeID))
				{
					if (!DAL.CheckUserName(model.Authentic.UserName))
					{
						if (DAL.Signup(model.Authentic))
						{
							model.Authentic.Password = string.Empty;
							sd.LoggedUser = model.Authentic;
							sd.Save(System.Web.HttpContext.Current);
							return View(model);
						}
						else
						{
							model.Authentic.Message = "Sikertelen művelet!";
						}
					}
					else
					{
						model.Authentic.Message = "Foglalt felhasználónév!";
					}
				}
				else
				{
					model.Authentic.Message = "Nincs ilyen azonosítóval dolgozó!";
				}
			}
			else
			{
				model.Authentic.Message = "Hibás adatok!";
			}
			model.SignUp = true;
			return View("Login", model);
		}

		#region Cart
		[HttpGet]
		public ActionResult Cart()
		{
			MVCShopModel model = new MVCShopModel(sd);
			model.CartModel.Products = DAL.GetProducts(sd.Cart.Keys.ToArray());
			return View(model);
		}

		[HttpGet]
		public ActionResult AddToCart(int id)
		{
			AddProduct(id);
			return RedirectToAction("Index");
		}

		private void AddProduct(int id)
		{
			if (DAL.IsProductValid(id))
			{
				if (!sd.Cart.ContainsKey(id))
				{
					sd.Cart.Add(id, 0);
				}
				sd.Cart[id]++;
				sd.Save(SessionCtx.Current);
			}
		}

		[HttpGet]
		public ActionResult RemoveFromCart(int id)
		{
			if (sd.Cart.ContainsKey(id))
			{
				sd.Cart.Remove(id);
				sd.Save(SessionCtx.Current);
			}
			return RedirectToAction("Cart");
		}
		[HttpGet]
		public ActionResult ProductDec(int id)
		{
			AddProduct(id);
			return RedirectToAction("Cart");
		}

		[HttpGet]
		public ActionResult ProductInc(int id)
		{
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
				sd.Save(SessionCtx.Current);
			}
			return RedirectToAction("Cart");
		}

		#endregion


	}
}