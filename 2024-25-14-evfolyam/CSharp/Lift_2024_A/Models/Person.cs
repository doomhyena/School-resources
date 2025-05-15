using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace Lift_2024_A.Models
{
	public class Person
	{
		static Random rnd = new Random();
		static int id = 1000;
		public static int maxLevel = 0;

		Timer timer;
		public int ID { get; }
		public int ActualLevel { get; set; }
		public int Target { get; private set; }
		public bool IsWait { get; private set; }
		private Action<int> Call;

		public Person(Action<int> _call)
		{
			ID = id++;
			ActualLevel = 0;
			Target = rnd.Next(Person.maxLevel + 1);
			Call = _call;
			timer = new Timer();
			timer.Tick += Timer_Tick;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			timer.Stop();
			IsWait = false;
			Target = rnd.Next(Person.maxLevel + 1);
			Call(ActualLevel);
		}

		public void Waiting(int level)
		{
			ActualLevel = level;
			IsWait = true;
			timer.Interval = rnd.Next(10000, 20000);
			timer.Start();
		}

		
	}
}
