using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var emp1 = new Employee
            {
                FirstName = "Nguyen",
                MiddleName = "Van",
                LastName = "Minh"
            };
            
            var emp2 = new Employee("Pham", "Van");

            var emp3 = new Employee("Nguyen","Quang", "Hieu");

            //Generic
            var employees = new List<Employee>{emp1, emp2, emp3};

            foreach (var emp in employees)
            {
                ChangeEmployee(emp);
            }

            PrintEmployees(employees);

            //var emp4 = emp1;//reference type
            //emp4.LastName = "Luong";
            //emp1.FirstName = "Tran";
            //emp1.MiddleName = "Anh";

            //employees.Add(emp4);

            //emp1.SayHello(); //Tran Anh Luong
            //emp4.SayHello(); //Tran Anh Luong

            //PrintEmployees(employees);

            //int a ;
            //int b = 15;
            //ChangeValue(a, b);

            //Console.WriteLine(a);//10
            //Console.WriteLine(b);//15

            //ChangeValue2(out a, b);
            //Console.WriteLine(a);
            //Console.WriteLine(b);

            //ChangeValue3(out a, ref b);

            //Console.WriteLine(a);
            //Console.WriteLine(b);

            //int i = 10;
            //long l = (long) i;//casting

            //Console.WriteLine(l);

            var str = "You are handsome";
            Console.WriteLine(str.CoundWord());

            var str2 = "Minh";
            Console.WriteLine(str2.Hello());
           
            Console.WriteLine(6.MultiplyBy(3));

            Console.ReadLine();

        }

        private static void ChangeEmployee(Employee employee)
        {
            employee.LastName = "Test";
        }

        private static void ChangeValue(int a, int b)
        {
            b = b + 1;
            a = b;
        }

        private static void ChangeValue2(out int a, int b)
        {
            b = b + 1;
            a = b;
        }

        private static void ChangeValue3(out int a, ref int b)
        {
            b = b + 1;
            a = b;
        }

        private static void PrintEmployees(List<Employee> employees)
        {
            foreach (var emp in employees)
            {
                emp.SayHello();
            }
        }
    }
}
