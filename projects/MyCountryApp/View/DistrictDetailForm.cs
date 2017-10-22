using System;
using System.Linq;
using System.Windows.Forms;
using MyCountry.Business;
using MyCountry.Business.Exceptions;
using MyCountry.DataAccess.Model;
using MyCountryApplication.Enumerations;

namespace MyCountryApplication.View
{
    public sealed partial class DistrictDetailForm : Form
    {
        private readonly IDistrictBusiness _districtBusiness;
        private readonly ICityBusiness _cityBusiness;
        //private readonly bool _isAddNew;
        private readonly EditMode _editMode;
        private readonly string _selectedCode;

        public DistrictDetailForm(EditMode editMode, string code = "")
        {
            InitializeComponent();

            _editMode = editMode;

            if (_editMode != EditMode.AddNew)
            {
                _selectedCode = code;

            }

            switch (editMode)
            {
                case EditMode.AddNew:
                    Text = @"Add new District";
                    break;
                case EditMode.Edit:
                    Text = @"Edit District";
                    break;
                case EditMode.View:
                    Text = @"View District Details";
                    break;
            }

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

            var canSave = _editMode != EditMode.View;
            btnSave.Visible = canSave;
            btnCancel.Text = canSave ? "Cancel": "Close";

            //EditMode in View, Edit
            if (_editMode == EditMode.View || _editMode == EditMode.Edit)
            {
                var editable = _editMode == EditMode.Edit;
                
                cbbCity.Enabled = false;
                txtCode.Enabled = false;
                txtName.Enabled = editable;
                txtType.Enabled = editable;

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
                if (_editMode == EditMode.View)
                {
                    return;
                }

                var city = cbbCity.SelectedItem as City;

                var districtInfo = new District
                {
                    Name = txtName.Text,
                    DistrictCode = txtCode.Text,
                    Type = txtType.Text,
                    CityCode = city != null ? city.CityCode : string.Empty
                };

                if (_editMode == EditMode.AddNew)
                {
                    _districtBusiness.Add(districtInfo);
                }
                else if (_editMode == EditMode.Edit)
                {
                    _districtBusiness.Update(districtInfo);
                }

                DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (DistrictValidationException ex)
            {
                MessageBox.Show(ex.Message, @"Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }


    }
}
