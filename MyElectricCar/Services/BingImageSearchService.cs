using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyElectricCar.Services.Interfaces;
using MyElectricCar.Shared.Models;
using Newtonsoft.Json;

namespace MyElectricCar.Services
{
    public class BingImageSearchService : IImageSearchService
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly IConfigService _configService;

        private const string _uri = "https://api.cognitive.microsoft.com/bing/v5.0/images/search?";

        public BingImageSearchService(IConfigService configService)
        {
            _configService = configService;
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _configService.AppSettings.BingSearchApiKey);
        }

        public async Task<ImageSearch> Search(string query)
        {
            var queryString = $"count=1&offset=0&mkt=en-us&safeSearch=Moderate&size=Large&q={Uri.EscapeDataString(query)}";
            HttpResponseMessage response = await _client.GetAsync(_uri + queryString);
            return JsonConvert.DeserializeObject<ImageSearch>(await response.Content.ReadAsStringAsync());
        }
    }
}
