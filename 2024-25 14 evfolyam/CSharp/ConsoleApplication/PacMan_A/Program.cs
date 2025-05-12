using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan_A
{
	internal class Program
	{
		static void Main(string[] args)
		{
			new GameManager(new Size() { W = 40, H = 20 }).Start();

			Console.ReadKey();
		}
	}
}
