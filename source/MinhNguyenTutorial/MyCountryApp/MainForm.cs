using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCountry.Repository;

namespace MyCountryApp
{
    public partial class MainForm : Form
    {
        private readonly DistrictRepository _districtRepository;
        private readonly CityRepository _cityRepository;

        public MainForm()
        {
            InitializeComponent();
            _cityRepository = new CityRepository();
            _districtRepository = new DistrictRepository();
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {            
            //join districts vs cities => list district information
            dataGridView1.DataSource = _districtRepository.GetAll();
        }
    }
}
