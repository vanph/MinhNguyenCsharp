using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCountry.DataAccess;

namespace MyCountryApplication.View
{
    public partial class LoginForm : Form
    {

        public  string UserName { get; set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            var userName = txtUserName.Text;
            var pass = txtPassword.Text;
            var dbContext = new MyCountryEntities();
            var user = dbContext.Users.FirstOrDefault(x => x.UserName== userName && x.Password ==pass);
            if (user != null)
            {
                MessageBox.Show(@"Login successful", @"Message", MessageBoxButtons.OK);
                this.UserName = user.UserName;
                DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show(@"Login failed", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
      
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
        }
    }
}
