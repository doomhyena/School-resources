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
		// C.R.U.D
		public static List<Supplier> Get_Suppliers()
		{
			using (DBContext db = new DBContext())
			{
				return db.Suppliers.ToList();
			}
		}
		public static Supplier Get_Suppliers(int id)
		{
			using (DBContext db = new DBContext())
			{
				return db.Suppliers.Find(id);
			}
		}

		public static void Create_Supplier(Supplier newSupplier)
		{
			using (DBContext db = new DBContext())
			{
				db.Suppliers.Add(newSupplier);
				db.SaveChanges();
			}
		}

		public static void Update_Supplier(int id, Supplier editedSupplier)
		{
			using (DBContext db = new DBContext())
			{
				Supplier original = db.Suppliers.Find(id);
				if (original != null)
				{
					original.Address = editedSupplier.Address;
					original.City = editedSupplier.City;
					original.CompanyName = editedSupplier.CompanyName;
					original.ContactName = editedSupplier.ContactName;


					db.SaveChanges();
				}
			}
		}

		public static void Delete_Supplier(int id)
		{
			using (DBContext db = new DBContext())
			{
				var supplier = db.Suppliers.Find(id);
				if (supplier != null)
				{
					db.Suppliers.Remove(supplier);
					db.SaveChanges();
				}
			}
		}
	}
}
