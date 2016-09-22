using MyElectricCar.Shared.Models;
using System.Collections.ObjectModel;

namespace MyElectricCar.ViewModels.Interfaces
{
    public interface IHistoryViewModel
    {
        ObservableCollection<ChargePointChargingSession> ChargingHistory { get; }
    }
}
