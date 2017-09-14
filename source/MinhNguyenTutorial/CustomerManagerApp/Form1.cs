using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CustomerManagerApp.Model;

namespace CustomerManagerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //var dbContext = new NorthwindEnties();
            //var query = dbContext.Customers.OrderBy(x => x.CustomerID);
            //dataGridView1.DataSource = query.ToList();

        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var searchvalue = txtSearch.Text;
            var customers = SearchCustomers(searchvalue);
            dataGridView1.DataSource = customers.ToList();
        }

        private  IEnumerable<Customer> SearchCustomers(string searchvalue)
        {
            var dbContext = new NorthwindEnties();
            var query = dbContext.Customers.Where(x => x.CustomerID.Contains(searchvalue) || x.CompanyName.Contains(searchvalue));
            var customers = query.ToList();

            return customers;
        }
    }
}
