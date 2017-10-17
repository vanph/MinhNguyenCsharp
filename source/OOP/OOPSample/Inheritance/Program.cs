using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var dog = new Dog("Meo", 10);
            dog.Print();
            dog.ShowWeight();

            var frog = new Frog("Ëch op");
           frog.Print();

            //var animal = new Animal("Trau");
            //animal.Print();
            
            Console.ReadLine();
        }
    }
}
