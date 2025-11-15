using System;
using System.Linq;
using System.Windows.Forms;

namespace NorthwindWinForms
{
    public partial class Form1 : Form
    {
        private readonly NorthwindContext _db;

        public Form1()
        {
            InitializeComponent();

            _db = new NorthwindContext(); 
            WireEvents();
            LoadProducts();
        }

        private void LoadProducts()
        {
            var products = _db.Products
                .OrderBy(p => p.ProductName)
                .Select(p => new { p.ProductId, p.ProductName })
                .ToList();

            cmbProducts.DisplayMember = "ProductName";
            cmbProducts.ValueMember = "ProductId";
            cmbProducts.DataSource = products;

        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbProducts.SelectedValue is int productId)) return;

            var customers = (from od in _db.OrderDetails
                             join o in _db.Orders on od.OrderId equals o.OrderId
                             join c in _db.Customers on o.CustomerId equals c.CustomerId
                             where od.ProductId == productId
                             orderby c.CompanyName
                             select new { c.CustomerId, c.CompanyName })
                            .Distinct()
                            .ToList();

            cmbCustomers.DataSource = customers;
            cmbCustomers.DisplayMember = "CompanyName";
            cmbCustomers.ValueMember = "CustomerId";
            cmbCustomers.Enabled = customers.Count > 0;

            cmbOrders.DataSource = null;
            cmbOrders.Enabled = false;
            lstOrderLines.Items.Clear();
            lstOrderLines.Enabled = false;
            lblTotal.Text = "—";
        }

        private void cmbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbProducts.SelectedValue is int productId)) return;
            if (!(cmbCustomers.SelectedValue is string custId)) return;

            var orders = (from od in _db.OrderDetails
                          join o in _db.Orders on od.OrderId equals o.OrderId
                          where od.ProductId == productId && o.CustomerId == custId
                          orderby o.OrderId
                          select new { o.OrderId })
                         .Distinct()
                         .ToList();

            cmbOrders.DataSource = orders;
            cmbOrders.DisplayMember = "OrderId";
            cmbOrders.ValueMember = "OrderId";
            cmbOrders.Enabled = orders.Count > 0;

            lstOrderLines.Items.Clear();
            lstOrderLines.Enabled = false;
            lblTotal.Text = "—";
        }

        private void cmbOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbOrders.SelectedValue is int orderId)) return;

            var lines = (from od in _db.OrderDetails
                         join p in _db.Products on od.ProductId equals p.ProductId
                         where od.OrderId == orderId
                         select new
                         {
                             p.ProductName,
                             od.Quantity,
                             od.UnitPrice,
                             od.Discount,
                             LineTotal = (decimal)od.Quantity * od.UnitPrice * (decimal)(1 - od.Discount)
                         })
                         .ToList();

            lstOrderLines.Items.Clear();
            lstOrderLines.Enabled = true;

            lstOrderLines.Items.Add($"{"Termék",-35} {"Menny.",7} {"Egységár",10} {"Összesen",12}");
            lstOrderLines.Items.Add(new string('—', 70));

            foreach (var x in lines)
                lstOrderLines.Items.Add($"{x.ProductName,-35} {x.Quantity,7} {x.UnitPrice,10:C2} {x.LineTotal,12:C2}");

            lblTotal.Text = lines.Sum(x => x.LineTotal).ToString("C2");
        }

        private void WireEvents()
        {
            cmbProducts.SelectedIndexChanged += cmbProducts_SelectedIndexChanged;
            cmbCustomers.SelectedIndexChanged += cmbCustomers_SelectedIndexChanged;
            cmbOrders.SelectedIndexChanged += cmbOrders_SelectedIndexChanged;
        }
    }
}
