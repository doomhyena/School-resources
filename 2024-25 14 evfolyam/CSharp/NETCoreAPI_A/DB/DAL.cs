using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public static class DAL
	{
		public static List<Customer> Get_Cusomer()
		{
			try
			{
				using (NWEntities db = new NWEntities())
				{
					return db.Customers.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		public static Customer Get_Customer(string id)
		{
			try
			{
				using (NWEntities db = new NWEntities())
				{
					return db.Customers.Find(id);
				}
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public static Tuple<bool, Exception> Create_Customer(Customer customer)
		{
			try
			{
				using (NWEntities db = new NWEntities())
				{
					db.Customers.Add(customer);
					db.SaveChanges();
					return new Tuple<bool, Exception>(true, null);
				}
			}
			catch (Exception ex)
			{
				return new Tuple<bool, Exception>(false, ex);
				throw;
			}
		}
		public static void Update_Customer(string id, Customer _customer)
		{
			try
			{
				using (NWEntities db = new NWEntities())
				{
					Customer customer = db.Customers.Find(id);
					if (customer != null)
					{
						customer.CompanyName = _customer.CompanyName;
						db.SaveChanges();
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		public static void Delete_Customer(string id)
		{
			try
			{
				using (NWEntities db = new NWEntities())
				{
					Customer c = db.Customers.Find(id);
					if (c != null)
					{
						db.Customers.Remove(c);
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
