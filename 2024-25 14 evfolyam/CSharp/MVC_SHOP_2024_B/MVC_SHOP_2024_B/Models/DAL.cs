using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MVC_SHOP_2024_B.Models
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
					result = db.Categories.AsNoTracking().ToList();
				}
			}
			catch (Exception ex)
			{

				throw;
			}
			return result;
		}

		internal static bool CheckEmployeeID(int employeeID)
		{
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					return db.Employees.Any(e => e.EmployeeID == employeeID);
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		internal static bool CheckUserName(string username)
		{
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					return db.Authentics.Any(a => a.UserName == username);
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		internal static List<Product> GetProducts(int catId)
		{
			List<Product> result = new List<Product>();
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					if (db.Categories.Any(c => c.CategoryID == catId))
					{
						result = db.Products.Where(p => p.CategoryID == catId).AsNoTracking().ToList();
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

		internal static List<Product> GetProducts(int[] prodIDs)
		{
			List<Product> result = new List<Product>();
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					result = db.Products
						.Where(p => prodIDs.Contains(p.ProductID))
						.AsNoTracking()
						.ToList();
				}
			}
			catch (Exception ex)
			{

				throw;
			}
			return result;
		}

		internal static Authentic Get_Auth(string username)
		{
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					return db.Authentics.Single(a => a.UserName == username);
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		internal static bool IsCategoryValid(int? id)
		{
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					return db.Categories.Any(p => p.CategoryID == id);
				}
			}
			catch (Exception ex)
			{

				throw;
			}
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

		internal static bool Signup(Authentic authentic)
		{
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					Authentic data = new Authentic()
					{
						EmployeeID = authentic.EmployeeID,
						UserName = authentic.UserName,
						Password = PasswordHASH(authentic.Password)
					};
					db.Authentics.Add(data);
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception ex)
			{
				return false;
				throw;
			}

		}

		#region SHA methods
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
		#endregion
	}
}