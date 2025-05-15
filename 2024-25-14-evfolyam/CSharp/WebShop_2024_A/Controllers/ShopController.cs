using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop_2024_A.Models;

namespace WebShop_2024_A.Controllers
{
	public class ShopController : Controller
	{
		// GET: Shop
		public ActionResult Index(int id = 0)
		{
			if (id == 0)
			{
				if (Session["CategoryID"] != null)
				{
					id = (int)Session["CategoryID"];
				}
			}
			else if (DAL.IsCategoryValid(id))
			{
				if (Session["CategoryID"] != null && (int)Session["CategoryID"] == id)
				{
					Session["CategoryID"] = id = 0;
				}
				else
				{
					Session["CategoryID"] = id;
				}

			}

			ShopIndexModel model = new ShopIndexModel();
			model.Categories = DAL.GetCategories();
			model.SelectedCategoryID = id;
			model.Products = DAL.GetProducts(model.SelectedCategoryID);

			ViewBag.IsLogged = Session["LoggedUser"] != null && (Session["LoggedUser"] as User).EmployeeID > 0;
			ViewBag.CartCount = Session["CartModel"] != null ? (Session["CartModel"] as CartModel).Cart.Sum(d => d.Value) : 0;
			ViewBag.UserName = Session["LoggedUser"] != null && (Session["LoggedUser"] as User).EmployeeID > 0 ?
				(Session["LoggedUser"] as User).UserName : "";

			return View(model);
		}

		[HttpGet]
		public ActionResult Login()
		{
			ViewBag.IsLogged = Session["LoggedUser"] != null && (Session["LoggedUser"] as User).EmployeeID > 0;
			ViewBag.CartCount = Session["Cart"] != null ? (Session["Cart"] as Dictionary<int, int>).Sum(d => d.Value) : 0;
			ViewBag.UserName = Session["LoggedUser"] != null && (Session["LoggedUser"] as User).EmployeeID > 0 ?
				(Session["LoggedUser"] as User).UserName : "";
			if (ViewBag.IsLogged)
			{
				Session["LoggedUser"] = new User();
				ViewBag.IsLogged = false;
				return RedirectToAction("Index");
			}
			return View(new AuthModel());
		}

		[HttpPost]
		public ActionResult Login(AuthModel model)
		{
			User loggedUser;
			if (DAL.IsUserNameValid(model.User.UserName) && DAL.IsPasswordValid(model.User))
			{
				loggedUser = DAL.GetUser(model.User.UserName);
				Session["LoggedUser"] = loggedUser;
				Session["CartModel"] = new CartModel(new Dictionary<int, int>());
				ViewBag.IsLogged = Session["LoggedUser"] != null && (Session["LoggedUser"] as User).EmployeeID > 0;
				return RedirectToAction("Index");
			}
			else
			{
				model.Message = "Hibás belépési adatok!";
				ViewBag.IsLogged = false;
				ViewBag.CartCount = 0;
				return View(model);
			}
		}

		[HttpPost]
		public ActionResult SignUp(AuthModel model)
		{
			ViewBag.IsLogged = Session["LoggedUser"] != null && (Session["LoggedUser"] as User).EmployeeID > 0;
			ViewBag.CartCount = Session["Cart"] != null ? (Session["Cart"] as Dictionary<int, int>).Sum(d => d.Value) : 0;
			ViewBag.UserName = Session["LoggedUser"] != null && (Session["LoggedUser"] as User).EmployeeID > 0 ?
				(Session["LoggedUser"] as User).UserName : "";

			if (ModelState.IsValid)
			{
				if (!DAL.IsUserNameValid(model.User.UserName))
				{
					if (DAL.IsEmployeeIDValid(model.User.EmployeeID))
					{
						if (DAL.CreateUser(model.User))
						{
							model.Message = "Sikeres regisztráció!";
							return View(model);
						}
					}
					else
					{
						model.Message = "A megadott dolgozó azonosító már hozzárendelt, vagy nem létezik";
					}
				}
				else
				{
					model.Message = "foglalt ez a felhasználónév!";
				}
			}
			model.IsRegistration = true;
			return View("Login", model);
		}

		[HttpGet]
		public ActionResult Cart()
		{
			CartModel cartModel = Session["CartModel"] != null ? (Session["CartModel"] as CartModel) : new CartModel(new Dictionary<int, int>());
			ViewBag.IsLogged = Session["LoggedUser"] != null && (Session["LoggedUser"] as User).EmployeeID > 0;
			ViewBag.CartCount = cartModel.Cart.Sum(d => d.Value);
			ViewBag.UserName = Session["LoggedUser"] != null && (Session["LoggedUser"] as User).EmployeeID > 0 ?
				(Session["LoggedUser"] as User).UserName : "";
			return View(cartModel);
		}

		[HttpGet]
		public ActionResult AddToCart(int id)
		{
			AddProduct(id);
			return RedirectToAction("Index");
		}

		private void AddProduct(int id)
		{
			CartModel cartModel = Session["CartModel"] != null ? (Session["CartModel"] as CartModel) : new CartModel(new Dictionary<int, int>());

			if (!cartModel.Cart.ContainsKey(id))
			{
				cartModel.Cart.Add(id, 0);
				cartModel.Products = DAL.GetProductsByID(cartModel.Cart.Keys.ToArray());
			}
			cartModel.Cart[id]++;
			Session["CartModel"] = cartModel;
		}

		[HttpGet]
		public ActionResult RemoveFromCart(int id)
		{
			CartModel cartModel = Session["CartModel"] != null ? (Session["CartModel"] as CartModel) : new CartModel(new Dictionary<int, int>());

			if (cartModel.Cart.ContainsKey(id))
			{
				cartModel.Cart.Remove(id);
				cartModel.Products.Remove(id);
				Session["CartModel"] = cartModel;
			}
			return RedirectToAction("Cart");
		}

		[HttpGet]
		public ActionResult CartDec(int id)
		{
			CartModel cartModel = new CartModel(new Dictionary<int, int>());
			if (Session["CartModel"] != null)
			{
				cartModel = Session["CartModel"] as CartModel;
				if (cartModel.Cart.ContainsKey(id))
				{
					if (cartModel.Cart[id] > 1)
					{
						cartModel.Cart[id]--;
					}
					else
					{
						cartModel.Cart.Remove(id);
						cartModel.Products.Remove(id);
					}
					Session["CartModel"] = cartModel;
				}
			}
			return RedirectToAction("Cart");
		}

		[HttpGet]
		public ActionResult CartInc(int id)
		{
			AddProduct(id);

			return RedirectToAction("Cart");
		}
	}
}