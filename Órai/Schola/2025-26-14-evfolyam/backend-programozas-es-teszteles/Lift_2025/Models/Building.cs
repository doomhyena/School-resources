using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift_2025.Models
{
	internal class Building
	{
		public int MaxLevel { get; }
		
		public Level[] Levels { get; private set; }
		public Elevator Elevator { get; private set; }

		public Building(int _levels)
		{
			MaxLevel = _levels;			
			Levels = new Level[MaxLevel + 1];
			Elevator = new Elevator(Levels);
			InitLevels();
		}


		private void InitLevels()
		{
			for (int i = 0; i < Levels.Length; i++)
			{
				Levels[i] = new Level(i, Elevator.Call);
			}
		}
	}
}
