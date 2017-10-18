using System.Collections.Generic;
using MyCountryApplication.ViewModel;

namespace MyCountryApplication.Business
{
    public interface IDistrictBusiness
    {
        List<DistrictViewModel> SearchDistricts(string keyword = "", string cityCode = "");
    }
}