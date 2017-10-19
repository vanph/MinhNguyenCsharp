using System.Collections.Generic;

namespace MyCountry.Business.ViewModel
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
        // hàm  public CityInfomation() để tạo mới những district hả anh ?. trên khai báo DistrictNames rồi ạ, hay chỗ này cần nhiều DistrictNames nên phải new liên tục


        //public int Count
        //{
        //    get { return DistrictNames.Count; }
        //}

        //public string DistrictNameString
        //{
        //    get { return string.Join(", ", DistrictNames); }
        //} 

        //Calculated Property
        public int Count =>  DistrictNames.Count;

        public string DistrictNameString => string.Join(", ", DistrictNames);
    }
}
