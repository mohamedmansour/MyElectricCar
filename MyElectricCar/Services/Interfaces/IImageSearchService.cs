using System.Threading.Tasks;
using MyElectricCar.Shared.Models;

namespace MyElectricCar.Services.Interfaces
{
    public interface IImageSearchService
    {
        Task<ImageSearch> Search(string query);
    }
}
