using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Dog:Animal
    {
        public Dog(string name, decimal weight) : base(name)
        {
            Weight = weight;
        }

        public void ShowWeight()
        {
            Console.WriteLine($"The {Name} has weight:{Weight} kg");
        }

        protected override void SayHello()
        {
            Console.WriteLine("gâu gâu ");
        }
    }
}
