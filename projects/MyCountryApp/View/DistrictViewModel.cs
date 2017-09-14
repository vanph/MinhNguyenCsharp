using System.ComponentModel.DataAnnotations;

namespace MyCountryApplication.View
{
    internal class DistrictViewModel
    {
        [Key]
        [StringLength(50)]
        public string DistrictCode { get; set; }

        public string CityCode { get; set; }
        public string DistrictName { get; internal set; }
        public string CityName { get; internal set; }
    }
}