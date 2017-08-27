using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (args != null && args.Length > 0)
            //{
            //    Console.WriteLine("hello " + args[0]);
            //}
            //else
            //{
            //    Console.WriteLine("hello world");
            //}

            int[] numbers = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};

            Console.WriteLine("For each");
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine("For:");
            for (int i = 0; i < numbers.Length; i = i+2)
            {
                Console.WriteLine(numbers[i]);
            }
     

            Console.ReadLine();
        }
    }
}
