namespace AssetMon.Shared.DTOs
{
    public class PaymentDTO
    {
        public string Id { get; set; }

        public string VehicleId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
