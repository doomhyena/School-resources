using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lift_2024_B.Models
{
	public class Elevator
	{
		private Level[] levels;
		public int Capacity { get; }
		public int ActualLevel { get; set; }
		public State State { get; private set; }
		public List<Person> People { get; set; }
		public List<int> Destinations { get; private set; }
		private Timer tmrMove, tmrWait;
		private Action RefreshForm;

		public Elevator(Level[] _levels)
		{
			levels = _levels;
			People = new List<Person>();
			Destinations = new List<int>();
			Capacity = 8;
			tmrMove = new Timer() { Interval = 1000 };
			tmrMove.Tick += TmrMove_Tick;
			tmrWait = new Timer() { Interval = 1000 };
			tmrWait.Tick += TmrWait_Tick;
		}

		public void Set_RefreshForm(Action _action)
		{
			RefreshForm = _action;
		}
		private void TmrWait_Tick(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
		private void TmrMove_Tick(object sender, EventArgs e)
		{
			tmrMove.Stop();
			if (Destinations.Count > 0)
			{
				if (Destinations.First() == ActualLevel)
				{
					State = State.Stop;
					Destinations.Remove(Destinations.First());
					Leave();
					Enter();
				}
				else
				{
					Move();
				}
				tmrMove.Start();
			}
		}
		public void Start()
		{
			tmrMove.Start();
		}
		private void Enter()
		{
			foreach (var person in levels[ActualLevel].People.Where(p => !p.IsWait).ToList())
			{
				if (People.Count < Capacity)
				{
					levels[ActualLevel].People.Remove(person);
					People.Add(person);
					AddNewDestination(person.Destination);
				}
			}
			if (levels[ActualLevel].People.Count(p => !p.IsWait) == 0)
			{
				levels[ActualLevel].IsCalling = false;
			}
			RefreshForm();
		}
		private void Leave()
		{
			foreach (var person in People.Where(p => p.Destination == ActualLevel).ToList())
			{
				People.Remove(person);
				if (ActualLevel != 0)
				{
					levels[ActualLevel].People.Add(person);
					person.Waiting(levels[ActualLevel]);
				}
			}
			RefreshForm();
		}
		public void Call(int _level)
		{
			if (State == State.Stop)
			{
				if (_level == ActualLevel)
				{
					Enter();
				}
				else
				{
					AddNewDestination(_level);
				}

				if (!tmrWait.Enabled)
				{
					Start();
				}
			}
			else
			{
				AddNewDestination(_level);
			}
		}
		private void AddNewDestination(int level)
		{
			if (!Destinations.Contains(level))
			{
				Destinations.Add(level);
			}
		}
		private void Move()
		{
			if (Destinations.Count > 0)
			{
				if (Destinations.First() > ActualLevel)
				{
					ActualLevel++;
					State = State.MoveUp;
				}
				else
				{
					ActualLevel--;
					State = State.MoveDown;
				}
				if (RefreshForm != null)
				{
					RefreshForm();
				}
			}
		}
	}

	public enum State { Stop, MoveUp, MoveDown }
}
