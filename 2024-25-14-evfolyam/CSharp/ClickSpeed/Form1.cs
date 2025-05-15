using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickSpeed
{
	public partial class Form1 : Form
	{
		private Data data;
		private static Random rnd = new Random();
		private Stopwatch watch;
		public Form1(Data _data)
		{
			data = _data;
			InitializeComponent();
			watch = new Stopwatch();
		}

		private void btn_Start_Click(object sender, EventArgs e)
		{
			label1.Text = "0";
			timer1.Interval = rnd.Next(5000, 15000);
			timer1.Start();
		}

		private void Start()
		{
			btn_Start.Enabled = false;
			btn_Stop.Location = new Point()
			{
				X = rnd.Next(panel2.ClientSize.Width - btn_Stop.Width),
				Y = rnd.Next(panel2.ClientSize.Height - btn_Stop.Height)
			};
			btn_Stop.Visible = true;
			watch.Start();
		}

		private void btn_Stop_Click(object sender, EventArgs e)
		{
			watch.Stop();
			label1.Text = watch.ElapsedMilliseconds.ToString();
			Reset();
		}

		private void Reset()
		{
			btn_Start.Enabled = true;
			btn_Stop.Visible = false;
			watch.Reset();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			Start();
		}

		private void btn_Start_MouseLeave(object sender, EventArgs e)
		{
			if (!watch.IsRunning)
			{
				MessageBox.Show("Error!");
				Reset();
			}
		}
	}
}
