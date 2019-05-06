using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Implementation_Project.Factory
{
    class Class1:NarrowBoat
    {
        public void test()
        {
           Console.WriteLine( base.GetEnumLength().ToString());
        }
    }
}
