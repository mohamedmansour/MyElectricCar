namespace MyElectricCar.Services.Interfaces
{
    public interface IUserService
    {
        string AccessToken { get; set; }
        long Id { get; set; }
        bool IsAuthenticated { get; }

        void Clear();
    }
}