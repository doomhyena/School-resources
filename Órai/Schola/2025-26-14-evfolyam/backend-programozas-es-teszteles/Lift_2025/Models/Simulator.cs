using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lift_2025.Models
{
	internal class Simulator
	{
		static Random rnd = new Random();
		Building building;
		Person newPerson;
		Timer tmr_newPeson;
		IUi ui;

		int levels;

		public Simulator(int _levels, IUi _ui)
		{
			ui=_ui;
			levels = _levels;

			building = new Building(levels);
			building.Elevator.Changed += Elevator_Changed;
			tmr_newPeson = new Timer() { Interval = 2000 };
			tmr_newPeson.Tick += Tmr_newPeson_Tick;
		}

		private void Elevator_Changed()
		{
			var el = building.Elevator;
			ui.UpdateElevator(el.ActualLevel, el.Destination, el.State, el.People, el.Program);
			ui.UpdateLevels(building.Levels);

			// compute aggregates
			int inElevator = el.People.Count;
			int onLevels = building.Levels.Sum(l => l.People.Count);
			int totalInBuilding = inElevator + onLevels;
			int waiting = building.Levels.Sum(l => l.People.Count(p => !p.IsWait));
			int left = el.LeftCount;

			ui.UpdateStats(totalInBuilding, inElevator, waiting, left);
		}
		private void Tmr_newPeson_Tick(object sender, EventArgs e)
		{
			tmr_newPeson.Stop();
			GeneratePerson();
			tmr_newPeson.Interval = rnd.Next(1500, 3000);
			tmr_newPeson.Start();
		}

		private void GeneratePerson()
		{
			newPerson = new Person(levels);
			newPerson.SetLevel(building.Levels[0]);
			newPerson.Start();
			System.Diagnostics.Debug.WriteLine($"{newPerson.ID} | {newPerson.TargetLevel}");
			ui.UpdateLevels(building.Levels);
		}

		internal void Start()
		{
			tmr_newPeson.Start();

		}
	}
}
