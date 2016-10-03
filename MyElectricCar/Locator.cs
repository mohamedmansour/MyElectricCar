using Autofac;
using MyElectricCar.Services;
using MyElectricCar.Services.Interfaces;
using MyElectricCar.ViewModels;
using MyElectricCar.ViewModels.Interfaces;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MyElectricCar
{
    /// <summary>
    /// Locator ensures that viewmodels can be instantiated with a common reference
    /// This allows for easier decoupling of the store implementation and the view models, and allows for 
    /// less viewmodel specific code in the views.
    /// </summary>
    public class Locator
    {
        private IContainer _container;

        public Locator()
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            _container = builder.Build();
        }

        private void RegisterTypes(ContainerBuilder builder)
        {
            builder.Register(c => new NavigationService(Window.Current.Content as Frame)).As<INavigationService>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<ChargePointService>().As<IChargePointService>().SingleInstance();

            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            builder.RegisterType<HistoryViewModel>().As<IHistoryViewModel>();
            builder.RegisterType<ChargePointAuthViewModel>().As<IChargePointAuthViewModel>();
        }

        public IChargePointAuthViewModel ChargePointAuthViewModel => _container.Resolve<IChargePointAuthViewModel>();

        public IMainViewModel MainViewModel => _container.Resolve<IMainViewModel>();

        public IHistoryViewModel HistoryViewModel => _container.Resolve<IHistoryViewModel>();

        public IUserService UserService => _container.Resolve<IUserService>();

        public INavigationService NavigationService => _container.Resolve<INavigationService>();
    }
}