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

namespace WindowsFormsApp1
{
	public partial class Edit_Form : Form
	{
		public Tuple<bool, Exception> Result { get; private set; }
		Product product;
		public Edit_Form(Product _product)
		{
			product = _product;
			InitializeComponent();
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btn_Save_Click(object sender, EventArgs e)
		{

			decimal.TryParse(tbx_UnitPrice.Text, out decimal unitprice);
			Product p = new Product()
			{
				ProductID = product.ProductID,
				ProductName = tbx_ProductName.Text,
				CategoryID = (cbx_AddPRoductCategories.SelectedItem as Category).CategoryID,
				UnitPrice = unitprice,
				Discontinued = cb_Disconti.Checked
			};

			Result = DAL.Update_Product(p);

			if (Result.Item1)
			{
				MessageBox.Show("Sikeres művelet!");
				Close();
			}
			else
			{
				MessageBox.Show($"Sikertelen művelet!{Environment.NewLine}{Result.Item2.Message}");
			}
		}

		private void Edit_Form_Load(object sender, EventArgs e)
		{
			tbx_ProductName.Text = product.ProductName;
			tbx_UnitPrice.Text = product.UnitPrice.ToString();
			cb_Disconti.Checked = product.Discontinued;
			cbx_AddPRoductCategories.DisplayMember = "CategoryName";
			cbx_AddPRoductCategories.ValueMember = "CategoryID";
			cbx_AddPRoductCategories.DataSource = DAL.Get_Categories();
			cbx_AddPRoductCategories.SelectedValue = product.CategoryID;
		}
	}
}
