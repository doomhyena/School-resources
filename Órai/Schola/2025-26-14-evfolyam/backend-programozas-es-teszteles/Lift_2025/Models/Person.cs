using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lift_2025.Models
{
	public class Person
	{
		static Random rnd = new Random();
		static int idStart = 1000;
		Timer tmr;
		public int ID { get; }
		public int ActualLevel { get; private set; }
		public int TargetLevel { get; private set; }
		int maxLevel;
		Level level;
		public bool IsWait { get; private set; }

		public Person(int _maxLevel)
		{
			ID = idStart++;
			maxLevel = _maxLevel;
			tmr = new Timer();
			tmr.Tick += Tmr_Tick;
			TargetLevel = rnd.Next(1, maxLevel + 1);
		}

		private void Tmr_Tick(object sender, EventArgs e)
		{
			tmr.Stop();
			IsWait = false;
			do
			{
				TargetLevel = rnd.Next(maxLevel + 1);
			} while (TargetLevel == ActualLevel);
			Start();
		}

		internal void SetLevel(Level _level)
		{
			level = _level;
			level.People.Add(this);
		}

		internal void Start()
		{
			level.CallElevator();
		}

		internal void Enter()
		{
			ActualLevel = level.ID;
			IsWait = true;
			tmr.Interval = rnd.Next(10000, 20000);
			tmr.Start();
		}
	}
}
