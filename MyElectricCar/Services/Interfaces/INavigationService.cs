using System;

namespace MyElectricCar.Services.Interfaces
{
    /// <summary>
    /// Navigation service interface, allows a test implementation to be substituted in its place.
    /// </summary>
    public interface INavigationService
    {
        bool Navigate<T>(object parameter = null);

        bool Navigate(Type source, object parameter = null);

        void GoBack();
    }
}