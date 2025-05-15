using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift_2024_A.Models
{
	public class Building
	{
		int maxLevel;
		public Level[] Levels { get; private set; }
		public Elevator Elevator { get; private set; }
		private Display display;

		public Building(int _maxLevel, Display _display)
		{
			maxLevel = _maxLevel;
			Person.maxLevel = maxLevel;
			Levels = new Level[maxLevel + 1];
			display = _display;
			Elevator=new Elevator(Levels,DataChanged);
			InitLevels();
		}

		private void InitLevels()
		{
			for (int i = 0; i < Levels.Length; i++)
			{
				Levels[i] = new Level(i, Elevator.Call);
			}
		}

		public void DataChanged()
		{
			display.Update_GUI(this);
		}
	}
}
