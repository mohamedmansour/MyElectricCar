using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MyElectricCar.Models;
using MyElectricCar.ViewModels.Interfaces;

namespace MyElectricCar.ViewModels.Mocks
{
    public class MockMainViewModel : IMainViewModel
    {
        public ObservableCollection<ChargePointChargingSession> ChargingSessions
        {
            get
            {
                return new ObservableCollection<ChargePointChargingSession>
                {
                    new ChargePointChargingSession
                    {
                        CompanyId = 509,
                        SessionId = 36036197,
                        ChargingTime = 2349000,
                        CurrentCharging = "done",
                        Address1 = "1020 Enterprise Way",
                        VehicleId = 277903,
                        StateName = "California",
                        City = "Sunnyvale",
                        PowerKw = 0,
                        CompanyName = "Microsoft",
                        SessionTime = 2366000,
                        MilesAdded = 13.899909272727273,
                        Latitude = 37.40439224243164,
                        TotalAmount = 0.33,
                        Longitude = -122.03480529785156,
                        UpdatePeriod = 299800,
                        DeviceId = 107357,
                        OutletNumber = 2,
                        ApiFlag = false,
                        CurrencyIsoCode = "USD",
                        EndTime = 1450820809000,
                        StartOffset = -28800,
                        PortLevel = 2,
                        StartTime = 1450818443000,
                        PaymentType = "paid",
                        EnergyKwh = 3.775284
                    }
                };
            }

            set
            {
            }
        }

        public ICommand DisconnectCommand
        {
            get
            {
                return null;
            }
        }
    }
}
