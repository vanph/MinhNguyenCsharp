using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MyCountry.Repository;
using MyCountry.Model;
using MyCountryApp.ViewModel;
using System.Collections.Generic;

namespace MyCountryApp
{
    public partial class MainForm : Form
    {
        private readonly DistrictRepository _districtRepository;
        private readonly CityRepository _cityRepository;

        public MainForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            lblCityName.Text = "";
            lblDistrictCode.Text = "";
            lblName.Text = "";
            _cityRepository = new CityRepository();
            _districtRepository = new DistrictRepository();
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            SearchDistricts();
        }

        private void SearchDistricts()
        {
            string searchValue = txtSearch.Text;
            var selectedCity = cbbSearch.SelectedItem as City;
            var cityCode = selectedCity != null ? selectedCity.Code : string.Empty;
        
            dataGridView1.DataSource = GetDistrictInformations(searchValue,cityCode );
        }

        private List<DistrictViewModel> GetDistrictInformations(string keyword, string cityCode)
        {
            var allDistricts = _districtRepository.GetAll();
            var allCities = _cityRepository.GetAll();

            var query = from d in allDistricts
                        join c in allCities on d.CityCode equals c.Code
                        select new DistrictViewModel { DistrictCode = d.Code, DistrictName = d.Name, CityCode = c.Code, CityName = c.Name };

            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                query = query.Where(a => a.DistrictCode.ToLower().Contains(keyword) || a.DistrictName.ToLower().Contains(keyword));
            }

            if (!string.IsNullOrEmpty(cityCode))
            {
                query = query.Where(a => a.CityCode.Contains(cityCode));
            }

            return query.ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadCities();
            SearchDistricts();
        }
        private void LoadCities()
        {
            cbbSearch.DataSource = _cityRepository.GetAll();
            cbbSearch.DisplayMember = nameof(City.Name);
            cbbSearch.SelectedIndex = -1;
        }

        private void btnClearSearch_click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cbbSearch.SelectedIndex = -1;
            SearchDistricts();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count >0)
            {
                var districtViewModel = dataGridView1.SelectedRows[0].DataBoundItem as DistrictViewModel;
                if(districtViewModel != null)
                {
                    lblCityName.Text = districtViewModel.CityName;
                    lblDistrictCode.Text = districtViewModel.CityCode;
                    lblName.Text = districtViewModel.DistrictName;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmDetail = new DistrictDetailForm { IsAddNew = true };
            frmDetail.Text = "Add new District";
            frmDetail.ShowDialog();
        
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var frmDetail = new DistrictDetailForm { IsEditNew = true };
            frmDetail.Text = "Edit district ";
            
            frmDetail.ShowDialog();
            
        }
    }
}
