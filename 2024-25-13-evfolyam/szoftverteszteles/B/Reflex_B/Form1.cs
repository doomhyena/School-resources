using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reflex_B
{
	public partial class Form1 : Form
	{
		static Random rnd = new Random();
		Stopwatch stopwatch;
		public Form1()
		{
			stopwatch = new Stopwatch();
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void btn_Start_Click(object sender, EventArgs e)
		{
			//click gomb láthatóságának kikapcsolása
			btn_Click.Visible = false;
			//click gomb engedélyezése
			btn_Click.Enabled = true;
			//start gomb kikapcsolása
			btn_Start.Enabled = false;
			// gomb elhelyezés
			btn_Click.Location = new Point()
			{
				X = rnd.Next(pnl_Game.ClientSize.Width - btn_Click.Width),
				Y = rnd.Next(pnl_Game.ClientSize.Height - btn_Click.Height)
			};
			timer1.Interval = rnd.Next(1500, 6000);
			timer1.Start();
		}

		private void btn_Click_Click(object sender, EventArgs e)
		{
			stopwatch.Stop();
			lbx_Results.Items.Add(String.Format($"{stopwatch.ElapsedMilliseconds:N0} ms"));
			btn_Start.Enabled = true;
			btn_Click.Enabled = false;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			// gomb bekapcsolás
			btn_Click.Visible = true;
			// mérés indítása
			stopwatch.Restart();
		}

		private void pnl_Game_MouseEnter(object sender, EventArgs e)
		{
			if (!btn_Click.Visible)
			{
				//csalás esete
				timer1.Stop();
				btn_Click.Visible = true;
				btn_Click.Enabled = false;
				lbx_Results.Items.Add("Csalás történt");
				btn_Start.Enabled = true;
			}
		}

		private void pnl_Game_MouseMove(object sender, MouseEventArgs e)
		{
			
		}
	}
}
