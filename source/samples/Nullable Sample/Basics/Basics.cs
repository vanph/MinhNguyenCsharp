
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basics
{
    internal class NullableBasics
    {
        static void DisplayValue(int? num)
        {
            if (num.HasValue == true)
            {
                Console.WriteLine("num = " + num);
            }
            else
            {
                Console.WriteLine("num = null");
            }

            // num.Value throws an InvalidOperationException if num.HasValue is false
            try
            {
                Console.WriteLine("value = {0}", num.Value);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main()
        {
            //DisplayValue(1);
            //DisplayValue(null);

            var employee7 = new Employee { EmployeeID = 7, BirthDate = DateTime.Now.AddYears(-20), LastName = "King", FristName = "Robert", Title = "Sales Representative", TitleOfCourtesy = "Mr.",  Address = "Edgeham HollowWinchester Way", City = "London", Region = "", PostalCode = "RG1 9SP", Country = "UK", HomePhone = "(71) 555-5598", PhotoPath = "http://accweb/emmployees/davolio.bmp" };
            var employee8 = new Employee { EmployeeID = 8, LastName = "Callahan", FristName = "Laura", Title = "Inside Sales Coordinator", TitleOfCourtesy = "Ms.",  Address = "4726 - 11th Ave. N.E.", City = "Seattle", Region = "WA", PostalCode = "98105", Country = "USA", HomePhone = "(206) 555-1189", PhotoPath = "http://accweb/emmployees/davolio.bmp" };
            var employee9 = new Employee { EmployeeID = 9, LastName = "Dodsworth", FristName = "Anne", Title = "Sales Representative", TitleOfCourtesy = "Ms.",  Address = "7 Houndstooth Rd.", City = "London", Region = " ", PostalCode = "WG2 7LT", Country = "UK", HomePhone = "(71) 555-4444", PhotoPath = "http://accweb/emmployees/davolio.bmp" };

            var employees = new List<Employee> { employee7, employee8, employee9 };

            foreach (var emp in employees)
            {
                emp.ShowBirthDate();
            }
            Console.ReadLine();
        }
    }
}
