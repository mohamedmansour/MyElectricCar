using Newtonsoft.Json;

namespace MyElectricCar.Models
{
    public class ChargePointVehicleInfo
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("make")]
        public string Make { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("vehicle_id")]
        public long VehicleId { get; set; }

        [JsonProperty("is_primary_vehicle")]
        public bool IsPrimaryVehicle { get; set; }

        [JsonProperty("battery_capacity")]
        public double BatteryCapacity { get; set; }
        
        [JsonProperty("ev_range")]
        public int EvRange { get; set; }
    }
}
