using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_A
{
	interface IActor
	{
		Position Pos { get; }
		Position TempPos { get; }
		bool UpdateRequired { get; set; }
		Direction Dir { get; }
		GameObject MyType { get; }
		void Move(Position _nP);
		Position NextStep(Direction _dir);
		void ChangeDirection(Direction _dir);
	}
}
