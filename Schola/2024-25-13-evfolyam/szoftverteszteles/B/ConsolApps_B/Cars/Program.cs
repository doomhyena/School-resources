using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program 
    {
        static void Main(string[] args)
        {
         Console.CursorVisible = false;
         //Controller c = new Controller();
         //c.Run();
         new Controller().Run();
         //------------
         Console.ReadKey();
        }
    }
}
