using Newtonsoft.Json;

namespace MyElectricCar.Models
{
    public class ChargePointAuth<T>
    {
        [JsonProperty("validate_login")]
        public T ValidateLogin {get; set;}
    }
}
 