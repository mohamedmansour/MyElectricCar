using MyElectricCar.Shared.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyElectricCar.Services
{
    public class ChargePointService
    {
        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Authenticates Async into the ChargePoint portal.
        /// </summary>
        /// <param name="username">The username usually the email.</param>
        /// <param name="password">The plaintext password.</param>
        /// <returns>AuthResponse model</returns>
        public async Task<ChargePointAuthResponse> AuthenticateAsync(string username, string password)
        {
            // Post data that prepares the auth request.
            var authData = new ChargePointAuth<ChargePointAuthRequest>
            {
                ValidateLogin = new ChargePointAuthRequest
                {
                    DeviceOS = "iOS",
                    DisableToken = false,
                    Password = password,
                    Username = username
                }
            };
            HttpResponseMessage response = await _client.PostAsync(
                "https://webservices.chargepoint.com/backend.php/mobileapi/v3",
                new StringContent(JsonConvert.SerializeObject(authData)));

            // Deserialized response.
            var authResponse = JsonConvert.DeserializeObject<ChargePointAuth<ChargePointAuthResponse>>(
                await response.Content.ReadAsStringAsync());
            return authResponse.ValidateLogin;
        }

        public async Task<ChargePointActivityResponse> ChargingActivityAsync(int pageSize, long userId)
        {
            // Post data that prepares the auth request.
            var queryData = new ChargePointActivity<ChargePointActivityRequest>
            {
                UserId = userId,
                ChargingActivity = new ChargePointActivityRequest
                {
                    PageSize = 10
                }
            };

            HttpResponseMessage response = await _client.GetAsync(
                "https://mc.chargepoint.com/map-prod/v2?" + JsonConvert.SerializeObject(queryData));

            // Deserialized response.
            var authResponse = JsonConvert.DeserializeObject<ChargePointActivity<ChargePointActivityResponse>>(
                await response.Content.ReadAsStringAsync());
            return authResponse.ChargingActivity;
        }
    }
}
