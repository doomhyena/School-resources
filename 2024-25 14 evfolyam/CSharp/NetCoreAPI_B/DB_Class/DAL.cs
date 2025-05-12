using DB_Class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Class
{
	public static class DAL
	{
		public static List<Order> Get_Orders()
		{
			try
			{
				using (NWContext db = new NWContext())
				{
					return db.Orders.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
