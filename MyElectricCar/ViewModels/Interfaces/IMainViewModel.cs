﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using MyElectricCar.Shared.Models;

namespace MyElectricCar.ViewModels.Interfaces
{
    public interface IMainViewModel
    {
        ICommand DisconnectCommand { get; }

        ChargePointChargingSession ChargingCurrent { get; }

        ObservableCollection<ChargePointChargingSession> ChargingHistory { get; }

        ChargePointVehicleInfo PrimaryVehicle { get; }
    }
}
