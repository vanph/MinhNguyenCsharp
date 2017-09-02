using System;
using System.Windows.Forms;
using EmployeeManagementApp.Repository;
using System.Linq;
using System.Collections.Generic;
using EmployeeManagementApp.Model;
using System.Text;
using System.IO;

namespace EmployeeManagementApp
{
    public partial class Form1 : Form
    {
        private readonly EmployeeRepository _employeeRepository;//Field
                        
        public Form1()
        {
            InitializeComponent();
            grdEmployee.AutoGenerateColumns = false;
            grdEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _employeeRepository = new EmployeeRepository();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUsingLinqMethodCallStyle();
            //SearchByUsingLinqQueryExpressionStyle();
            //SearchByPrevLinq();

            var props = typeof(Employee).GetProperties();
        }

        private void SearchByPrevLinq()
        {
            string searchValue = txtsearch.Text;
            var allEmployees = _employeeRepository.GetEmployees();
            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.ToLower();
                var filterdEmps = new List<Employee>();

                foreach (var emp in allEmployees)
                {
                    if(emp.FullName.ToLower().Contains(searchValue) || emp.FullAddress.ToLower().Contains(searchValue))
                    {
                        filterdEmps.Add(emp);
                    }
                }

                grdEmployee.DataSource = filterdEmps;
            }
            else
            {
                grdEmployee.DataSource = allEmployees;
            }

            var filteredEmployees = new List<Employee>();

          
        }

        private void SearchByUsingLinqQueryExpressionStyle()
        {
            string searchValue = txtsearch.Text;
            var allEmployees = _employeeRepository.GetEmployees();
            
            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.ToLower();
                var filteredEmployees = from e in allEmployees
                                        where e.FullName.ToLower().Contains(searchValue) || e.FullAddress.ToLower().Contains(searchValue)
                                        orderby e.BirthDate descending
                                        select e;            

                grdEmployee.DataSource = filteredEmployees.ToList();
            }
            else
            {
                grdEmployee.DataSource = (from e in allEmployees orderby e.BirthDate descending select e).ToList();
            }
        }

        private void SearchUsingLinqMethodCallStyle()
        {
            string searchValue = txtsearch.Text;
            var allEmployees = _employeeRepository.GetEmployees();
            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.ToLower();
                var filteredEmployees = allEmployees.Where(x => x.FullName.ToLower().Contains(searchValue) || x.FullAddress.ToLower().Contains(searchValue))
                                                    .OrderByDescending(x => x.BirthDate);

                grdEmployee.DataSource = filteredEmployees.ToList();
            }
            else
            {
                grdEmployee.DataSource = allEmployees.OrderByDescending(x => x.BirthDate).ToList();
            }
        }

        private void OnFormLoaded(object sender, EventArgs e)
        {
           //var employees= _employeeRepository.GetEmployees();
           // grdEmployee.DataSource = employees;
        }

        private void btnExportToTxt_Click(object sender, EventArgs e)
        {
            ExportToText1();
        }

        private void ExportToText1()
        {
            var allEmployees = _employeeRepository.GetEmployees();

            StringBuilder str = new StringBuilder();

            foreach (var emp in allEmployees)
            {
                str.AppendLine($"Full Name: {emp.FullName} - Title: {emp.Title} - Full Address: {emp.FullAddress}");
            }                        
            
            var path = $"{Directory.GetCurrentDirectory()}\\emp.txt";

            File.WriteAllText(path, str.ToString());

            MessageBox.Show("Successfully exported");
        }

        private void btnExportToCsv_Click(object sender, EventArgs e)
        {
            var allEmployees = _employeeRepository.GetEmployees();

            StringBuilder str = new StringBuilder();

            foreach (var emp in allEmployees)
            {
                str.AppendLine($"{emp.FullName};{emp.Title};{emp.FullAddress}");
            }

            var path = $"{Directory.GetCurrentDirectory()}\\emp.csv";

            File.WriteAllText(path, str.ToString());

            MessageBox.Show("Successfully exported");
        }
    }
}
