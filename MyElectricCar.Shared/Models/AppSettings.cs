using Newtonsoft.Json;

namespace MyElectricCar.Shared.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class AppSettings
    {
        [JsonProperty("bing_search_api_key")]
        public string BingSearchApiKey { get; set; }
    }
}
