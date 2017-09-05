namespace MyCountry.Model
{
    public  class City
    {
        //Ma Thanh pho
        public string Code { get; set; }

        //Ten Tinh Thanh Pho
        public string Name { get; set; }

        //Loai: Tinh / Thanh pho truc thuoc trung uong
        public string Type { get; set; }

        public City(string code, string name, string type)
        {
            Code = code;
            Name = name;
            Type = type;
        }
    }
}
