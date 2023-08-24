namespace AssetMon.Models.Exceptions
{
    public sealed class OwnershipNotFoundException : NotFoundException
    {
        public OwnershipNotFoundException(string userId, string vehicleId) : base($"The Ownership for user with id: {userId} and vehicle with id : {vehicleId} doesn't exist in the database.")
        {
                
        }
    }
}
