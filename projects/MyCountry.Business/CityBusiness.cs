using System.Collections.Generic;
using System.Linq;
using MyCountry.Business.ViewModel;
using MyCountry.DataAccess;
using MyCountry.DataAccess.Model;

namespace MyCountry.Business
{
    public class CityBusiness : ICityBusiness
    {

        public List<City> GetCities()
        {
            var dbContext = new MyCountryEntities();
            var cities = dbContext.Cities.ToList();
            return cities;
        }

        public List<CityInfomation> GetCityInformations()
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
                DistrictNames = Enumerable.ToList<string>(x.Districts.Select(d => d.Name))
            }).ToList();
            
            return cityInfomations;
        }

    }
}