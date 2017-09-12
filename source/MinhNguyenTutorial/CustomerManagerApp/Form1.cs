using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchvalue = txtSearch.Text;
            var dbContext = new NorthwindEnties();
            var customersQuery = dbContext.Customers.Where(x => x.CustomerID.Contains(searchvalue)|| x.CompanyName.Contains(searchvalue));
            var customers = customersQuery.ToList();
            dataGridView1.DataSource = customers.ToList();
        }


    }
}
