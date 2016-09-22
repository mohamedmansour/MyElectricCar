using Newtonsoft.Json;

namespace MyElectricCar.Shared.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChargePointActivity<T>
    {
        [JsonProperty("charging_activity")]
        public T ChargingActivity { get; set; }

        [JsonProperty("user_id")]
        public long UserId;
    }
}