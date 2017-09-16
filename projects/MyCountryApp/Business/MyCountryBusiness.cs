using System.Collections.Generic;
using MyCountry.DataAccess;
using MyCountryApplication.ViewModel;
using System.Linq;

namespace MyCountryApplication.Business
{
    public class MyCountryBusiness
    {
        public  List<DistrictViewModel> SearchDistricts(string keyword ="")
        {
            var dbContext = new MyCountryEntities();

            var query = (from d in dbContext.Districts
                join c in dbContext.Cities on d.CityCode equals c.CityCode
                select new DistrictViewModel
                {
                    DistrictCode = d.DistrictCode,
                    DistrictName = d.Name,
                    CityCode = c.CityCode,
                    CityName = c.Name
                });

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(d => d.DistrictCode.Contains(keyword) || d.DistrictName.Contains(keyword));
            }

            var result = query.ToList();

            return result;
        }
        public  List<City> GetCities()
        {
            var dbContext = new MyCountryEntities();
            var cities = dbContext.Cities.ToList();

            return cities;
        }
    }
}