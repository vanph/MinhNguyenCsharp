using System;
using System.Linq;
using System.Windows.Forms;
using MyCountryApplication.Business;
using MyCountry.DataAccess;

namespace MyCountryApplication.View
{
    public sealed partial class DistrictDetailForm : Form
    {
        private readonly MyCountryBusiness _myCountryBusiness;
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
            _myCountryBusiness = new MyCountryBusiness();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void DistrictDetailForm_Load(object sender, EventArgs e)
        {
            var cities = new MyCountryEntities();
            cbbCity.DataSource = cities;
            cbbCity.DisplayMember = nameof(City.Name);
            if (!_isAddNew)
            {
                cbbCity.Enabled = false;
                txtCode.Enabled = false;
                var dbContext = new MyCountryEntities();
                var editingDistrict = dbContext.Districts.FirstOrDefault(x => x.DistrictCode == _selectedCode);
                if (editingDistrict != null)
                {
                    txtName.Text = editingDistrict.Name;
                    txtCode.Text = editingDistrict.DistrictCode;
                    txtType.Text = editingDistrict.Type;
                    var city = cities.Districts.FirstOrDefault(x => x.CityCode == editingDistrict.CityCode);
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
                if (_isAddNew)
                {
                    var dbContext = new MyCountryEntities();
                    var city = cbbCity.SelectedItem as City;

                    var district = new District
                    {
                        Name = txtName.Text,
                        DistrictCode = txtCode.Text,
                        Type = txtType.Text,
                        CityCode = city != null ? city.CityCode : string.Empty
                    };
                    dbContext.Districts.Add(district);
                    dbContext.SaveChanges();
                }
                else
                {
                    //Todo: Implement editing district

                    var dbContext = new MyCountryEntities();
                    var district = dbContext.Districts.FirstOrDefault(x => x.DistrictCode == _selectedCode);
                    if (district != null)
                    {
                        district.Name = txtName.Text;
                        district.Type = txtType.Text;

                        dbContext.SaveChanges();
                    }
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }


    }
}
