using DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
	public class DAL
	{
		public static List<Customer> Get_Customer()
		{
			try
			{
				using (NWEntities db=new NWEntities())
				{
					return db.Customers.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
