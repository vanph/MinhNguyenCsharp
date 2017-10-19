using System.Collections.Generic;
using MyCountry.Business.ViewModel;
using MyCountry.DataAccess.Model;

namespace MyCountry.Business
{
    public interface ICityBusiness
    {

        List<City> GetCities();

        List<CityInfomation> GetCityInformations();
    }
}