using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class Employee
    {
        private string _firstName; //field , backing field

        public string FirstName //Property
        {
            get
            {
                return _firstName;
            }

            set { _firstName = value; }
        }

        public string MiddleName { get; set; } //Auto-Property

        public string LastName { get; set; }

        public string FullName => string.IsNullOrEmpty(MiddleName) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";

        public Employee()
        {

        }

        //Constructor
        public Employee(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Employee(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public void SayHello()//method
        {
            Console.WriteLine($"Hello {FullName}");
        }
    }
}
