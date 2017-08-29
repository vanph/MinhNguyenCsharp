using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EmployeeManagementApp.Model;

namespace EmployeeManagementApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            grdEmployee.AutoGenerateColumns = false;
            var employees = GetEmployees();
            grdEmployee.DataSource = employees;
        }

        private List<Employee> GetEmployees()
        {
            var date = new DateTime(1948, 12, 08);
            var date1 = new DateTime(1952, 02, 19);
            var date2 = new DateTime(1963, 08, 30);
            var date3 = new DateTime(1937, 09, 19);
            var date4 = new DateTime(1955, 03, 04);
            var date5 = new DateTime(1963, 07, 02);
            var date6 = new DateTime(1960, 05, 29);
            var date7 = new DateTime(1958, 01, 09);
            var date8 = new DateTime(1966, 01, 27);

            var employee1 = new Employee { EmployeeID = 1, LastName = "Davolio", FristName = "Nancy", Title = "Sales Representative", TitleOfCourtesy = "Ms.", BirthDate = date, Address = "507 - 20th Ave. E.Apt. 2A", City = "Seattle", Region = "WA", PostalCode = "98122", Country = "USA", HomePhone = "(206) 555-9857", PhotoPath = "http://accweb/emmployees/davolio.bmp" };
            var employee2 = new Employee { EmployeeID = 2, LastName = "Fuller", FristName = "Andrew", Title = "Vice President, Sales", TitleOfCourtesy = "Dr.", BirthDate = date1, Address = "908 W. Capital Way", City = "Tacoma", Region = "WA", PostalCode = "98401", Country = "USA", HomePhone = "(206) 555-9482", PhotoPath = "http://accweb/emmployees/davolio.bmp" };
            var employee3 = new Employee { EmployeeID = 3, LastName = "Leverling", FristName = "Janet", Title = "Sales Representative", TitleOfCourtesy = "Ms.", BirthDate = date2, Address = "722 Moss Bay Blvd.", City = "Kirkland", Region = "WA", PostalCode = "98033", Country = "USA", HomePhone = "(206) 555 - 3412", PhotoPath = "http://accweb/emmployees/fuller.bmp" };
            var employee4 = new Employee { EmployeeID = 4, LastName = "Peacock", FristName = "Margaret", Title = "Sales Representative", TitleOfCourtesy = "Mrs.", BirthDate = date3, Address = "4110 Old Redmond Rd.", City = "Redmond", Region = "WA", PostalCode = "98052", Country = "USA", HomePhone = "(206) 555-8122", PhotoPath = "http://accweb/emmployees/leverling.bmp" };
            var employee5 = new Employee { EmployeeID = 5, LastName = "Buchanan", FristName = "Steven", Title = "Sales Manager", TitleOfCourtesy = "Mr.", BirthDate = date4, Address = "14 Garrett Hill", City = "London", Region = "", PostalCode = "SW1 8JR", Country = "UK", HomePhone = "(71) 555-4848", PhotoPath = "http://accweb/emmployees/peacock.bmp" };
            var employee6 = new Employee { EmployeeID = 6, LastName = "Suyama", FristName = "Michael", Title = "Sales Representative", TitleOfCourtesy = "Mr.", BirthDate = date5, Address = "Coventry HouseMiner Rd.", City = "London", Region = "", PostalCode = "EC2 7JR", Country = "UK", HomePhone = "(71) 555-7773", PhotoPath = "http://accweb/emmployees/buchanan.bmp" };
            var employee7 = new Employee { EmployeeID = 7, LastName = "King", FristName = "Robert", Title = "Sales Representative", TitleOfCourtesy = "Mr.", BirthDate = date6, Address = "Edgeham HollowWinchester Way", City = "London", Region = "", PostalCode = "RG1 9SP", Country = "UK", HomePhone = "(71) 555-5598", PhotoPath = "http://accweb/emmployees/davolio.bmp" };
            var employee8 = new Employee { EmployeeID = 8, LastName = "Callahan", FristName = "Laura", Title = "Inside Sales Coordinator", TitleOfCourtesy = "Ms.", BirthDate = date7, Address = "4726 - 11th Ave. N.E.", City = "Seattle", Region = "WA", PostalCode = "98105", Country = "USA", HomePhone = "(206) 555-1189", PhotoPath = "http://accweb/emmployees/davolio.bmp" };
            var employee9 = new Employee { EmployeeID = 9, LastName = "Dodsworth", FristName = "Anne", Title = "Sales Representative", TitleOfCourtesy = "Ms.", BirthDate = date8, Address = "7 Houndstooth Rd.", City = "London", Region = " ", PostalCode = "WG2 7LT", Country = "UK", HomePhone = "(71) 555-4444", PhotoPath = "http://accweb/emmployees/davolio.bmp" };
            
            var employees = new List<Employee> { employee1, employee2, employee3, employee4, employee5, employee6, employee7, employee8, employee9 };

            return employees;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtsearch.Text;
         grdEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in grdEmployee.Rows)
                {
                    if (row.Cells[4].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch 
            {
                MessageBox.Show("input error");
            }


        }
    }
}
