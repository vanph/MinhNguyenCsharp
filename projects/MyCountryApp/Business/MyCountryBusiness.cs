using System.Collections.Generic;
using MyCountry.DataAccess;
using MyCountryApplication.ViewModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MyCountry.DataAccess.Model;

namespace MyCountryApplication.Business
{
    public class MyCountryBusiness : IMyCountryBusiness
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
        

        public List<City> GetCities()
        {
            var dbContext = new MyCountryEntities();
            var cities = dbContext.Cities.ToList();
            return cities;
        }
        public List<CityInfomation> GetCityInformaitons()
        {
            var dbContext = new MyCountryEntities();

            //1
            //var cityInfomations = dbContext.Districts.GroupBy(d => d.City.Name).Select(
            //    c => new CityInfomation()
            //    {
            //        CityName = c.Key,
            //        DistrictNames = c.Select(x => x.Name).ToList()
            //    }).ToList();

            //2
            //var cityInfomations = dbContext.Cities.GroupBy(d => d.Name).Select(
            //    c => new CityInfomation()
            //    {
            //        CityName = c.Key,
            //        DistrictNames = c.SelectMany(x=> x.Districts).Select(x=> x.Name).ToList()
            //    }).ToList();

            //3
            //var cityInfomations = (from c in dbContext.Cities
            //                       join d in dbContext.Districts on c.CityCode equals d.CityCode into cityDistricts
            //                       from cd in cityDistricts
            //                       group cd by cd.City.Name into g
            //                       select new CityInfomation()
            //                       {
            //                           CityName = g.Key,
            //                           DistrictNames = g.Select(x => x.Name).ToList()
            //                       }).ToList();

            //4
            //var cityQuery = from c in dbContext.Cities
            //                join d in dbContext.Districts on c.CityCode equals d.CityCode
            //                select new
            //                {
            //                    CityName = c.Name,
            //                    DistrictName = d.Name
            //                };

            //var cityInfomations = (from c in cityQuery
            //                       group c by c.CityName
            //                       into g
            //                       select new CityInfomation()
            //                       {
            //                           CityName = g.Key,
            //                           DistrictNames = g.Select(x => x.DistrictName).ToList()
            //                       }).ToList();

            //Lazy loading

            var cityInfomations = dbContext.Cities.Select(x => new CityInfomation
            {
                CityName = x.Name,
                DistrictNames = x.Districts.Select(d => d.Name).ToList()
            }).ToList();
            
            return cityInfomations;
        }

    }

}