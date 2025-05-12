using Automata_DLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uszoda.Models;

namespace Uszoda
{
	public partial class Form1 : Form
	{
		static Random rnd = new Random();
		Models.Uszoda uszoda;
		int failCounter;

		public Form1()
		{
			InitializeComponent();
			uszoda = new Models.Uszoda(100, 50, Refresh_UX);
			personGenTimer.Interval = rnd.Next(1000, 3000);
			failCounter = 0;
			CreateStorages();
		}

		private void CreateStorages()
		{
			MyLabel ml;
			foreach (Storage storage in uszoda.Storages)
			{
				ml = new MyLabel() { Free = true, ID = storage.ID };
				switch (storage.Type)
				{
					case TicketType.Box:
						pnl_Box.Controls.Add(ml);
						break;
					case TicketType.Cabine:
						pnl_Cabine.Controls.Add(ml);
						break;
					default:
						break;
				}
			}
		}

		private void personGenTimer_Tick(object sender, EventArgs e)
		{
			personGenTimer.Stop();
			CreateNewPerson();
			personGenTimer.Start();
		}

		private void CreateNewPerson()
		{
			Wallet wallet = new Wallet()
			{
				_5 = rnd.Next(8),
				_10 = rnd.Next(6),
				_20 = rnd.Next(5),
				_50 = rnd.Next(4),
				_100 = rnd.Next(2),
				_200 = rnd.Next(2),

			};
			Person p = new Person(rnd.Next(500, 3000), wallet, rnd.Next(10000, 20000));
			p.BuyTicket(uszoda);
			if (p.Ticket != null)
			{
				p.Enter(uszoda);
			}
			else
			{
				failCounter++;
			}
			Refresh_UX();
		}

		public void Refresh_UX()
		{
			tbx_People.Text = uszoda.People.Count.ToString();
			tbx_Box.Text = uszoda.People.Count(q => q.Ticket.TicketType == TicketType.Box).ToString();
			tbx_Cabine.Text = uszoda.People.Count(q => q.Ticket.TicketType == TicketType.Cabine).ToString();
			tbx_Fail.Text = failCounter.ToString();
			tbx_Cassa.Text = string.Format($"{uszoda.Tickets.Sum(q => q.Price):C}");
			tbx_Discount.Text = uszoda.Tickets.Count(q => q.Discount).ToString();

			MyLabel ml;
			foreach (Storage stor in uszoda.Storages)
			{
				switch (stor.Type)
				{
					case TicketType.Box:
						ml = pnl_Box.Controls.Cast<MyLabel>().First(q => q.ID == stor.ID);
						if (ml.Free != stor.Free)
						{
							ml.Free = stor.Free;
						}
						break;
					case TicketType.Cabine:
						ml = pnl_Cabine.Controls.Cast<MyLabel>().First(q => q.ID == stor.ID);
						if (ml.Free != stor.Free)
						{
							ml.Free = stor.Free;
						}
						break;
					default:
						break;
				}
			}

			lbx_Products.Items.Clear();
			foreach (var p in uszoda.MyAutomata.Products)
			{
				lbx_Products.Items.Add(String.Format($"{p.Key.Name,-20}{p.Key.Price,6:C0}{p.Value,3}"));
			}
			Wallet wallet = uszoda.MyAutomata.Get_MainWallet();
			tbx_Coin_5.Text = wallet._5.ToString();
			tbx_Coin_10.Text = wallet._10.ToString();
			tbx_Coin_20.Text = wallet._20.ToString();
			lbl_10.Text = wallet._50.ToString();
			lbl_100.Text = wallet._100.ToString();
			lblb_200.Text = wallet._200.ToString();
			tbx_CoinsSum.Text = string.Format($"{wallet.Sum:C0}");
		}

		private void btn_Start_Click(object sender, EventArgs e)
		{
			personGenTimer.Start();
			tmr_UseAutomata.Start();
		}

		private void tmr_UseAutomata_Tick(object sender, EventArgs e)
		{
			tmr_UseAutomata.Stop();
			int count = 1;// uszoda.People.Count < 6 ? 2 : rnd.Next(3, uszoda.People.Count / 2);
			ProductType pt;
			if (uszoda.People.Count > 1)
			{
				for (int i = 0; i < count; i++)
				{
					pt = rnd.Next(2) == 0 ? ProductType.Food : ProductType.Drink;
					switch (pt)
					{
						case ProductType.Food:
							uszoda.People[rnd.Next(uszoda.People.Count)].Hungry = true;
							break;
						case ProductType.Drink:
							uszoda.People[rnd.Next(uszoda.People.Count)].Thirsty = true;
							break;
						default:
							break;
					}
				}
			}
			tmr_UseAutomata.Start();
		}
	}

	public enum TicketType { Box, Cabine }

	public class MyLabel : Label
	{
		public int ID { get; set; }
		private bool free;
		public bool Free
		{
			get
			{ return free; }
			set
			{
				free = value;
				BackColor = free ? Color.Green : Color.Red;
			}
		}

		public MyLabel()
		{
			AutoSize = false;
			Width = 10;
			Height = 10;
			Margin = new Padding(5, 5, 5, 5);
		}
	}
}
