using MyElectricCar.Commons;
using MyElectricCar.Services;
using MyElectricCar.Shared.Models;
using MyElectricCar.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MyElectricCar.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly UserService _userService;
        private readonly ChargePointService _chargePointService;

        private ICommand _disconnectCommand;

        private ChargePointChargingSession _chargingCurrent;
        private ObservableCollection<ChargePointChargingSession> _chargingHistory;
        private ChargePointVehicleInfo _primaryVehicle;

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

        public ObservableCollection<ChargePointChargingSession> ChargingHistory
        {
            get
            {
                return _chargingHistory;
            }

            private set
            {
                _chargingHistory = value;
                NotifyPropertyChanged();
            }
        }

        public ChargePointChargingSession ChargingCurrent
        {
            get
            {
                return _chargingCurrent;
            }

            private set
            {
                _chargingCurrent = value;
                NotifyPropertyChanged();
            }
        }

        public ChargePointVehicleInfo PrimaryVehicle
        {
            get
            {
                return _primaryVehicle;
            }

            private set
            {
                _primaryVehicle = value;
                NotifyPropertyChanged();
            }
        }

        public async void QueryChargingStations()
        {
            var response = await _chargePointService.ChargingActivityAsync(10, _userService.Id);
            var currentChargingIndex = response.SessionInfo.FindIndex(s => s.EnableStopCharging);
            if (currentChargingIndex != -1)
            {
                ChargingCurrent = response.SessionInfo[currentChargingIndex];
                response.SessionInfo.RemoveAt(currentChargingIndex);
            }

            ChargingHistory = new ObservableCollection<ChargePointChargingSession>(response.SessionInfo);
            PrimaryVehicle = response.VehicleInfo.FirstOrDefault(v => v.Value.IsPrimaryVehicle).Value;
        }

        private void Disconnect(object parameter)
        {
            _userService.Clear();
            App.NavigationService.Navigate<Views.ChargePointAuthView>();
        }
    }
}
