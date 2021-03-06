﻿using System.Threading.Tasks;
using MyElectricCar.Shared.Models;

namespace MyElectricCar.Services.Interfaces
{
    public interface IElectricChargeService
    {
        Task<ChargePointAuthResponse> AuthenticateAsync(string username, string password);
        Task<ChargePointActivityResponse> ChargingActivityAsync(int pageSize, long userId);
    }
}