using MyElectricCar.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyElectricCar.Services
{
    public class UserService
    {
        private const string AuthAccessToken = "AuthAcessToken";
        private const string AuthUserId = "AuthUserId";

        public bool IsAuthenticated
        {
            get
            {
                return String.IsNullOrWhiteSpace(AuthUserId) ? false : true;
            }
        }

        public string AuthToken
        {
            get
            {
                return LocalStorageHelper.GetOrDefault<string>(AuthAccessToken);
            }
            set
            {
                LocalStorageHelper.Set(AuthAccessToken, value);
            }
        }

        public string Id
        {
            get
            {
                return LocalStorageHelper.GetOrDefault<string>(AuthUserId);
            }
            set
            {
                LocalStorageHelper.Set(AuthUserId, value);
            }
        }
    }
}
