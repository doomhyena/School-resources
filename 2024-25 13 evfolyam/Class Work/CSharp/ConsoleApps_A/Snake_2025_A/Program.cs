using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_2025_A
{
    class Program
    {
        static void Main(string[] args)
        {
         Console.CursorVisible = false;

         Controller c = new Controller(new Size(40,25));
         c.Run();

         //---------------------------
         //Console.ReadKey();
        }
    }
}
