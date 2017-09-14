using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Windows.Forms;
using MyCountryApplication.DataAccess.Model;
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

            //MyCountryEntities entity = new MyCountryEntities();
            //var query = (from d in entity.Districts
            //             where d.DistrictCode.Contains(searchValue) || d.Name.Contains(searchValue)
            //             join c in entity.Cities on d.CityCode equals c.CityCode
            //             select new DistrictViewModel
            //             {
            //                 DistrictCode = d.DistrictCode,
            //                 DistrictName = d.Name,
            //                 CityCode = c.CityCode,
            //                 CityName = c.Name
            //             }).ToList();
            grdDistrict.DataSource = SearchDistricts(txtSearch.Text);
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var query = SearchDistricts("");

            grdDistrict.DataSource = query.ToList();
        }

        private static List<DistrictViewModel> SearchDistricts(string keyword)
        {
            var dbContext = new MyCountryEntities();

            var query = (from d in dbContext.Districts
                join c in dbContext.Cities on d.CityCode equals c.CityCode
                select new DistrictViewModel
                {
                    DistrictCode = d.DistrictCode,
                    DistrictName = d.Name,
                    CityCode = c.CityCode,
                    CityName = c.Name
                });

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(d => d.DistrictCode.Contains(keyword) || d.DistrictName.Contains(keyword));
            }

            var result = query.ToList();

            return result;
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
