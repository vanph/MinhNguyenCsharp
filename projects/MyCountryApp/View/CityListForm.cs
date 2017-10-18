using System;
using System.Windows.Forms;
using MyCountryApplication.Business;

namespace MyCountryApplication.View
{
    public partial class CityListForm : Form
    {
        private readonly ICityBusiness _cityBusiness ;

        public CityListForm()
        {
            InitializeComponent();
            
            _cityBusiness = new CityBusiness();

            dataGridView1.AutoGenerateColumns = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void CityListForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _cityBusiness.GetCityInformations();
        }
    }
}
