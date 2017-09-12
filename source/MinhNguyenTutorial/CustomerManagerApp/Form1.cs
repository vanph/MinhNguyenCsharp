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

        private void button1_Click(object sender, EventArgs e)
        {
            var dbContext = new NorthwindEnties();
            var query = dbContext.Customers.OrderBy(x => x.CustomerID);

            dataGridView1.DataSource = query.ToList();

        }
    }
}
