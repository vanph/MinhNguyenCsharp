using System.Collections.Generic;
using MyCountry.DataAccess.Model;
using MyCountryApplication.ViewModel;

namespace MyCountryApplication.Business
{
    public interface ICityBusiness
    {

        List<City> GetCities();

        List<CityInfomation> GetCityInformations();
    }
}