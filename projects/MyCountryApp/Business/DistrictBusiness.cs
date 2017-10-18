using System;
using System.Collections.Generic;
using System.Linq;
using MyCountry.DataAccess;
using MyCountry.DataAccess.Model;
using MyCountryApplication.Exceptions;
using MyCountryApplication.ViewModel;

namespace MyCountryApplication.Business
{
    public class DistrictBusiness : IDistrictBusiness
    {
        public List<DistrictViewModel> Search(string keyword = "", string cityCode = "")
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

        public District GetByCode(string districtCode)
        {
            var dbContext = new MyCountryEntities();

            var district = dbContext.Districts.FirstOrDefault(x => x.DistrictCode == districtCode);

            return district;
        }

        public void Add(District districtInfo)
        {
            var dbContext = new MyCountryEntities();

            var existingDistrict = dbContext.Districts.FirstOrDefault(x => x.DistrictCode == districtInfo.DistrictCode);

            if (existingDistrict != null)
            {
                //raise duplicated district error here
                throw new UpdateDistrictException($"District code {existingDistrict.DistrictCode} exists.");
            }

            var district = new District
            {
                DistrictCode = districtInfo.DistrictCode,
                Name = districtInfo.Name,
                Type = districtInfo.Type,
                CityCode = districtInfo.CityCode,
                CreatedDate = DateTime.Now,
                CreatedBy = ServiceContext.UserName,
                ModifiedDate = DateTime.Now,
                ModifiedBy = ServiceContext.UserName
            };

            dbContext.Districts.Add(district);

            dbContext.SaveChanges();
        }

        public void Update(District districtInfo)
        {
            var dbContext = new MyCountryEntities();

            var existingDistrict = dbContext.Districts.FirstOrDefault(x => x.DistrictCode == districtInfo.DistrictCode);

            if (existingDistrict != null)
            {
                existingDistrict.Name = districtInfo.Name;
                existingDistrict.Type = districtInfo.Type;
                existingDistrict.ModifiedDate = DateTime.Now;
                existingDistrict.ModifiedBy = ServiceContext.UserName;

                dbContext.SaveChanges();
            }
        }
    }
}