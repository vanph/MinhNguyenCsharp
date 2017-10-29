using System;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using MyCountryApplication.External.Model;
using Newtonsoft.Json;
using RestSharp;

namespace MyCountryApplication.View
{
    public partial class CountryForm : Form
    {
        private const string UrlUsaState = "http://services.groupkt.com/state/get/USA/all";
        private const string UrlCountries = "http://services.groupkt.com/country/get/all";
        public CountryForm()
        {
            InitializeComponent();
        }

        private void btnGetStates_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new RestClient { BaseUrl = new Uri(UrlUsaState) };
                var request = new RestRequest();

                var response = client.Execute(request);

                var data = JsonConvert.DeserializeObject<StateResult>(response.Content);
                if (data?.RestResponse?.Result != null)
                {
                    dataGridView1.DataSource = data.RestResponse.Result.ToList();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new RestClient { BaseUrl = new Uri(UrlCountries) };
                var request = new RestRequest();

                var response = client.Execute(request);

                var data = JsonConvert.DeserializeObject<CountryResult>(response.Content);
                if (data?.RestResponse?.Result != null)
                {
                    dataGridView1.DataSource = data.RestResponse.Result.ToList();
                }


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }
    }
}
