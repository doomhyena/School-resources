using DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public static class DAL
	{
		public static List<Category> Get_Categories()
		{
			try
			{
				using (NWContext db = new NWContext())
				{
					return db.Categories.AsNoTracking().ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static List<Product> Get_Products()
		{
			try
			{
				using (NWContext db = new NWContext())
				{
					return db.Products.AsNoTracking().ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		public static List<Product> Get_Products(int categoryID)
		{
			try
			{
				using (NWContext db = new NWContext())
				{
					if (db.Categories.Any(c => c.CategoryID == categoryID))
					{
						return db.Products
							.Where(p => p.CategoryID == categoryID)
							.AsNoTracking()
							.ToList();
					}
					return new List<Product>();

				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
