using System;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace Inheritance
{
    public class Frog:Animal
    {
        public Frog(string name):base(name)
        {
            
        }

        protected override void SayHello()
        {
            Console.WriteLine("op op");
        }

        public override void Print()
        {
            Console.WriteLine("This is Frog .");
            base.Print();
        }
        
        //Overloading
        public  void Print(string message)
        {
            Console.WriteLine(message);
            base.Print();
        }
    }
}