using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_DB.Model;

namespace Winform_DB
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Load_Customers();
		}

		private void Load_Customers()
		{
			cbx_Customers.DisplayMember = "CompanyName";
			cbx_Customers.ValueMember = "CustomerID";
			cbx_Customers.Items.AddRange(DAL.Get_Customers().ToArray());
			//cbx_Customers.DataSource = DAL.Get_Customers();
		}

		private void cbx_Customers_SelectionChangeCommitted(object sender, EventArgs e)
		{
			Load_Orders((cbx_Customers.SelectedItem as Customer).CustomerID);
		}

		private void Load_Orders(string v)
		{
			cbx_Orders.Items.Clear();
			cbx_Orders.DisplayMember = "OrderID";
			cbx_Orders.ValueMember = "OrderID";
			cbx_Orders.Items.AddRange(DAL.Get_OrdersByID(v).ToArray());
		}
	}
}
