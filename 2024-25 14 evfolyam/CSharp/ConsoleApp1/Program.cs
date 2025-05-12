using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(Rgb(148, -20, 211));
			Console.ReadKey();
		}
		public static string Rgb(int r, int g, int b)
		{
			if (r > 255) r = 255;
			if (g > 255) g = 255;
			if (b > 255) b = 255;
			
			return BitConverter.ToString(new byte[] { 
				(byte)r,
				(byte)g,
				(byte)b,
			}).Replace("-","");
		}
	}
}
