using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20250331___Winforms
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			Load_Categories();
		}

		private void Load_Categories()
		{
			lbx_Categories.DisplayMember = "CategoryName";
			lbx_Categories.ValueMember = "CategoryID";
			try
			{
				using (NorthWind_2025Entities db = new NorthWind_2025Entities())
				{
					//lbx_Categories.Items.AddRange(db.Categories.ToArray());
					lbx_Categories.DataSource = db.Categories.ToList();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void lbx_Categories_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (int.TryParse(lbx_Categories.SelectedValue.ToString(), out int categoryID))
			{
				flp_Products.Controls.Clear();
				try
				{
					using (NorthWind_2025Entities db = new NorthWind_2025Entities())
					{
						foreach (var product in db.Products.Where(p => p.CategoryID == categoryID))
						{
							flp_Products.Controls.Add(new Label() { Text = product.ProductName, BackColor=Color.Aqua });
						}
					}
				}
				catch (Exception)
				{

					throw;
				}
			}
		}
	}
}
