using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Homework
{
    public class Calculation
    {
        public int SumMultiplesOf3Or5(int n)
        {
            var sum = 0;

            for (var i = 0; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum = sum + i;
                }
            }

            return sum;
        }
    }
}
