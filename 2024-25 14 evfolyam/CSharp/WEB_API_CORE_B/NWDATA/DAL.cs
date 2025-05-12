using NWDATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWDATA
{
	public class DAL
	{
		public static List<Product> Get_Products()
		{
			try
			{
				using (NorthWind2025Context db=new NorthWind2025Context())
				{
					return db.Products.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
