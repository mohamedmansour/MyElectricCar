using System;
using MyElectricCar.Commons;
using MyElectricCar.Services.Interfaces;

namespace MyElectricCar.Services
{
    public class UserService : IUserService
    {
        private const string SettingAccessToken = "AuthAcessToken";
        private const string SettingUserId = "AuthUserId";

        public bool IsAuthenticated
        {
            get
            {
                return string.IsNullOrWhiteSpace(AccessToken) ? false : true;
            }
        }

        public string AccessToken
        {
            get
            {
                return LocalStorageHelper.GetOrDefault<string>(SettingAccessToken);
            }
            set
            {
                LocalStorageHelper.Set(SettingAccessToken, value);
            }
        }

        public long Id
        {
            get
            {
                return LocalStorageHelper.GetOrDefault<long>(SettingUserId);
            }
            set
            {
                LocalStorageHelper.Set(SettingUserId, value);
            }
        }

        public void Clear()
        {
            LocalStorageHelper.Remove(SettingAccessToken);
            LocalStorageHelper.Remove(SettingUserId);
        }
    }
}
