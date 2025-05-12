using Lift_2024_A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Lift_2024_A
{
	public class Simulator
	{
		static Random rnd = new Random();
		int levels;
		Building building;
		Person newPerson;
		Display display;
		Timer personGeneratorTimer;


		public Simulator(int _levels)
		{
			levels = _levels;
			display = new Display(levels);
			building=new Building(levels,display);
			personGeneratorTimer = new Timer() {Interval=1 };
			personGeneratorTimer.Tick += PersonGeneratorTimer_Tick;
		}

		private void PersonGeneratorTimer_Tick(object sender, EventArgs e)
		{
			personGeneratorTimer.Stop();
			GeneratePerson();
			display.Update_GUI(building);
			personGeneratorTimer.Interval = rnd.Next(500, 1500);
			personGeneratorTimer.Start();
		}

		private void GeneratePerson()
		{
			newPerson = new Person(building.Elevator.Call);
			building.Levels[0].People.Add(newPerson);
			building.Levels[0].IsCalling = true;
		}

		public void Start()
		{
			personGeneratorTimer.Start();
			display.ShowDialog();
		}
	}
}
