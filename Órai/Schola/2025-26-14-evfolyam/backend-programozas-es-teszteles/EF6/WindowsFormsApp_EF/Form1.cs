using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DATA_NW;

namespace WindowsFormsApp_EF
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();			
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			cbx_Categories.DisplayMember = "CategoryName";
			cbx_Categories.ValueMember = "CategoryID";
			cbx_Categories.Text = "-- Válassz --";
			cbx_Categories.Items.AddRange(DAL.Get_Categories().ToArray());
		}
	}
}
