using System.Windows.Input;
using MyElectricCar.ViewModels.Interfaces;

namespace MyElectricCar.ViewModels.Mocks
{
    public class MockChargePointAuthViewModel : IChargePointAuthViewModel
    {
        public ICommand ConnectCommand
        {
            get
            {
                return null;
            }
        }

        public string Password
        {
            get
            {
                return "1234";
            }

            set
            {
            }
        }

        public string Username
        {
            get
            {
                return "aliens";
            }

            set
            {
            }
        }
    }
}
