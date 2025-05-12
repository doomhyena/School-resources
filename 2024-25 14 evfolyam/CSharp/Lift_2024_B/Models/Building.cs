using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift_2024_B.Models
{
	public class Building
	{
		int maxLevel;
		public Level[] Levels { get; private set; }
		public Elevator Elevator { get; private set; }

		public Building(int _maxLevel)
		{
			maxLevel = _maxLevel;
			Levels = new Level[maxLevel + 1];
			Elevator = new Elevator(Levels);
			Init_Levels();
		}

		private void Init_Levels()
		{
			for (int i = 0; i <= maxLevel; i++)
			{
				Levels[i] = new Level(i, Elevator.Call);
			}
		}
	}
}
