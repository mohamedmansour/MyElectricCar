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
        private Dictionary<string, ViewModelBase> modelSet = new Dictionary<string, ViewModelBase>();

        /// <summary>
        /// Set up all of the known view models, and instantiate the question repository.
        /// </summary>
        public ViewModelLocator()
        {
            //QuestionStore store = new QuestionStore();
            //InitializeStore(store);
            modelSet.Add("ChargePointAuthViewModel", new ChargePointAuthViewModel());
            //modelSet.Add("QuestionViewModel", new QuestionViewModel(store));
        }

        /// <summary>
        /// The ChargePointAuthView is databound to this property.
        /// </summary>
        public ChargePointAuthViewModel ChargePointAuthViewModel
        {
            get
            {
                return (ChargePointAuthViewModel)modelSet["ChargePointAuthViewModel"];
            }
        }

        /*
        private async void InitializeStore(QuestionStore store)
        {
            await store.LoadQuestions();
        }*/
    }
}