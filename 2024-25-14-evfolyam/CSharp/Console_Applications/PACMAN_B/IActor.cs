using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN_B
{
	interface IActor
	{
		Position Pos { get; }
		Position TempPos { get; }
		Direction Dir { get; }
		GameObject MyType { get; }
		bool UpdateRequired { get; set; }
		void Move(Position _nP);
		Position NextPosition(Direction _dir);
		void ChangeDirection(Direction _dir);
	}
}
