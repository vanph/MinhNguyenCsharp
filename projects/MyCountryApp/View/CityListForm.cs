using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCountryApplication.ViewModel;
using MyCountry.DataAccess;
using MyCountryApplication.Business;

namespace MyCountryApplication.View
{
    public partial class CityListForm : Form
    {
        private readonly IMyCountryBusiness _myCountryBusiness ;

        public CityListForm()
        {
            InitializeComponent();
            
            _myCountryBusiness = new MyCountryBusiness();

            dataGridView1.AutoGenerateColumns = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void CityListForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _myCountryBusiness.GetCityInformaitons();
        }
    }
}
