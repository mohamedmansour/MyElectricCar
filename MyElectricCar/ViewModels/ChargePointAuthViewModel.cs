using MyElectricCar.Commons;
using MyElectricCar.Services;
using MyElectricCar.ViewModels.Interfaces;
using System;
using System.Windows.Input;
using Windows.UI.Popups;

namespace MyElectricCar.ViewModels
{
    public class ChargePointAuthViewModel : ViewModelBase, IChargePointAuthViewModel
    {
        private ICommand _connectCommand;
        private string _username;
        private string _password;
        private readonly ChargePointService _chargePointService;
        private readonly UserService _userService;

        public ChargePointAuthViewModel(ChargePointService chargePointService, UserService userService)
        {
            _chargePointService = chargePointService;
            _userService = userService;
        }

        public ICommand ConnectCommand
        {
            get
            {
                if (_connectCommand == null)
                {
                    _connectCommand = new RelayCommand(Connect);
                }
                return _connectCommand;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                NotifyPropertyChanged();
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyPropertyChanged();
            }
        }

        private async void Connect(object parameter)
        {
            var auth = await _chargePointService.AuthenticateAsync(this.Username, this.Password);
            if (auth.Status)
            {
                _userService.AccessToken = auth.AuthToken;
                _userService.Id = long.Parse(auth.UserId);
                App.NavigationService.Navigate<Views.MainPage>();
            }
            else
            {
                await new MessageDialog("Denied: " + auth.Error).ShowAsync();
            }
        }
    }
}
