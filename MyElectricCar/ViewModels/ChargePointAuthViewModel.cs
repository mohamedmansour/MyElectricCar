using MyElectricCar.Commons;
using MyElectricCar.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace MyElectricCar.ViewModels
{
    public class ChargePointAuthViewModel : ViewModelBase
    {
        private ICommand _connectCommand;
        private string _username;
        private string _password;
        private ChargePointService _service;

        public ChargePointAuthViewModel(ChargePointService service)
        {
            _service = service;
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
                NotifyPropertyChanged("Username");
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
                NotifyPropertyChanged("Password");
            }
        }

        private async void Connect(object parameter)
        {
            var auth = await _service.AuthenticateAsync(this.Username, this.Password);
            if (auth.Status)
            {
                await new MessageDialog("Connected").ShowAsync();
            }
            else
            {
                await new MessageDialog("Denied: " + auth.Error).ShowAsync();
            }
        }
    }
}
