using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace csk_hf_260109
{
    internal class Program
    {
        public class Category { 
            public int CategoryID; 
            public string CategoryName; 
        }
        public class Customer { 
            public string CustomerID; 
            public string CompanyName; 
            public string ContactName; 
        }
        public class Employee { 
            public int EmployeeID; 
            public string FirstName; 
            public string LastName; 
        }
        public class OrderDetail { 
            public int OrderID; 
            public int ProductID; 
            public decimal UnitPrice; 
            public int Quantity; 
        }
        public class Order { 
            public int OrderID; 
            public string CustomerID; 
            public int EmployeeID; 
            public DateTime OrderDate; 
        }
        public class Product { 
            public int ProductID; 
            public string ProductName; 
            public int CategoryID; 
            public decimal UnitPrice; 
        }

        static void Feladat(int n) => Console.WriteLine($"\n{n}. feladat:\n");

        static void Main(string[] args)
        {
            var customers = ReadCsv("Customers.csv", ';', 3)
                .Select(p => new Customer { CustomerID = p[0], CompanyName = p[1], ContactName = p[2] }).ToList();

            var products = ReadCsv("Products.csv", ';', 8)
                .Select(p => new Product
                {
                    ProductID = int.Parse(p[0]),
                    ProductName = p[1],
                    CategoryID = int.Parse(p[2]),
                    UnitPrice = decimal.Parse(p[4], NumberStyles.Number, CultureInfo.InvariantCulture)
                }).ToList();
            var productsById = products.ToDictionary(p => p.ProductID);

            var orders = ReadCsv("Orders.csv", ';', 4)
                .Select(p => new Order
                {
                    OrderID = int.Parse(p[0]),
                    CustomerID = p[1],
                    EmployeeID = int.Parse(p[2]),
                    OrderDate = DateTime.Parse(p[3])
                }).ToList();

            var orderDetails = ReadCsv("Order_Details.csv", ';', 4)
                .Select(p => new OrderDetail
                {
                    OrderID = int.Parse(p[0]),
                    ProductID = int.Parse(p[1]),
                    UnitPrice = decimal.Parse(p[2], NumberStyles.Number, CultureInfo.InvariantCulture),
                    Quantity = int.Parse(p[3])
                }).ToList();

            Feladat(3);
            Console.WriteLine($"Összes cég: {customers.Count}");

            Feladat(4);
            var customerTotals = orders
                .Join(orderDetails, o => o.OrderID, od => od.OrderID, (o, od) => new { o.CustomerID, od.UnitPrice, od.Quantity })
                .GroupBy(x => x.CustomerID)
                .Select(g => new
                {
                    CustomerName = customers.FirstOrDefault(c => c.CustomerID == g.Key)?.CompanyName ?? $"Unknown (ID={g.Key})",
                    TotalSpent = g.Sum(x => x.UnitPrice * x.Quantity)
                })
                .OrderByDescending(x => x.TotalSpent);

            Console.WriteLine($"{"Vásárló",-35} {"Összeg",12}");
            Console.WriteLine(new string('-', 50));
            foreach (var ct in customerTotals)
                Console.WriteLine($"{ct.CustomerName,-35} {ct.TotalSpent,12:C}");

            Feladat(5);
            var productCounts = orderDetails
                .GroupBy(od => od.ProductID)
                .Select(g => new
                {
                    ProductName = productsById.ContainsKey(g.Key) ? productsById[g.Key].ProductName : $"Unknown (ID={g.Key})",
                    TimesBought = g.Count()
                })
                .OrderByDescending(x => x.TimesBought);

            Console.WriteLine($"{"Termék",-35} {"Vásárlások",12}");
            Console.WriteLine(new string('-', 50));
            foreach (var pc in productCounts)
                Console.WriteLine($"{pc.ProductName,-35} {pc.TimesBought,12}");
        }

        static IEnumerable<string[]> ReadCsv(string filePath, char delimiter, int minColumns)
        {
            var fullPath = Path.Combine(AppContext.BaseDirectory, filePath);
            if (!File.Exists(fullPath))
            {
                var available = Directory.GetFiles(AppContext.BaseDirectory).Select(Path.GetFileName);
                throw new FileNotFoundException(
                    $"File '{filePath}' not found in '{AppContext.BaseDirectory}'. Available files: {string.Join(", ", available)}");
            }

            foreach (var line in File.ReadLines(fullPath).Skip(1))
            {
                var parts = line.Split(delimiter).Select(p => p.Trim()).ToArray();
                if (parts.Length >= minColumns)
                    yield return parts;
            }
        }
    }
}
