using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF_20240522_A.Models
{
	public static class DAL
	{
		public static List<Employee> Get_Employees()
		{
			var result = new List<Employee>();
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
		public static Employee Get_Employee(int id)
		{
			Employee result = null;
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					if (db.Employees.Any(q => q.EmployeeID == id))
					{
						result = db.Employees
							.Include(q => q.Orders.Select(w => w.Order_Details))
							.First(q => q.EmployeeID == id);
					}
				}
			}
			catch (Exception)
			{

				throw;
			}
			return result;
		}
		public static List<Order> Get_Orders()
		{
			List<Order> result = new List<Order>();
			try
			{
				using (NorthWindEntities db = new NorthWindEntities())
				{
					result = db.Orders
						.Include(o => o.Order_Details.Select(od => od.Product))
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
