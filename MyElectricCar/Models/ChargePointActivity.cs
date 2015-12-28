using Newtonsoft.Json;

namespace MyElectricCar.Models
{
    public class ChargePointActivity<T>
    {
        [JsonProperty("charging_activity")]
        public T ChargingActivity { get; set; }

        [JsonProperty("user_id")]
        public long UserId;
    }
}