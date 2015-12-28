using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyElectricCar.ViewModel
{
    /// <summary>
    /// ViewModelLocator ensures that viewmodels can be instantiated with a common reference to the QuestionStore. 
    /// This allows for easier decoupling of the store implementation and the view models, and allows for 
    /// less viewmodel specific code in the views.
    /// </summary>
    public class ViewModelLocator
    {
        private IContainer _container;

        /// <summary>
        /// Set up all of the known view models, and instantiate the question repository.
        /// </summary>
        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            _container = builder.Build();
        }

        private void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<ChargePointAuthViewModel>().As<ChargePointAuthViewModel>();
        }

        /// <summary>
        /// The ChargePointAuthView is databound to this property.
        /// </summary>
        public ChargePointAuthViewModel ChargePointAuthViewModel
        {
            get
            {
                return _container.Resolve<ChargePointAuthViewModel>();
            }
        }
    }
}