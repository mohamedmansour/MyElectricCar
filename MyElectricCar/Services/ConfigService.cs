using System;
using System.Threading.Tasks;
using MyElectricCar.Services.Interfaces;
using MyElectricCar.Shared.Models;
using Newtonsoft.Json;
using Windows.Storage;

namespace MyElectricCar.Services
{
    public class ConfigService : IConfigService
    {
        private readonly StorageFolder _localFolder = ApplicationData.Current.LocalFolder;
        
        public ConfigService()
        {
            // I know this is hated on.
            Task.WaitAll(Task.Run(async () => await InitializeSettingsAsync()));
        }

        public AppSettings AppSettings { get; private set; }

        private async Task InitializeSettingsAsync()
        {
            var uri = new Uri("ms-appx:///AppSettings.json");
            StorageFile appsettingsFile = await StorageFile.GetFileFromApplicationUriAsync(uri);
            string appsettingsContent = await FileIO.ReadTextAsync(appsettingsFile);
            AppSettings = JsonConvert.DeserializeObject<AppSettings>(appsettingsContent);
        }
    }
}
