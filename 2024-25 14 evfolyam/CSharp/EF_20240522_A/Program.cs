using EF_20240522_A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_20240522_A
{
	class Program
	{
		static void Main(string[] args)
		{
			//List<Employee> employees = DAL.Get_Employees();
			//Employee emp;
			//foreach (var item in employees)
			//{
			//	emp = DAL.Get_Employee(item.EmployeeID);
			//	Console.WriteLine($"{item.Name,-30} Orders sum:{emp.Orders.Sum(q => q.Order_Details.Sum(w => w.Quantity * w.UnitPrice)):N2}");
			//}
			
			foreach (var order in DAL.Get_Orders())
			{
				
				Console.WriteLine($"OrderID:{order.OrderID,3}\tOrder date:{order.OrderDate.Value.ToString("yyyy-MM-dd")}");
				foreach (var od in order.Order_Details)
				{
					Console.WriteLine($"\t{od.Product.ProductName,-40} {od.Quantity,5} {od.UnitPrice:N2}");					
				}
				Console.WriteLine($"Order total:{order.Order_Details.Sum(od=>od.UnitPrice*od.Quantity):N2}");
				for (int i = 0; i < Console.WindowWidth; i++)
				{
					Console.Write('-');
				}
				Console.WriteLine();
			}

			//-----------------------
			Console.ReadKey();
		}
	}
}
