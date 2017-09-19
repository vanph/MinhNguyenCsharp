using System;
using System.Windows.Forms;
using MyCountryApplication.Business;
using MyCountry.DataAccess;
using MyCountryApplication.ViewModel;

namespace MyCountryApplication.View
{
    public partial class DistrictDetailForm : Form
    {
        private readonly MyCountryBusiness _myCountryBusiness;

        public DistrictDetailForm()
        {
            InitializeComponent();
            _myCountryBusiness = new MyCountryBusiness();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void DistrictDetailForm_Load(object sender, EventArgs e)
        {
            cbbCity.DataSource = _myCountryBusiness.GetCities();
            cbbCity.DisplayMember = nameof(City.Name);
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (MyCountryEntities dbContext = new MyCountryEntities())
            {
                //Todo: check existing district code
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

                MessageBox.Show("ok");
            }
        }
    }
}
