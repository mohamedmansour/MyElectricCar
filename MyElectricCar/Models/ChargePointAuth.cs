using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyElectricCar.Models
{
    class ChargePointAuth<T>
    {
        [JsonProperty("validate_login")]
        public T ValidateLogin {get; set;}
    }
}
 