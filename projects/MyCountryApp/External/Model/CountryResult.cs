using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyCountryApplication.External.Model
{
    public class CountryResultItem
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("alpha2_code")]
        public string Alpha2Code { get; set; }

        [JsonProperty("alpha3_code")]
        public string Alpha3Code { get; set; }
    }

    public class CountryRestResponse
    {

        [JsonProperty("messages")]
        public IList<string> Messages { get; set; }

        [JsonProperty("result")]
        public IList<CountryResultItem> Result { get; set; }
    }

    public class CountryResult
    {

        [JsonProperty("RestResponse")]
        public CountryRestResponse RestResponse { get; set; }
    }

}
