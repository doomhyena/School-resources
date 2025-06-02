using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
	class Controller
	{
		static Random rnd = new Random();
		public List<Car> Cars { get; set; }
		public int Lane { get; set; }
		int delay;

		public Controller()
		{			
			Cars = new List<Car>();
			Lane = Console.WindowHeight / 2;
			delay = rnd.Next(5, 20);
		}

		internal void Run()
		{
			CarFactory();

			do
			{
				foreach (Car car in Cars.ToList())
				{
					if (car.Position.X < Console.WindowWidth - 2) // léphetünk e még jobbra
					{
						Clear(car); // törlés
						if (car.Speed == 0) // 
						{
							car.Last = car.Position;

							if (car.TakeOver && !Collision(new Position() { X = car.Position.X, Y = Lane })) // visszatérhetünk e az előzésből
							{
								car.Position = new Position() { X = car.Position.X, Y = Lane };
								car.TakeOver = false;
							}

							if (Collision(new Position() {X=car.Position.X+1,Y=car.Position.Y })) //előzünk e
							{
								car.Position = new Position() { X = car.Position.X + 1, Y = Lane - 1 };
								car.TakeOver = true;
							}
							else
							{
								car.Position = new Position() { X = car.Position.X + 1, Y = car.Position.Y };
							}

							Draw(car); // rajzolás

							car.Speed = car.SpeedOrig;
						}
						else
						{
							car.Speed--;
						}
					}
					else
					{
						Cars.Remove(car);
						Clear(car);
						CarFactory();
					}

				}
				if (delay == 0 && Cars.Count < 5)
				{
					CarFactory();
					delay = rnd.Next(2, 10);
				}
				else
				{
					delay--;
				}
				System.Threading.Thread.Sleep(10);
			} while (true);
		}

		private bool Collision(Position p)
		{
			return Cars.Any(c => c.Position.X == p.X && c.Position.Y == p.Y);
		}

		private void Draw(Car car)
		{
			Console.SetCursorPosition(car.Position.X, car.Position.Y);
			Console.ForegroundColor = car.Color;
			Console.Write('█');
		}

		private void CarFactory()
		{
			Car newCar = new Car(Lane);
			Cars.Add(newCar);
		}

		private void Clear(Car car)
		{
			Console.SetCursorPosition(car.Last.X, car.Last.Y);
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Write(' ');
		}
	}
}
