using Lift_2024_B.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lift_2024_B
{
	public partial class Dashboard : Form
	{
		private Building building;
		public Dashboard(Building _building)
		{
			building = _building;
			InitializeComponent();
			trb_Levels.Maximum = building.Levels.Length-1;
		}

		public void RefreshForm()
		{
			trb_Levels.Value = building.Elevator.ActualLevel;
			//------------------------
			string labelTXT = "";
			switch (building.Elevator.State)
			{
				case State.Stop:
					labelTXT = string.Format($"-- | {building.Elevator.ActualLevel,2} | --");
					break;
				case State.MoveUp:
					labelTXT = string.Format($"▲▲ | {building.Elevator.ActualLevel,2} | ▲▲");
					break;
				case State.MoveDown:
					labelTXT = string.Format($"▼▼ | {building.Elevator.ActualLevel,2} | ▼▼");
					break;
				default:
					break;
			}
			lbl_State.Text = labelTXT;
			//-------------------------------------
			string itemTXT = "";
			Level level;
			lbx_People.Items.Clear();
			for (int i = building.Levels.Length-1; i >= 0; i--)
			{
				level = building.Levels[i];
				itemTXT = string.Format($"{level.ID,2} : {level.People.Count(p => p.IsWait),3} : {level.People.Count(p => !p.IsWait)}");
				lbx_People.Items.Add(itemTXT);
			}

		}
	}
}
