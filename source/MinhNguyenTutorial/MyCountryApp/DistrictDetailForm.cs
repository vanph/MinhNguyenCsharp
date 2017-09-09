using MyCountry.Model;
using MyCountry.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCountryApp
{

    public partial class DistrictDetailForm : Form
    {
        public bool IsAddNew { get; set; }
        public bool IsEditNew { get; set; }
        public DistrictDetailForm()
        {
            InitializeComponent();
       
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void DistrictDetailForm_Load(object sender, EventArgs e)
        {   
            if(IsAddNew==true)
            {
              
            }
            if (IsEditNew == true)
            {
                txtCodee.ReadOnly = true;
                cbbCity.Enabled = false;
            }

        }
    }
}
