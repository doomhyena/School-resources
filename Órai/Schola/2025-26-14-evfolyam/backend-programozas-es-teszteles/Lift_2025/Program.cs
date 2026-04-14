using Lift_2025.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lift_2025
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			IUi display = new Display(10);
			
			new Simulator(10,display).Start();
			((Display)display).ShowDialog();
		}
	}
}
