using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class TestClass
    {
        private readonly int _year;


        public TestClass()
        {
            _year = 100;
        }

        public void Print()
        {
            // Common.PageSize = 100; => Error
            Console.WriteLine($"Page size setting:{Common.PageSize}");
            Common.DelayTimeInMinutes = 60;
            Console.WriteLine($"Delay:{Common.DelayTimeInMinutes}");
        }
    }
}
