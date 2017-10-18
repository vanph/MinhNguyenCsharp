using System.Collections.Generic;
using System.Linq;
using MyCountry.DataAccess;
using MyCountryApplication.ViewModel;

namespace MyCountryApplication.Business
{
    public class DistrictBusiness : IDistrictBusiness
    {
        public List<DistrictViewModel> SearchDistricts(string keyword = "", string cityCode = "")
        {
            var dbContext = new MyCountryEntities();

            //using Join
            ////var query = (from d in dbContext.Districts
            ////    join c in dbContext.Cities on d.CityCode equals c.CityCode
            ////    select new DistrictViewModel()
            ////    {
            ////        DistrictCode = d.DistrictCode,
            ////        DistrictName = d.Name,
            ////        CityCode = c.CityCode,
            ////       CityName= c.Name
            ////    });

            //not use join
            var query = dbContext.Districts.Select(d => new DistrictViewModel { DistrictCode = d.DistrictCode, DistrictName = d.Name, CityCode = d.CityCode, CityName = d.City.Name });

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(d => d.DistrictCode.Contains(keyword) || d.DistrictName.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(cityCode))
            {
                query = query.Where(c => c.CityCode == cityCode);
            }

            var result = query.OrderBy(x => x.DistrictCode).ToList();

            return result;

        }

    }
}