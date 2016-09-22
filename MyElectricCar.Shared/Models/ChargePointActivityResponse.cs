using Newtonsoft.Json;
using System.Collections.Generic;

namespace MyElectricCar.Shared.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChargePointActivityResponse
    {
        [JsonProperty("session_info")]
        public List<ChargePointChargingSession> SessionInfo { get; set; }

        [JsonProperty("page_offset")]
        public string PageOffset { get; set; }

        [JsonProperty("vehicle_info")]
        public Dictionary<string, ChargePointVehicleInfo> VehicleInfo { get; set; }
    }
}
