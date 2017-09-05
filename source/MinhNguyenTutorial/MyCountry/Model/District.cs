namespace MyCountry.Model
{
   public class District
    {
        // Ma quan huyen
        public string Code { get; set; }

        //Ten quan huyen
        public string Name { get; set; }

        //Loai: quan hoac huyen
        public string Type { get; set; }

        //Ma thanh pho
        public string CityCode { get; set; }

        public District(string code, string name, string type, string cityCode)
        {
            Code = code;
            Name = name;
            Type = type;
            CityCode = cityCode;
        }
    }
}
