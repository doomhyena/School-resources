using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftesThreades
{
    class Lift
    {
        public int emelet;
        public List<int> program;

        public Lift(int e)
        {
            emelet = e;
            program = new List<int>();
        }
    }
}
