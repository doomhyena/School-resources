using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Lift_2025.Models
{
	public partial class Display : Form, IUi
	{

		int maxLevel;

		TextBox tbx_TotalInBuilding;
		TextBox tbx_WaitingTotal;
		TextBox tbx_LeftCount;

		public Display(int _maxLevel)
		{
			maxLevel = _maxLevel;
			InitializeComponent();
			trb_Levels.Maximum = maxLevel;
			Init_Levels();

			var labelX = label4.Left;
			var textboxX = tbx_InElevator.Left;
			var currentY = tbx_InElevator.Bottom + 10;

			var lblTotal = new Label
			{
				Text = "Total in bldg:",
				Location = new Point(labelX, currentY + 6), 
				AutoSize = true,
				Font = label4.Font,
				ForeColor = label4.ForeColor
			};
			tbx_TotalInBuilding = new TextBox
			{
				Location = new Point(textboxX, currentY),
				Size = tbx_InElevator.Size,
				ReadOnly = true,
				Font = tbx_InElevator.Font,
				TextAlign = HorizontalAlignment.Center
			};

			currentY += tbx_InElevator.Height + 8;

			var lblWaiting = new Label
			{
				Text = "Waiting total:",
				Location = new Point(labelX, currentY - 4),
				AutoSize = true,
				Font = label4.Font,
				ForeColor = label4.ForeColor
			};
			tbx_WaitingTotal = new TextBox
			{
				Location = new Point(textboxX, currentY),
				Size = tbx_InElevator.Size,
				ReadOnly = true,
				Font = tbx_InElevator.Font,
				TextAlign = HorizontalAlignment.Center
			};

			currentY += tbx_InElevator.Height + 8;

			var lblLeft = new Label
			{
				Text = "Left building:",
				Location = new Point(labelX, currentY - 4),
				AutoSize = true,
				Font = label4.Font,
				ForeColor = label4.ForeColor
			};
			tbx_LeftCount = new TextBox
			{
				Location = new Point(textboxX, currentY),
				Size = tbx_InElevator.Size,
				ReadOnly = true,
				Font = tbx_InElevator.Font,
				TextAlign = HorizontalAlignment.Center
			};

			Controls.Add(lblTotal);
			Controls.Add(tbx_TotalInBuilding);
			Controls.Add(lblWaiting);
			Controls.Add(tbx_WaitingTotal);
			Controls.Add(lblLeft);
			Controls.Add(tbx_LeftCount);
		}
		private void Init_Levels()
		{
			for (int i = maxLevel; i >= 0; i--)
			{
				lbx_Levels.Items.Add($"{i,2} | {0}");
			}

		}
		
		void IUi.UpdateElevator(int actualLevel, int targetLevel, State state, IReadOnlyList<Person> peopleInElevator, IReadOnlyList<int> program)
		{
			trb_Levels.Value = actualLevel;
			switch (state)
			{
				case State.Stop:
					lbl_Level.Text = $"-- {actualLevel} --";
					break;
				case State.MoveUp:
					lbl_Level.Text = $"▲▲ {actualLevel} ▲▲";
					break;
				case State.MoveDown:
					lbl_Level.Text = $"▼▼ {actualLevel} ▼▼";
					break;
				default:
					break;
			}
			
			tbx_Destination.Text = targetLevel.ToString();

			tbx_InElevator.Text = peopleInElevator.Count.ToString();

			lbx_Program.Items.Clear();
			lbx_Program.Items.AddRange(program.Select(i => i.ToString()).ToArray());
		}

		void IUi.UpdateLevels(IReadOnlyList<Level> l)
		{
			lbx_Levels.Items.Clear();

			for (int i = l.Count - 1; i >= 0; i--)
			{
				lbx_Levels.Items.Add($"{i,2} | {l[i].People.Count} | {l[i].People.Count(p => p.IsWait)} | {l[i].People.Count(p => !p.IsWait)}");
			}
		}

		void IUi.UpdateStats(int totalInBuilding, int 
			inElevator, int waitingForElevator, int leftCount)
		{
			tbx_TotalInBuilding.Text = totalInBuilding.ToString();
			tbx_WaitingTotal.Text = waitingForElevator.ToString();
			tbx_LeftCount.Text = leftCount.ToString();
		}
	}
}