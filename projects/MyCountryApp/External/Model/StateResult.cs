using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCountryApplication.External.Model
{
    public class StateResultItem
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("abbr")]
        public string Abbr { get; set; }

        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("largest_city")]
        public string LargestCity { get; set; }

        [JsonProperty("capital")]
        public string Capital { get; set; }
    }

    public class StateRestResponse
    {

        [JsonProperty("messages")]
        public IList<string> Messages { get; set; }

        [JsonProperty("result")]
        public IList<StateResultItem> Result { get; set; }
    }

    public class StateResult
    {

        [JsonProperty("RestResponse")]
        public StateRestResponse RestResponse { get; set; }
    }

}
