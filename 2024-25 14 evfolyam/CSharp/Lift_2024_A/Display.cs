using Lift_2024_A.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lift_2024_A
{
	public partial class Display : Form
	{
		public Display(int maxlevel)
		{
			InitializeComponent();
			trackBar1.Maximum = maxlevel;
		}

		public void Update_GUI(Building _building)
		{
			trackBar1.Value=_building.Elevator.ActualLevel;
			tbx_Sum.Text=_building.Levels.Sum(q=>q.People.Count).ToString();
			tbx_Ele.Text=_building.Elevator.People.Count.ToString();
			tbx_Leave.Text=_building.Elevator.LeaveCounter.ToString();
		}

		private void Display_Load(object sender, EventArgs e)
		{

		}
	}
}
