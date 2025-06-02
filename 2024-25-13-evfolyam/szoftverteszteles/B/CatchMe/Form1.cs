using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchMe
{
	public partial class Form1 : Form
	{
		static Random rnd = new Random();
		double dist;
		public Form1()
		{
			InitializeComponent();
		}

		private void btn_Escape_Click(object sender, EventArgs e)
		{

		}

		private void btn_Start_Click(object sender, EventArgs e)
		{
			btn_Escape.Location = new Point()
			{
				X = rnd.Next(panel2.Width - btn_Escape.Width),
				Y = rnd.Next(panel2.Height - btn_Escape.Height)
			};
			btn_Escape.Visible = true;
		}

		private void panel2_MouseMove(object sender, MouseEventArgs e)
		{
			dist = Math.Sqrt(
				Math.Pow((e.X - btn_Escape.Location.X), 2) +
				Math.Pow((e.Y - btn_Escape.Location.Y), 2)
								);
			this.Text = String.Format($"Távolság={dist:N2}");

		}
	}
}
