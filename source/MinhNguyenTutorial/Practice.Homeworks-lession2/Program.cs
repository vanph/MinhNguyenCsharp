using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Homeworks_lession2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task();
            Console.ReadLine();
        }

        private static void Task()
        {
            Console.WriteLine("Employee List :");
            var employees = GetEmployee();
            PrintEmployee(employees);
            

        }
        private static List<Employee> GetEmployee() {
           
            var employee1 = new Employee { EmployeeID = 1 , LastName= "Davolio" , FristName= "Nancy",Title= "Sales Representative",TitleOfCourtesy="Ms.",BirthDate= "1948-12-08 0:00:00" ,Address= "507 - 20th Ave. E.Apt. 2A" ,City= "Seattle",Region= "WA" ,PostalCode= "98122",Country= "USA",HomePhone= "(206) 555-9857", PhotoPath= "http://accweb/emmployees/davolio.bmp" };
            var employee2 = new Employee { EmployeeID = 2, LastName = "Davolio", FristName = "Nancy", Title = "Sales Representative", TitleOfCourtesy = "Ms.", BirthDate = "1948-12-08 0:00:00", Address = "507 - 20th Ave. E.Apt. 2A", City = "Seattle", Region = "WA", PostalCode = "98122", Country = "USA", HomePhone = "(206) 555-9857", PhotoPath = "http://accweb/emmployees/davolio.bmp" };
            var employees = new List<Employee> { employee1, employee2 };

            return employees;
        }


        private     static void PrintEmployee(List<Employee> employees)
        {   
            foreach( var employee in employees)
            {
                Console.WriteLine(employee.GetDetail());
            }
        }
      
    }
}
