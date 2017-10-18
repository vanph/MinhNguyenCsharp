using System.Collections.Generic;
using MyCountry.DataAccess.Model;
using MyCountryApplication.ViewModel;

namespace MyCountryApplication.Business
{
    public interface IDistrictBusiness
    {
        List<DistrictViewModel> Search(string keyword = "", string cityCode = "");


        District GetByCode(string districtCode);

        void Add(District districtInfo);

        void Update(District districtInfo);
    }
}