using System;
using System.Linq;
using System.Windows.Forms;
using MyCountryApplication.DataAccess.Persistence;

namespace MyCountryApplication.View
{
    public partial class ListDistrictForm : Form
    {
        public ListDistrictForm()
        {
            InitializeComponent();
            grdDistrict.AutoGenerateColumns = false;
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            grdDistrict.DataSource = new MyCountryEntities().Districts.ToList();
        }
        private void btnClearSearch_click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }
    }
}
