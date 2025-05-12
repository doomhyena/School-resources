using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
	public static class DAL
	{
		public static List<Category> Get_Categories()
		{
			try
			{
				using (NWContext db = new NWContext())
				{
					return db.Categories.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		public static Category Get_Category(int id)
		{
			try
			{
				using (NWContext db = new NWContext())
				{
					return db.Categories.Find(id);
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		public static void Create_Category(Category newCategory)
		{
			try
			{
				using (NWContext db = new NWContext())
				{
					db.Categories.Add(newCategory);
					db.SaveChanges();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		public static void Update_Category(int id, Category category)
		{
			try
			{
				using (NWContext db = new NWContext())
				{
					Category actual = db.Categories.Find(id);
					if (actual != null)
					{
						actual.Picture = category.Picture;
						actual.Description = category.Description;
						actual.CategoryName = category.CategoryName;
						db.SaveChanges();
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		public static void Delete_Category(int id)
		{
			try
			{
				using (NWContext db = new NWContext())
				{
					Category c = db.Categories.Find(id);
					if (c != null)
					{
						db.Categories.Remove(c);
						db.SaveChanges();
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
