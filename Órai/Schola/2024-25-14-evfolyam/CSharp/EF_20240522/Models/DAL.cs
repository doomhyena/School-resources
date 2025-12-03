using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF_20240522.Models
{
	public static class DAL
	{
		public static List<Employee> Get_Employees()
		{
			List<Employee> result = new List<Employee>();
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					result = db.Employees.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
			return result;
		}
		public static List<Employee> Get_EmployeesWithOrders()
		{
			List<Employee> result = new List<Employee>();
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					result = db.Employees
						.Include(q => q.Orders.Select(w=>w.Order_Details))
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
		public static List<Order> Get_OrdersWithProducts()
		{
			List<Order> result = new List<Order>();
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					result = db.Orders
						.Include(q => q.Order_Details.Select(w => w.Product))
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
	}
}
