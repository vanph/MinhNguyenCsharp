using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCountry.DataAccess.Model;
using MyCountryApplication.ViewModel;

namespace MyCountryApplication.Business
{
    public interface IMyCountryBusiness
    {
        List<DistrictViewModel> SearchDistricts(string keyword = "", string cityCode = "");

        List<City> GetCities();

        List<CityInfomation> GetCityInformaitons();
    }
}
