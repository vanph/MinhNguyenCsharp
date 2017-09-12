using MyCountry.Model;
using MyCountry.Repository;
using System;
using System.Windows.Forms;
using System.Linq;

namespace MyCountryApp
{
    public partial class DistrictDetailForm : Form
    {
        private readonly CityRepository _cityRepository;
        private readonly DistrictRepository _districtRepository;

        private bool _isAddNew;
        private string _selectedDistrictCode;

        public DistrictDetailForm(CityRepository cityRepository, DistrictRepository districtRepository)
        {
            InitializeComponent();
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _isAddNew = true;
        }

        public DistrictDetailForm(CityRepository cityRepository, DistrictRepository districtRepository, string districtCode)
        {
            InitializeComponent();
            _cityRepository = cityRepository;
            _districtRepository = districtRepository;
            _selectedDistrictCode = districtCode;//g
            _isAddNew = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCities(string selectedCityCode = "")
        {            
            var cities = _cityRepository.GetAll();
            cbbCity.DataSource = cities;
            cbbCity.DisplayMember = nameof(City.Name);

            if(!string.IsNullOrEmpty(selectedCityCode))
            {
                var selectedCity = cities.FirstOrDefault(x => x.Code == selectedCityCode);
                if (selectedCity != null)
                {
                    cbbCity.SelectedItem = selectedCity;
                }
            }            
        }
        private void DistrictDetailForm_Load(object sender, EventArgs e)
        {            
            if (_isAddNew == true)
            {
                LoadCities();
            }
            else
            {              
                txtCode.ReadOnly = true;
                txtCode.Enabled = false;
                cbbCity.Enabled = false;
                var district = _districtRepository.GetByCode(_selectedDistrictCode);
                if (district != null)
                {
                    txtCode.Text = district.Code;
                    txtName.Text = district.Name;
                    txtType.Text = district.Type;
                    LoadCities(district.CityCode);
                }              
            }
        }
    }
}
