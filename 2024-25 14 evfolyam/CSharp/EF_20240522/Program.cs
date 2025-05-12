using EF_20240522.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EF_20240522
{
	class Program
	{
		static void Main(string[] args)
		{

			foreach (var item in DAL.Get_EmployeesWithOrders())
			{
				Console.WriteLine($"{item.Name,-20} orders sum:{item.Orders.Sum(q => q.Order_Details.Sum(w => w.UnitPrice * w.Quantity)):N2}");
			}

			//var orders = DAL.Get_OrdersWithProducts();
			//int n = 1;
			//foreach (Order order in orders)
			//{

			//	Console.WriteLine($"{n++,4} OrderID={order.OrderID}\torder date:{order.OrderDate.Value.ToString("yyyy-MM-dd")}");
			//	foreach (var od in order.Order_Details)
			//	{
			//		Console.WriteLine($"\t{od.Product.ProductName,-40} {od.Quantity,5} {od.UnitPrice:N2}");
			//	}
			//	Console.WriteLine();
			//	Console.WriteLine($"Order sum: {order.Order_Details.Sum(q => q.Quantity * q.UnitPrice):N2}");
			//	for (int i = 0; i < Console.WindowWidth; i++)
			//	{
			//		Console.Write('-');
			//	}
			//	Console.WriteLine();
			//}




			//-------------------------
			Console.ReadKey();
		}
	}
}
