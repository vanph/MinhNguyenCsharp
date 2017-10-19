using System;
using System.Linq;
using System.Windows.Forms;
using MyCountry.Business;
using MyCountry.Business.Exceptions;
using MyCountry.DataAccess.Model;

namespace MyCountryApplication.View
{
    public sealed partial class DistrictDetailForm : Form
    {
        private readonly IDistrictBusiness _districtBusiness;
        private readonly ICityBusiness _cityBusiness;
        private readonly bool _isAddNew;
        private readonly string _selectedCode;

        public DistrictDetailForm(bool isAddNew, string code = "")
        {
            InitializeComponent();
            _isAddNew = isAddNew;
            if (!isAddNew)
            {
                _selectedCode = code;

            }

            Text = _isAddNew ? @"Add new District" : @"Edit District";

            _districtBusiness = new DistrictBusiness();
            _cityBusiness = new CityBusiness();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void DistrictDetailForm_Load(object sender, EventArgs e)
        {
            var cities = _cityBusiness.GetCities();
            cbbCity.DataSource = cities;
            cbbCity.DisplayMember = nameof(City.Name);

            if (!_isAddNew)
            {
                cbbCity.Enabled = false;
                txtCode.Enabled = false;

                var editingDistrict = _districtBusiness.GetByCode(_selectedCode);
                if (editingDistrict != null)
                {
                    txtName.Text = editingDistrict.Name;
                    txtCode.Text = editingDistrict.DistrictCode;
                    txtType.Text = editingDistrict.Type;
                    var city = cities.FirstOrDefault(x => x.CityCode == editingDistrict.CityCode);
                    cbbCity.SelectedItem = city;
                }
                else
                {
                    MessageBox.Show(@"Cannot found district.", @"Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnSave.Enabled = false;
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var city = cbbCity.SelectedItem as City;

                var districtInfo = new District
                {
                    Name = txtName.Text,
                    DistrictCode = txtCode.Text,
                    Type = txtType.Text,
                    CityCode = city != null ? city.CityCode : string.Empty
                };

                if (_isAddNew)
                {
                    _districtBusiness.Add(districtInfo);
                }
                else
                {
                    _districtBusiness.Update(districtInfo);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (DistrictValidationException ex)
            {
                MessageBox.Show(ex.Message,@"Message",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }


    }
}
