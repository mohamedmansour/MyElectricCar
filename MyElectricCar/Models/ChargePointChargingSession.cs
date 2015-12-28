using Newtonsoft.Json;

namespace MyElectricCar.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ChargePointChargingSession
    {
        [JsonProperty("company_id")]
        public long CompanyId { get; set; }

        [JsonProperty("session_id")]
        public long SessionId { get; set; }

        [JsonProperty("charging_time")]
        public long ChargingTime { get; set; }

        [JsonProperty("current_charging")]
        public string CurrentCharging { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("vehicle_id")]
        public long vehicle_id { get; set; }

        [JsonProperty("state_name")]
        public string StateName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("power_kw")]
        public double PowerKw { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("session_time")]
        public long SessionTime { get; set; }

        [JsonProperty("miles_added")]
        public double MilesAdded { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }

        [JsonProperty("total_amount")]
        public double TotalAmount { get; set; }

        [JsonProperty("update_period")]
        public long UpdatePeriod { get; set; }

        [JsonProperty("device_id")]
        public long DeviceId { get; set; }

        [JsonProperty("outlet_number")]
        public long OutletNumber { get; set; }

        [JsonProperty("api_flag")]
        public bool ApiFlag { get; set; }

        [JsonProperty("currency_iso_code")]
        public string CurrencyIsoCode { get; set; }

        [JsonProperty("end_time")]
        public long EndTime { get; set; }

        [JsonProperty("start_offset")]
        public long StartOffset { get; set; }

        [JsonProperty("port_level")]
        public long PortLevel { get; set; }

        [JsonProperty("start_time")]
        public long StartTime { get; set; }

        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }

        [JsonProperty("energy_kwh")]
        public double EnergyKwh { get; set; }
    }
}
