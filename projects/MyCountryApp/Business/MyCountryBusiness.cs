using System.Collections.Generic;
using System.Data.Entity;
using MyCountry.DataAccess;
using MyCountryApplication.ViewModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Schema;
using MyCountry.DataAccess.Model;

namespace MyCountryApplication.Business
{
    public class MyCountryBusiness
    {
        public List<DistrictViewModel> SearchDistricts(string keyword ="",string cityCode="")
        {
            var dbContext= new MyCountryEntities();
            var query = (from d in dbContext.Districts
                join c in dbContext.Cities on d.CityCode equals c.CityCode
                select new DistrictViewModel()
                {
                    DistrictCode = d.DistrictCode,
                    DistrictName = d.Name,
                    CityCode = c.CityCode,
                   CityName= c.Name
                });
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(d => d.DistrictCode.Contains(keyword) || d.DistrictName.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(cityCode))
            {
                query = query.Where(c=>c.CityCode==cityCode);
            }
            var result = query.OrderBy(x=>x.DistrictCode).ToList();
            return result;

        }

        public List<City> GetCities()
        {
            var dbContext = new MyCountryEntities();
            var cities = dbContext.Cities.ToList();
            return cities;
        }
    }
   
}