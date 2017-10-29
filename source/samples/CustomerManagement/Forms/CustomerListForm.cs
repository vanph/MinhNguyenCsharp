using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CustomerManagement.DataAccess;

namespace CustomerManagement.Forms
{
    public partial class CustomerListForm : Form
    {
        private  BindingSource bsCustomers = new BindingSource();
        public CustomerListForm()
        {
            InitializeComponent();
            grdCustomer.AutoGenerateColumns = false;
        }

        private void FormLoaded(object sender, EventArgs e)
        {
            var dbContext = new DataModel();

            var customers = dbContext.Customers.ToList();

            bsCustomers.DataSource = customers;     
            grdCustomer.DataSource = bsCustomers;

            SetupDataBindingsForLabels();
          
            bsCustomers.Position = 1;
            bindingNavigator1.BindingSource = bsCustomers;

            bindingNavigator1.DeleteItem = null;
            bindingNavigator1.AddNewItem = null;
        }

        /// <summary>
        /// Data bind two fields to labels
        /// </summary>
        private void SetupDataBindingsForLabels()
        {
            lblCustomerIdentifier.DataBindings.Add("text", bsCustomers, "CustomerID");
            lblCompanyName.DataBindings.Add("text", bsCustomers, "CompanyName");
        }
            
        private void cmdFilterByColumn_Click(object sender, EventArgs e)
        {
        }


        private void cmdEditCurrentCustomer_Click(object sender, EventArgs e)
        {
            EditCurrentRow();
        }

        private void cmdAddNewCustomer_Click(object sender, EventArgs e)
        {
            AddNewCustomer();
        }
        private void RemoveCurrentRow()
        {
            MessageBox.Show(nameof(RemoveCurrentRow));
        }
        private void AddNewCustomer()
        {
            MessageBox.Show(nameof(AddNewCustomer));  
        }
        private void EditCurrentRow()
        {
              MessageBox.Show(nameof(EditCurrentRow));
        }
        private void cmdRemoveCurrentCustomer_Click(object sender, EventArgs e)
        {
            RemoveCurrentRow();
        }

        private void OnGridCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                RemoveCurrentRow();
            }
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                EditCurrentRow();
            }

        }

        private void OnBindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            AddNewCustomer();
        }

        private void OnBindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            RemoveCurrentRow();
        }

        private void OnGridCustomer_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                EditCurrentRow();
            }
        }
    }
}