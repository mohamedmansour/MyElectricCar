using System.Windows.Input;

namespace MyElectricCar.ViewModels.Interfaces
{
    public interface IChargePointAuthViewModel
    {
        ICommand ConnectCommand { get; }

        string Username { get; set; }

        string Password { get; set; }
    }
}
