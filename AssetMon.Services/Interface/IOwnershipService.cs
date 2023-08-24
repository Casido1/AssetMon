namespace AssetMon.Services.Interface
{
    public interface IOwnershipService
    {
        Task CreateOwnershipAsync(string userId, string vehicleId, bool trackChanges);
        Task DeleteOwnershipAsync(string userId, string vehicleId, bool trackChanges);
        Task UpdateOwnershipAsync(string userId, string vehicleId, bool trackChanges);
    }
}
