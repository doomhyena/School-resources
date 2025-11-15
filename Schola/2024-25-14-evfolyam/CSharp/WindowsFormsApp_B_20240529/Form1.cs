using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_B_20240529
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void chk_CheckedChanged(object sender, EventArgs e)
		{
			if (this.Controls.Cast<CheckBox>().Count(q=>q.Checked)>2)
			{
				(sender as CheckBox).Checked = false;
			}
		}
	}
}
