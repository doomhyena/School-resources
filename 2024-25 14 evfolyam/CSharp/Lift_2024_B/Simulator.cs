using Lift_2024_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lift_2024_B
{
	internal class Simulator
	{
		static Random rnd = new Random();
		int levelCount;
		Building building;
		Person newPerson;
		Timer timer;
		Dashboard dashboard;

		public Simulator(int _levels)
		{
			levelCount = _levels;
			building = new Building(levelCount);
			dashboard = new Dashboard(building);
			building.Elevator.Set_RefreshForm(dashboard.RefreshForm);
			Person.maxLevel= levelCount;
			timer=new Timer() { Interval=1};
			timer.Tick += Timer_Tick;
			
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			timer.Stop();
			GeneratePerson();
			dashboard.RefreshForm();
			timer.Interval = rnd.Next(2000, 4000);
			timer.Start();
		}

		private void GeneratePerson()
		{
			newPerson=new Person();
			building.Levels[0].People.Add(newPerson);
			building.Levels[0].IsCalling = true;
		}

		public void Start()
		{
			timer.Start();
			dashboard.ShowDialog();
		}
	}
}
