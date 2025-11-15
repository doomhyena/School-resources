using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2025
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.CursorVisible = false;

			Control c = new Control(new Size(80, 30));
			c.Run();						
		}
	}
}
