using MyElectricCar.Shared.Models;
using System.Threading.Tasks;

namespace MyElectricCar.Services.Interfaces
{
    public interface IConfigService
    {
        AppSettings AppSettings { get; }
    }
}
