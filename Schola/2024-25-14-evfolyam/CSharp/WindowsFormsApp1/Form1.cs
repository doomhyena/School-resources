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
		Form2 f2;
		Data data;
		public Form1(Data _data)
		{
			data = _data;
			data.Form1_Update = F1_Update;
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			data.Form1_TBX = textBox1.Text;
			if (f2 is null)
			{
				f2 = new Form2(data);				
			}
			f2.Show();
		}

		public void F1_Update()
		{
			textBox2.Text = data.Form2_TBX;
		}
	}
}
