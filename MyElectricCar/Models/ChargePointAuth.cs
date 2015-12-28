using Newtonsoft.Json;

namespace MyElectricCar.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChargePointAuth<T>
    {
        [JsonProperty("validate_login")]
        public T ValidateLogin {get; set;}
    }
}
 