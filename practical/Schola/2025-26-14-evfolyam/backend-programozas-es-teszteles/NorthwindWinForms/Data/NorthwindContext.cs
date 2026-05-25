using System.Data.Entity;

namespace NorthwindWinForms
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext() : base("name=NorthwindConn") { }

        static NorthwindContext()
        {
            Database.SetInitializer<NorthwindContext>(null);
        }

        public DbSet<Product> Products { 
            get; set; 
        }
        public DbSet<Customer> Customers { 
            get; set; 
        }
        public DbSet<Order> Orders { 
            get; set; 
        }
        public DbSet<OrderDetail> OrderDetails { 
            get; set; 
        }

        protected override void OnModelCreating(DbModelBuilder mb)
        {
            mb.Entity<Product>().ToTable("Products").HasKey(p => p.ProductId);
            mb.Entity<Customer>().ToTable("Customers").HasKey(c => c.CustomerId);
            mb.Entity<Order>().ToTable("Orders").HasKey(o => o.OrderId);

            mb.Entity<OrderDetail>()
              .ToTable("Order Details")
              .HasKey(od => new { od.OrderId, od.ProductId });

            base.OnModelCreating(mb);
        }
    }

    public class Product
    {
        public int ProductId { 
            get; set; 
        }
        public string ProductName { 
            get; set; 
        }
    }

    public class Customer
    {
        public string CustomerId { 
            get; set; 
        }
        public string CompanyName { 
            get; set; 
        }
    }

    public class Order
    {
        public int OrderId { 
            get; set; 
        }
        public string CustomerId { 
            get; set; 
        }
    }

    public class OrderDetail
    {
        public int OrderId { 
            get; set; 
        }
        public int ProductId { 
            get; set; 
        }
        public decimal UnitPrice {
            get; set; 
        }
        public short Quantity { 
            get; set; 
        }
        public float Discount { 
            get; set; 
        } 
    }
}
