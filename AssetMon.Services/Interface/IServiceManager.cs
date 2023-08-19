namespace AssetMon.Services.Interface
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IVehicleService VehicleService { get; }
        IPaymentService PaymentService { get; }
        IAuthenticationService AuthenticationService { get; }
        IPictureService PictureService { get; }
    }
}
