using MyElectricCar.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyElectricCar.ViewModels.Interfaces
{
    public interface IMainViewModel
    {
        ICommand DisconnectCommand { get; }

        ObservableCollection<ChargePointChargingSession> ChargingSessions { get; }
    }
}
