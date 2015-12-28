using Newtonsoft.Json;

namespace MyElectricCar.Models
{
    public class ChargePointActivityRequest
    {
        [JsonProperty("page_size")]
        public int PageSize { get; set; }
    }
}
