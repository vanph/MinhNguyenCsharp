using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MyCountry.DataAccess;
using MyCountryApplication.Business;
using MyCountryApplication.ViewModel;


namespace MyCountryApplication.View
{
    public partial class ListDistrictForm : Form
    {
        private readonly MyCountryBusiness _myCountryBusiness;

        public ListDistrictForm()
        {
            InitializeComponent();
            grdDistrict.AutoGenerateColumns = false;
            _myCountryBusiness = new MyCountryBusiness();
        }

        

        private void btnSeach_Click(object sender, EventArgs e)
        {
            grdDistrict.DataSource = _myCountryBusiness.SearchDistricts(txtSearch.Text);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbbCity.DataSource = _myCountryBusiness.GetCities();
            cbbCity.DisplayMember = nameof(City.Name);
            cbbCity.SelectedIndex = -1;

            grdDistrict.DataSource = _myCountryBusiness.SearchDistricts();
        }


        private void btnClearSearch_click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (grdDistrict.SelectedRows.Count > 0)
            {
                var districtViewModel = grdDistrict.SelectedRows[0].DataBoundItem as DistrictViewModel;
                if (districtViewModel != null)
                {
                    lblCityName.Text = districtViewModel.CityName;
                    lblDistrictCode.Text = districtViewModel.CityCode;
                    lblName.Text = districtViewModel.DistrictName;
                }
            }
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
