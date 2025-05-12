using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebShop_2024_A.Models
{
	public static class DAL
	{
		public static List<Category> GetCategories()
		{
			List<Category> result = new List<Category>();
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					result = db.Categories.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
			return result;
		}

		internal static List<Product> GetProducts(int selectedCategoryID)
		{
			List<Product> result = new List<Product>();
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					if (db.Categories.Any(c => c.CategoryID == selectedCategoryID))
					{
						result = db.Products
								.Where(p => p.CategoryID == selectedCategoryID)
								.AsNoTracking()
								.ToList();
					}
					else
					{
						result = db.Products.AsNoTracking().ToList();
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
			return result;
		}

		internal static Dictionary<int, Product> GetProductsByID(int[] keys)
		{
			Dictionary<int, Product> result = new Dictionary<int, Product>();
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					result = db.Products
						.Where(p => keys.Contains(p.ProductID))
						.AsNoTracking()
						.ToDictionary(p => p.ProductID, p => p);
				}
			}
			catch (Exception ex)
			{

				throw;
			}
			return result;
		}

		internal static bool IsCategoryValid(int id)
		{
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					return db.Categories.Any(c => c.CategoryID == id);
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public static string PasswordHASH(String _p)
		{
			SHA512 sha512 = SHA512Managed.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(_p);
			byte[] hash = sha512.ComputeHash(bytes);
			return GetStringFromHash(hash);
		}
		private static string GetStringFromHash(byte[] hash)
		{
			StringBuilder result = new StringBuilder();
			for (int i = 0; i < hash.Length; i++)
			{
				result.Append(hash[i].ToString("x2"));
			}
			return result.ToString();
		}

		internal static bool IsUserNameValid(string userName)
		{
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					return db.Users.Any(u => u.UserName.ToLower() == userName.ToLower());
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		internal static bool IsPasswordValid(User _user)
		{
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					if (db.Users.Any())
					{
						User user = db.Users.Single(u => u.UserName == _user.UserName.ToLower());
						return user.Password == PasswordHASH(_user.Password);
					}
					return false;
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		internal static User GetUser(string userName)
		{
			User result = null;
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					result = db.Users
						.Include(u => u.Employee)
						.AsNoTracking()
						.Single(u => u.UserName.ToLower() == userName);
				}
			}
			catch (Exception)
			{

				throw;
			}
			return result;
		}

		internal static bool IsEmployeeIDValid(int employeeID)
		{
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					return db.Employees.Any(e => e.EmployeeID == employeeID) &&
							!db.Users.Any(u => u.EmployeeID == employeeID);
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		internal static bool CreateUser(User user)
		{
			bool result = false;
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					user.UserName = user.UserName.ToLower();
					user.Password = PasswordHASH(user.Password);
					db.Users.Add(user);
					db.SaveChanges();
					result = true;
				}
			}
			catch (Exception ex)
			{

				throw;
			}
			return result;
		}

		internal static bool IsProductValid(int id)
		{
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					return db.Products.Any(p => p.ProductID == id);
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}
	}
}