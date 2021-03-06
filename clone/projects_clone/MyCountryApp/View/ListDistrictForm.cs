﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            cbbCity.DisplayMember = nameof(City.Name);
            cbbCity.ValueMember = nameof(City.CityCode);

        }


        private void btnSeach_Click(object sender, EventArgs e)
        {
            SearchDistrictInformations();
        }

        public void SearchDistrictInformations()
        {
            var keyword = txtSearch.Text;
            var city = cbbCity.SelectedItem as City;
            var cityCode = city != null ? city.CityCode : string.Empty;
            grdDistrict.DataSource = _myCountryBusiness.SearchDistricts(keyword, cityCode);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCities();

        }

        private void LoadCities()
        {
            cbbCity.DataSource = _myCountryBusiness.GetCities();
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
            var frmDetail = new DistrictDetailForm(true);
            var dialogResult = frmDetail.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                MessageBox.Show(@"Successfully added district", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SearchDistrictInformations();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var districtViewModel = grdDistrict.SelectedRows[0].DataBoundItem as DistrictViewModel;
            if (districtViewModel != null)
            {
                var frmDetail = new DistrictDetailForm(false, districtViewModel.DistrictCode);
                var dialogResult = frmDetail.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    MessageBox.Show(@"Successfully edited the district", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SearchDistrictInformations();
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            if (grdDistrict.SelectedRows.Count > 0)
            {
                var districtViewModel = grdDistrict.SelectedRows[0].DataBoundItem as DistrictViewModel;
                if (districtViewModel != null)
                {
                    var dialogResult = MessageBox.Show($@"Do you really want to delete the District {districtViewModel.DistrictName}?", @"Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dialogResult == DialogResult.Yes)
                    {
                        var dbContext = new MyCountryEntities();
                        var districtCode = districtViewModel.DistrictCode;
                        var district = dbContext.Districts.FirstOrDefault(x => x.DistrictCode == districtCode);

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
