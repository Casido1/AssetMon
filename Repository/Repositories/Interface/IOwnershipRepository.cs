using AssetMon.Models;

namespace AssetMon.Data.Repositories.Interface
{
    public interface IOwnershipRepository
    {
        Task CreateOwnershipAsync(Ownership ownership);
        Task DeleteOwnershipAsync(Ownership ownership);
        Task<Ownership> GetOwnershipById(string userId, string vehicleId, bool trackChanges);
    }
}
