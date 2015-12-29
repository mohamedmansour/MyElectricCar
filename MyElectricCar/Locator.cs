using Autofac;
using MyElectricCar.Services;
using MyElectricCar.ViewModels;
using MyElectricCar.ViewModels.Interfaces;

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

        /// <summary>
        /// Set up all of the known view models, and instantiate the question repository.
        /// </summary>
        public Locator()
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            _container = builder.Build();
        }

        private void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<UserService>();
            builder.RegisterType<ChargePointService>().As<ChargePointService>();

            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            builder.RegisterType<ChargePointAuthViewModel>().As<IChargePointAuthViewModel>();
        }

        /// <summary>
        /// The ChargePointAuthView is databound to this property.
        /// </summary>
        public IChargePointAuthViewModel ChargePointAuthViewModel
        {
            get
            {
                return _container.Resolve<IChargePointAuthViewModel>();
            }
        }

        /// <summary>
        /// The MainView is databound to this property.
        /// </summary>
        public IMainViewModel MainViewModel
        {
            get
            {
                return _container.Resolve<IMainViewModel>();
            }
        }

        /// <summary>
        /// The ChargePointAuthView is databound to this property.
        /// </summary>
        public UserService UserService
        {
            get
            {
                return _container.Resolve<UserService>();
            }
        }
    }
}