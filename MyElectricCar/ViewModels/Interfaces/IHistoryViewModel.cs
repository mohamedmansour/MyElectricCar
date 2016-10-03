using System.Collections.ObjectModel;
using MyElectricCar.Shared.Models;

namespace MyElectricCar.ViewModels.Interfaces
{
    public interface IHistoryViewModel
    {
        ObservableCollection<ChargePointChargingSession> ChargingHistory { get; }
    }
}
