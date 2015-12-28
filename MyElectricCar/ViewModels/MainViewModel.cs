using MyElectricCar.Commons;
using MyElectricCar.Services;
using System.Windows.Input;

namespace MyElectricCar.ViewModels
{
    public class MainViewModel
    {
        private ICommand _disconnectCommand;
        private readonly UserService _userService;

        public MainViewModel(UserService userService)
        {
            _userService = userService;
        }

        public ICommand DisconnectCommand
        {
            get
            {
                if (_disconnectCommand == null)
                {
                    _disconnectCommand = new RelayCommand(Disconnect);
                }
                return _disconnectCommand;
            }
        }

        private void Disconnect(object parameter)
        {
            _userService.Clear();
            App.NavigationService.Navigate<Views.ChargePointAuthView>();
        }
    }
}
