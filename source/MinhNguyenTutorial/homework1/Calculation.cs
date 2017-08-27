using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Homework
{
    public class Calculation
    {
        // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
       //Find the sum of all the multiples of 3 or 5 below 1000.
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
