using MyElectricCar.Commons;
using MyElectricCar.Models;
using MyElectricCar.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyElectricCar.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly UserService _userService;
        private readonly ChargePointService _chargePointService;

        private ICommand _disconnectCommand;
        private ObservableCollection<ChargePointChargingSession> _chargingSessions;

        public MainViewModel(UserService userService, ChargePointService chargePointService)
        {
            _userService = userService;
            _chargePointService = chargePointService;
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

        public ObservableCollection<ChargePointChargingSession> ChargingSessions
        {
            get
            {
                return _chargingSessions;
            }
            private set
            {
                _chargingSessions = value;
                NotifyPropertyChanged();
            }
        }

        public async void QueryChargingStations()
        {
            var response = await _chargePointService.ChargingActivityAsync(10, _userService.Id);
            ChargingSessions = new ObservableCollection<ChargePointChargingSession>(response.SessionInfo);
        }

        private void Disconnect(object parameter)
        {
            _userService.Clear();
            App.NavigationService.Navigate<Views.ChargePointAuthView>();
        }
    }
}
