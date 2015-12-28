using MyElectricCar.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyElectricCar.ViewModel
{
    public class ChargePointAuthViewModel : ViewModelBase
    {
        private ICommand _connectCommand;
        private string _username;
        private string _password;

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
            System.Diagnostics.Debug.WriteLine("Connecting");
        }
    }
}
