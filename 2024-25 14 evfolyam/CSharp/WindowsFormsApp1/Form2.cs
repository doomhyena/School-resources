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
	public partial class Form2 : Form
	{
		Data data;
		public Form2(Data _data)
		{
			data = _data;	
			data.Form2_Update=F2_Update;
			InitializeComponent();
			textBox1.Text = data.Form1_TBX;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			data.Form2_TBX = textBox2.Text;
			data.Form1_Update();
		}

		public void F2_Update()
		{

		}

	}
}
