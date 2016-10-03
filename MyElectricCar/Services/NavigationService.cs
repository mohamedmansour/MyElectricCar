using System;
using Windows.UI.Xaml.Controls;
using MyElectricCar.Services.Interfaces;

namespace MyElectricCar.Services
{
    /// <summary>
    /// Navigation system that decouples the View Model from knowledge of the View for navigation
    /// purposes. This class can be replaced with a simple mock implementation for test purposes.
    /// </summary>
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// Keep track of the main Frame object, so we can issue Navigation calls to it, without
        /// the view models needing to maintain a reference to the views.
        /// </summary>
        private readonly Frame frame;

        public NavigationService(Frame frame)
        {
            this.frame = frame;
        }

        /// <summary>
        /// Navigate to the target page of type T
        /// </summary>
        /// <typeparam name="T">Type of the view to navigate to.</typeparam>
        /// <param name="parameter">Any parameters to pass to the newly loaded view</param>
        /// <returns></returns>
        public bool Navigate<T>(object parameter = null)
        {
            var type = typeof(T);

            return Navigate(type, parameter);
        }

        /// <summary>
        /// Navigate to the target page of the specified type.
        /// </summary>
        /// <param name="t">Type of the view to navigate to.</typeparam>
        /// <param name="parameter">Any parameters to pass to the newly loaded view</param>
        /// <returns></returns>
        public bool Navigate(Type t, object parameter = null)
        {
            return frame.Navigate(t, parameter);
        }

        /// <summary>
        ///  Goes back a page in the back stack.
        /// </summary>
        public void GoBack()
        {
            frame.GoBack();
        }
    }
}
