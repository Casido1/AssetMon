namespace AssetMon.Shared.DTOs
{
    public class VehicleRepairToUpdateDTO
    {
        public string VehicleId { get; set; }
        public string RepairName { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
