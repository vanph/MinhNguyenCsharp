using System.Collections.Generic;
using MyCountry.Business.ViewModel;
using MyCountry.DataAccess.Model;

namespace MyCountry.Business
{
    public interface IDistrictBusiness
    {
        List<DistrictViewModel> Search(string keyword = "", string cityCode = "");


        District GetByCode(string districtCode);

        void Add(District districtInfo);

        void Update(District districtInfo);
    }
}