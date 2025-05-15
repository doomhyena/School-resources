using Microsoft.EntityFrameworkCore;
using ShopData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopData
{
	public static class DAL
	{
		public static List<Category>? Get_Categories()
		{
			try
			{
				using (DBContext db=new DBContext())
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
				using (DBContext db = new DBContext())
				{
					return db.Products.AsNoTracking().ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
