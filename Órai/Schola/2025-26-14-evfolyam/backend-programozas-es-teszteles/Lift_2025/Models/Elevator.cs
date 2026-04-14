using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lift_2025.Models
{
	internal class Elevator
	{
		Timer tmrMove, tmrWait;
		Level[] levels;
		private int actualLevel;
		private State state;
		private int destination;
		public int ActualLevel
		{
			get => actualLevel;
			private set
			{
				actualLevel = value;
				OnChanged();
			}
		}


		public int Destination
		{
			get => destination;
			private set
			{
				destination = value;
				OnChanged();
			}
		}
		public List<Person> People { get; private set; }
		public int Capacity { get; }
		public State State
		{
			get => state;
			set
			{
				state = value;
				OnChanged();
			}
		}
		public List<int> Program { get; private set; }
		public event Action Changed;

		public int LeftCount { get; private set; }

		public Elevator(Level[] _levels)
		{

			State = State.Stop;
			Program = new List<int>();
			levels = _levels;
			Capacity = 8;
			People = new List<Person>();
			tmrMove = new Timer() { Interval = 500 };
			tmrWait = new Timer() { Interval = 1500 };
			tmrMove.Tick += TmrMove_Tick;
			tmrWait.Tick += TmrWait_Tick;

		}

		private void TmrWait_Tick(object sender, EventArgs e)
		{
			tmrWait.Stop();
			Start();
		}
		private void TmrMove_Tick(object sender, EventArgs e)
		{
			tmrMove.Stop();

			if (Destination == ActualLevel) //megérkeztünk
			{
				State = State.Stop;
				Leave();
				Enter();
			}
			else
			{
				Move();
			}
			tmrMove.Start();
		}
		public void Call(int _level)
		{
			if (State == State.Stop) // lift épp áll
			{
				if (ActualLevel == _level)
				{
					// csak be kell szállítani az embereket
					Enter();
				}
				else
				{
					AddToProgram(_level);
				}
				if (!tmrWait.Enabled)
				{
					Start();
				}
			}
			else // lift épp megy valahová
			{
				AddToProgram(_level);
			}
		}
		private void AddToProgram(int _level)
		{
			if (!Program.Contains(_level) && _level != Destination)
			{
				Program.Add(_level);

			}
		}
		private void Start()
		{
			if (Program.Count > 0)
			{
				Destination = Program.First();
				Program.Remove(Program.First());
				tmrMove.Start();
			}
		}
		private void Enter()
		{
			Person p;
			while (levels[ActualLevel].People.Count(person => !person.IsWait) > 0 && People.Count < Capacity)
			{
				p = levels[ActualLevel].People.Where(person => !person.IsWait).First();
				levels[ActualLevel].People.Remove(p);
				People.Add(p);
				AddToProgram(p.TargetLevel);
			}
			OnChanged();
		}
		private void Leave()
		{
			foreach (var p in People.Where(person => person.TargetLevel == ActualLevel).ToList())
			{
				if (ActualLevel>0)
				{
					p.SetLevel(levels[ActualLevel]);
					People.Remove(p);
					p.Enter();
				}
				else
				{
					People.Remove(p);
					LeftCount++; 
				}
			}
			OnChanged();
		}
		private void Move()
		{
			if (Destination > ActualLevel)
			{
				State = State.MoveUp;
				ActualLevel++;
			}
			else
			{
				State = State.MoveDown;
				ActualLevel--;
			}
			OnChanged();
		}
		private void OnChanged()
		{
			if (Changed!=null)
			{
				Changed.Invoke();
			}
		}

	}
	public enum State { Stop, MoveUp, MoveDown }
}
