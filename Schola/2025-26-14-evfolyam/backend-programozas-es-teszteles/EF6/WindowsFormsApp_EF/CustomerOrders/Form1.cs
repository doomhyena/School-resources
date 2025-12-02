using DATA_NW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerOrders
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			cbx_Customers.DisplayMember = "CompanyName";
			cbx_Customers.ValueMember = "CustomerID";
			cbx_Orders.DisplayMember = "OrderID";
			cbx_Orders.ValueMember = "OrderID";
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Load_Customers();
		}

		private void Load_Customers()
		{
			cbx_Customers.DataSource = DAL.Get_Customers();
		}
	}
}
