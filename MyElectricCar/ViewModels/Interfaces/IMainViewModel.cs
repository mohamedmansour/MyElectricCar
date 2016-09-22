using MyElectricCar.Shared.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyElectricCar.ViewModels.Interfaces
{
    public interface IMainViewModel
    {
        ICommand DisconnectCommand { get; }

        ChargePointChargingSession ChargingCurrent { get; }

        ObservableCollection<ChargePointChargingSession> ChargingHistory { get; }

        ChargePointVehicleInfo PrimaryVehicle { get; }
    }
}
