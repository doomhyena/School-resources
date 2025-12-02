using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DATA_NW
{
	public static class DAL
	{
		public static List<Category> Get_Categories()
		{
			var result = new List<Category>();
			try
			{
				using (NWEntities db = new NWEntities())
				{
					result = db.Categories
						.AsNoTracking()
						.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}

			return result;
		}

		public static Product Get_Product(int prodID)
		{
			var result = new Product();
			try
			{
				using (NWEntities db = new NWEntities())
				{
					result = db.Products.Find(prodID);
				}
			}
			catch (Exception)
			{

				throw;
			}
			return result;
		}

		public static List<Product> Get_Products(int catID)
		{
			var result = new List<Product>();
			try
			{
				using (NWEntities db = new NWEntities())
				{
					result = db.Products
						.AsNoTracking()
						.Where(p => p.CategoryID == catID)
						.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
			return result;
		}

		public static bool Create_Product(Product newProduct)
		{
			try
			{
				using (NWEntities db = new NWEntities())
				{
					db.Products.Add(newProduct);
					db.SaveChanges();
					return true;
				}
			}
			catch (Exception)
			{
				throw;
				return false;
			}
		}

		public static Tuple<bool, Exception> Update_Product(Product product)
		{
			try
			{
				using (NWEntities db = new NWEntities())
				{
					db.Products.Attach(product);
					db.Entry(product).State = EntityState.Modified;
					db.SaveChanges();

					//Product origin=db.Products.Find(product.ProductID);
					//origin.ProductName= product.ProductName;
					//db.SaveChanges();
					return new Tuple<bool, Exception>(true, null);
				}
			}
			catch (Exception ex)
			{
				return new Tuple<bool, Exception>(false, ex);

			}
		}

		public static List<Customer> Get_Customers()
		{
			List<Customer> result=new List<Customer>();
			try
			{
				using (NWEntities db=new NWEntities())
				{
					result = db.Customers.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
			return result;
		}
	}
}
