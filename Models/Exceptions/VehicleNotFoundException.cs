namespace AssetMon.Models.Exceptions
{
    public sealed class VehicleNotFoundException : NotFoundException
    {
        public VehicleNotFoundException(string vehicleId) : base($"The vehicle with id: {vehicleId} doesn't exist in the database.")
        {        
        }
    }
}
