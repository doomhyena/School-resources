using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_DB.Model
{
	public static class DAL
	{
		public static List<Customer> Get_Customers()
		{
			List<Customer> result = new List<Customer>();
			try
			{
				using (NorthWindEntities db=new NorthWindEntities())
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

		public static List<Order> Get_OrdersByID(string customerID)
		{
			List<Order> result = new List<Order>();
			try
			{
				using (NorthWindEntities db=new NorthWindEntities())
				{
					result = db.Orders.Where(q => q.CustomerID == customerID).ToList();
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
