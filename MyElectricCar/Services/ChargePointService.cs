using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyElectricCar.ViewModel.Services
{
    public class ChargePointService
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<bool> AuthenticateAsync(string user, string password)
        {
            /*
            "{\"version\":\"54\",
                \"validate_login\":\\
                {
                    \"disable_token\":false,\
                    "password\":\"{0}\",
                    \"device_os\":\"iOS\",\
                    "user_name\":\"{1}\"\\
               }\\}
        */
            string postData = string.Format("", password, user);
            HttpResponseMessage response = await _client.PostAsync(
                "https://webservices.chargepoint.com/backend.php/mobileapi/v3",
                new StringContent(postData));

            var responseString = await response.Content.ReadAsStringAsync();

            return true;
        }
    }
}
