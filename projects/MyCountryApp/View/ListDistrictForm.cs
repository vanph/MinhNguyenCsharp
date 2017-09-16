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
            SearchDistrictInformations();
        }

        private void SearchDistrictInformations()
        {
            var keyword = txtSearch.Text;
            var cityCode = cbbCity.SelectedValue != null ? cbbCity.SelectedValue.ToString() : string.Empty;

            grdDistrict.DataSource = _myCountryBusiness.SearchDistricts(keyword, cityCode);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCities();

            SearchDistrictInformations();
        }

        private void LoadCities()
        {
            cbbCity.DataSource = _myCountryBusiness.GetCities();
            cbbCity.DisplayMember = nameof(City.Name);
            cbbCity.ValueMember = nameof(City.CityCode);
            cbbCity.SelectedIndex = -1;
        }


        private void btnClearSearch_click(object sender, EventArgs e)
        {
            cbbCity.SelectedIndex = -1;
            txtSearch.Text = "";
            SearchDistrictInformations();
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
            if (grdDistrict.SelectedRows.Count > 0)
            {
                var districtViewModel = grdDistrict.SelectedRows[0].DataBoundItem as DistrictViewModel;
                if (districtViewModel != null)
                {
                   var dialogResult = MessageBox.Show($@"Do you really want to delete the District {districtViewModel.DistrictName}?",@"Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var dbContext = new MyCountryEntities();
                        var distristCode = districtViewModel.DistrictCode;
                        var district = dbContext.Districts.FirstOrDefault(x => x.DistrictCode == distristCode);

                        if (district != null)
                        {
                            dbContext.Districts.Remove(district);
                            dbContext.SaveChanges();
                            SearchDistrictInformations();

                            MessageBox.Show(@"Successfully deleted the district.", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Please select a district to delete", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
