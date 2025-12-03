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
	public partial class Form1 : Form
	{
		Edit_Form editForm;
		public int MyProperty { get; set; }
		public Form1()
		{
			InitializeComponent();
			cbx_Categories.DisplayMember = "CategoryName";
			cbx_Categories.ValueMember = "CategoryID";
			cbx_AddPRoductCategories.DisplayMember = "CategoryName";
			cbx_AddPRoductCategories.ValueMember = "CategoryID";
			cbx_Products.DisplayMember = "ProductName";
			cbx_Products.ValueMember = "ProductID";
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			cbx_Categories.Items.AddRange(DAL.Get_Categories().ToArray());
			cbx_AddPRoductCategories.Items.AddRange(DAL.Get_Categories().ToArray());
		}

		private void cbx_Categories_SelectionChangeCommitted(object sender, EventArgs e)
		{
			int catID = (cbx_Categories.SelectedItem as Category).CategoryID;
			System.Diagnostics.Debug.WriteLine($"CatID:{catID}");
			Load_Products(catID);
		}

		private void Load_Products(int catID)
		{
			cbx_Products.DataSource = DAL.Get_Products(catID);
		}

		private void cbx_Products_SelectionChangeCommitted(object sender, EventArgs e)
		{
			int prodID = (int)cbx_Products.SelectedValue;
			System.Diagnostics.Debug.WriteLine($"ProdID:{prodID}");
			Load_ProductDetails(prodID);
		}

		private void Load_ProductDetails(int prodID)
		{
			Product p = DAL.Get_Product(prodID);
			DataTable dt = new DataTable();
			dt.Columns.Add("Property");
			dt.Columns.Add("Value");

			DataRow dr;
			dr = dt.NewRow();
			dr[0] = "Product ID";
			dr[1] = p.ProductID;
			dt.Rows.Add(dr);

			dr = dt.NewRow();
			dr[0] = "Product Name";
			dr[1] = p.ProductName;
			dt.Rows.Add(dr);

			dr = dt.NewRow();
			dr[0] = "Unit Price";
			dr[1] = p.UnitPrice;
			dt.Rows.Add(dr);

			dgw_ProductDetails.DataSource = dt;
		}

		private void Create_Click(object sender, EventArgs e)
		{
			if (cbx_AddPRoductCategories.SelectedIndex > -1 && tbx_ProductName.Text.Length > 5 && decimal.TryParse(tbx_UnitPrice.Text, out decimal unitPrice))
			{
				Product newProduct = new Product()
				{
					ProductName = tbx_ProductName.Text,
					CategoryID = (cbx_AddPRoductCategories.SelectedItem as Category).CategoryID,
					UnitPrice = unitPrice,
					Discontinued = cb_Disconti.Checked
				};
				if (!DAL.Create_Product(newProduct))
				{
					MessageBox.Show("Sikertelen db művelet!");
				}
				else
				{
					MessageBox.Show("Sikeres művelet!");
					tbx_ProductName.Text = tbx_UnitPrice.Text = string.Empty;
					cb_Disconti.Checked = false;
				}

			}
		}

		private void btn_Edit_Click(object sender, EventArgs e)
		{
			if (cbx_Products.SelectedIndex > -1)
			{
				editForm = new Edit_Form(cbx_Products.SelectedItem as Product);				
				editForm.ShowDialog();
			}

		}		
	}
}
