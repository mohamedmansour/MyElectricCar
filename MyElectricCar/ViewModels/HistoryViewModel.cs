using System.Collections.ObjectModel;
using System.Windows.Input;
using MyElectricCar.Services;
using MyElectricCar.Shared.Models;
using MyElectricCar.ViewModels.Interfaces;

namespace MyElectricCar.ViewModels
{
    public class HistoryViewModel : ViewModelBase, IHistoryViewModel
    {
        private readonly UserService _userService;
        private readonly ChargePointService _chargePointService;

        private ObservableCollection<ChargePointChargingSession> _chargingHistory;

        public HistoryViewModel(UserService userService, ChargePointService chargePointService)
        {
            _userService = userService;
            _chargePointService = chargePointService;
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

        public async void QueryChargingStations()
        {
            var response = await _chargePointService.ChargingActivityAsync(10, _userService.Id);
            var currentChargingIndex = response.SessionInfo.FindIndex(s => s.EnableStopCharging);
            if (currentChargingIndex != -1)
            {
                response.SessionInfo.RemoveAt(currentChargingIndex);
            }

            ChargingHistory = new ObservableCollection<ChargePointChargingSession>(response.SessionInfo);
        }
    }
}
