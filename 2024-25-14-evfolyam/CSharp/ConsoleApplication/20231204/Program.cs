using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20231204
{
			internal class Program
			{
						static void Main(string[] args)
						{
									A a1 = new A("Zénó");
									a1.WriteName();
									A a2 = a1.Copy();
									a1.name = "Abigél";
									a2.WriteName();
									//--------------------
									Console.WriteLine("- VÉGE -");
									Console.ReadKey();
						}
			}

			public class A
			{
						public string name;

						public A(string _name)
						{
									name = _name;
						}
						public void WriteName()
						{
									Console.WriteLine(name);
						}

						public A Copy()
						{
									return new A(name);
						}
			}
}
