using System.Collections.Generic;

namespace MyCountryApplication.Business
{
    public class CityInfomation
    {
        //public string CityCode { get; set; }
        public string CityName { get; set; }
        public List<string> DistrictNames { get; set; }

        public CityInfomation()
        {
            DistrictNames = new List<string>();
        }


        //public int Count
        //{
        //    get { return DistrictNames.Count; }
        //}

        //public string DistrictNameString
        //{
        //    get { return string.Join(", ", DistrictNames); }
        //} 

        //Calculated Property
        public int Count => DistrictNames.Count;

        public string DistrictNameString => string.Join(", ", DistrictNames);
    }
}
