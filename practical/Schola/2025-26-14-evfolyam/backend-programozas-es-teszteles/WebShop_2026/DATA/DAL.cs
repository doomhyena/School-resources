using DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
	public static class DAL
	{
		public static List<Category> Get_Categories()
		{
			List<Category> result = new List<Category>();
			try
			{
				using (NW_2025Ctx db = new NW_2025Ctx())
				{
					result = db.Categories
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
		public static List<Product> Get_Products()
		{
			List<Product> result = new List<Product>();
			try
			{
				using (NW_2025Ctx db = new NW_2025Ctx())
				{
					result = db.Products
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
		public static List<Product> Get_Products(string catName)
		{
			List<Product> result = new List<Product>();
			try
			{
				using (NW_2025Ctx db = new NW_2025Ctx())
				{
					result = db.Products
						.AsNoTracking()
						.Where(p => p.Category.CategoryName == catName)
						.ToList();
				}
			}
			catch (Exception ex)
			{

				throw;
			}
			return result;
		}

		public static string PasswordHASH(String _p)
		{
			SHA512 sha512 = SHA512Managed.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(_p);
			byte[] hash = sha512.ComputeHash(bytes);
			return GetStringFromHash(hash);
		}

		public static bool ProductIsValid(int prodid)
		{
			try
			{
				using (NW_2025Ctx db=new NW_2025Ctx())
				{
					return db.Products.Any(p => p.ProductId == prodid);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static int UserIsValid(string _username, string _password)
		{
			int result = 0;
			try
			{
				using (NW_2025Ctx db = new NW_2025Ctx())
				{
					if (db.Authentications.Any(a => a.UserName == _username) && db.Authentications.Single(a => a.UserName == _username).Password == PasswordHASH(_password))
					{
						result = db.Authentications.Single(a => a.UserName == _username && a.Password == PasswordHASH(_password)).EmployeeId;
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
			return result;
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
	}
}
