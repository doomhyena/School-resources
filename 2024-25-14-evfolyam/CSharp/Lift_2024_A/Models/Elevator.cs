using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace Lift_2024_A.Models
{
	public class Elevator
	{
		private Level[] levels;
		public int ActualLevel { get; set; }
		public Direction Dir { get; private set; }
		public List<Person> People { get; set; }
		public List<int> Destinations { get; set; }
		public int LeaveCounter { get; private set; }
		public int Capacity { get; }
		private Timer timerMove, timerWait;
		private Action DataChanged;

		public Elevator(Level[] _levels, Action _dataChanged)
		{
			levels = _levels;
			DataChanged = _dataChanged;
			People = new List<Person>();
			Destinations = new List<int>();
			Capacity = 10;
			timerMove = new Timer() { Interval = 300 };
			timerMove.Tick += TimerMove_Tick; ;
			timerWait = new Timer() { Interval = 900 };
			timerWait.Tick += TimerWait_Tick;
		}

		private void TimerWait_Tick(object sender, EventArgs e)
		{
			timerWait.Stop();
			MoveToNextLevel();
			timerMove.Start();
		}

		private void TimerMove_Tick(object sender, EventArgs e)
		{
			timerMove.Stop();
			if (Destinations.Count > 0)
			{
				if (Destinations.First() == ActualLevel)
				{
					Dir = Direction.Stop;
					Destinations.Remove(Destinations.First());
					Leave();
					Enter();
					DataChanged();
					timerWait.Start();
				}
				else
				{
					MoveToNextLevel();
					timerMove.Start();
				}
			}
		}

		public void Start()
		{
			timerMove.Start();
		}
		private void Enter()
		{
			foreach (var person in levels[ActualLevel].People.Where(q => !q.IsWait).ToList())
			{
				if (People.Count < Capacity)
				{
					People.Add(person);
					levels[ActualLevel].People.Remove(person);
					AddNewDestination(person.Target);
				}
			}
			DataChanged();
		}
		private void Leave()
		{
			foreach (var person in People.Where(q => q.Target == ActualLevel).ToList())
			{
				People.Remove(person);
				if (ActualLevel != 0)
				{
					levels[ActualLevel].People.Add(person);
					person.Waiting(ActualLevel);
				}
				else
				{
					LeaveCounter++;
				}
			}
			DataChanged();
		}
		public void Call(int level)
		{
			if (Dir == Direction.Stop)
			{
				if (level == ActualLevel)
				{
					Enter();
				}
				else
				{
					AddNewDestination(level);
				}

				if (!timerWait.Enabled)
				{
					Start();
				}
			}
			else
			{
				AddNewDestination(level);
			}
		}
		private void AddNewDestination(int level)
		{
			if (!Destinations.Contains(level))
			{
				Destinations.Add(level);
			}
		}
		private void MoveToNextLevel()
		{
			if (Destinations.Count > 0)
			{
				if (Destinations.First() > ActualLevel)
				{
					ActualLevel++;
					Dir = Direction.Up;
				}
				else
				{
					ActualLevel--;
					Dir = Direction.Down;
				}
				DataChanged();
			}
		}

	}

	public enum Direction { Stop, Up, Down }
}
