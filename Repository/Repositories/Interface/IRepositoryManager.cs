namespace AssetMon.Data.Repositories.Interface
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IVehicleRepository Vehicle { get; }
        IPaymentRepository Payment { get; }
        IOwnershipRepository Ownership { get; }
        IAddressRepository Address { get; }
        IRepairRepository Repair { get; }
        Task SaveAsync();
    }
}
