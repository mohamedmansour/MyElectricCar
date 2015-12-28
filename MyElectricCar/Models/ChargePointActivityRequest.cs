using Newtonsoft.Json;

namespace MyElectricCar.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChargePointActivityRequest
    {
        [JsonProperty("page_size")]
        public int PageSize { get; set; }
    }
}
