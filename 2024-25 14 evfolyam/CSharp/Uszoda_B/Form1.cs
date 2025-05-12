using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uszoda_B.Models;
using Automata_2024_B.Models;

namespace Uszoda_B
{
	public partial class Form1 : Form
	{
		static Random rnd = new Random();
		int failCounter;
		Uszoda uszoda;
		Automata a1;
		public Form1()
		{
			InitializeComponent();
			uszoda = new Uszoda(100, 50, Update_GUI);
			CreateStoragesGUI();
			failCounter = 0;
		}

		private void CreateStoragesGUI()
		{
			foreach (var st in uszoda.Storages)
			{
				switch (st.Type)
				{
					case StorageType.Box:
						flp_Box.Controls.Add(st.Label);
						break;
					case StorageType.Cabine:
						flp_Cabine.Controls.Add(st.Label);
						break;
					default:
						break;
				}
			}
		}
		private void btn_Start_Click(object sender, EventArgs e)
		{
			tmr_CreatePerson.Interval = rnd.Next(1000, 4000);
			tmr_CreatePerson.Start();
			tmr_useAutomata.Interval = rnd.Next(5000, 10000);
			tmr_useAutomata.Start();

		}
		private void btn_Stop_Click(object sender, EventArgs e)
		{
			tmr_CreatePerson.Stop();
		}
		private void tmr_CreatePerson_Tick(object sender, EventArgs e)
		{
			tmr_CreatePerson.Stop();
			CreatePerson();
			tmr_CreatePerson.Interval = rnd.Next(1000, 4000);
			tmr_CreatePerson.Start();
		}
		private void CreatePerson()
		{
			Person p = new Person(rnd.Next(2500, 10000), new Wallet()
			{
				_5 = rnd.Next(10),
				_10 = rnd.Next(8),
				_20 = rnd.Next(6),
				_50 = rnd.Next(5),
				_100 = rnd.Next(3),
				_200 = rnd.Next(2),
			});
			p.Buy_Ticket(uszoda);
			if (p.Ticket != null)
			{
				uszoda.Enter(p);
			}
			else
			{
				failCounter++;
			}
			Update_GUI();
		}
		public void Update_GUI()
		{
			tbx_People.Text = uszoda.PeopleCount.ToString();
			tbx_Box.Text = uszoda.BoxCount.ToString();
			tbx_Cabine.Text = uszoda.CabineCount.ToString();
			tbx_Fail.Text = failCounter.ToString();
			tbx_Leave.Text = uszoda.LeaveCount.ToString();
			tbx_Tickets.Text = uszoda.TicketCounter.ToString();

			#region Productlist
			lbx_Products.Items.Clear();
			foreach (var item in uszoda.MyAutomata.products)
			{
				lbx_Products.Items.Add(string.Format($"{item.Value,3} - {item.Key.Name}"));
			}
			#endregion

			#region Coins
			lbx_Coins.Items.Clear();
			lbx_Coins.Items.Add($"  5 - {uszoda.MyAutomata.mainWallet._5}");
			lbx_Coins.Items.Add($" 10 - {uszoda.MyAutomata.mainWallet._10}");
			lbx_Coins.Items.Add($" 20 - {uszoda.MyAutomata.mainWallet._20}");
			lbx_Coins.Items.Add($" 50 - {uszoda.MyAutomata.mainWallet._50}");
			lbx_Coins.Items.Add($"100 - {uszoda.MyAutomata.mainWallet._100}");
			lbx_Coins.Items.Add($"200 - {uszoda.MyAutomata.mainWallet._200}");
			#endregion
		}

		private void tmr_useAutomata_Tick(object sender, EventArgs e)
		{
			if (uszoda.PeopleCount > 0)
			{
				tmr_useAutomata.Stop();
				if (rnd.Next(2) == 1)
				{
					uszoda.People[rnd.Next(uszoda.People.Count)].Hungry = true;
				}
				else
				{
					uszoda.People[rnd.Next(uszoda.People.Count)].Thirsty = true;
				}
				tmr_useAutomata.Interval = rnd.Next(5000, 10000);
				tmr_useAutomata.Start();
			}
		}
	}

	public class MyLabel : Label
	{
		private bool free;

		public int ID { get; }
		public bool Free
		{
			get => free;
			set
			{
				free = value;
				if (free)
				{
					BackColor = Color.Green;
				}
				else
				{
					BackColor = Color.Red;
				}
				//BackColor = free ? Color.Green : Color.Red;
			}
		}

		public MyLabel(int _id)
		{
			ID = _id;
			Free = true;
			AutoSize = false;
			Width = 10;
			Height = 10;
			Margin = new Padding(2);
		}
	}
}
