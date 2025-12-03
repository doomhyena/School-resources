using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lift_2024_B.Models
{
	public class Person
	{
		private static Random rnd = new Random();
		private static int _id = 1000;
		public static int maxLevel = 0;
		private Timer timer;
		
		public int ID { get; }
		public int ActualLevel { get; private set; }
		public int Destination { get; private set; }
		public bool IsWait { get; private set; }
		private Level level;

		public Person()
		{
			ID = _id++;
			ActualLevel= 0;
			Destination=rnd.Next(Person.maxLevel+1);
			timer=new Timer();
			timer.Tick += Timer_Tick;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			timer.Stop();
			IsWait=false;
			Destination = rnd.Next(Person.maxLevel + 1);
			level.IsCalling= true;
		}
		public void Waiting(Level _level)
		{
			level= _level;
			ActualLevel= _level.ID;
			IsWait = true;
			timer.Interval = rnd.Next(5000, 10000);
			timer.Start();
		}
	}
}
