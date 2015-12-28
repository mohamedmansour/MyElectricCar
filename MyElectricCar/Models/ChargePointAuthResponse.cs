using Newtonsoft.Json;

namespace MyElectricCar.Models
{
    public class ChargePointAuthResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("auth_token")]
        public string AuthToken { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
