using System;
using System.Windows.Forms;

namespace MyCountryApplication.View
{
    public partial class DistrictDetailForm : Form
    {
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

        }
    }
}
