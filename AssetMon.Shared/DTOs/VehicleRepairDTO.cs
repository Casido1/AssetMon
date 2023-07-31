namespace AssetMon.Shared.DTOs
{
    public class VehicleRepairDTO
    {
        public string Id { get; set; }
        public string VehicleId { get; set; }
        public string RepairName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
