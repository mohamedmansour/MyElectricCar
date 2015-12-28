using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyElectricCar.Models
{
    public class ChargePointAuthRequest
    {
        [JsonProperty("disable_token")]
        public bool DisableToken { get; set; }

        [JsonProperty("user_name")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("device_os")]
        public string DeviceOS { get; set; }
    }
}
