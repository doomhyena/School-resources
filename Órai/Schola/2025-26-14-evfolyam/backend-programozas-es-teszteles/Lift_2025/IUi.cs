using Lift_2025.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift_2025
{
	public interface IUi
	{
		void UpdateElevator(int actualLevel, int targetLevel, State state, IReadOnlyList<Person> peopleInElevator, IReadOnlyList<int> program);
		void UpdateLevels(IReadOnlyList<Level> levels);
		void UpdateStats(int totalInBuilding, int inElevator, int waitingForElevator, int leftCount);
	}
}
