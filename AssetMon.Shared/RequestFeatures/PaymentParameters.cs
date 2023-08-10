namespace AssetMon.Shared.RequestFeatures
{
    public class PaymentParameters : RequestParameters
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } = DateTime.MaxValue;
        public bool ValidDateRange => EndDate > StartDate;
    }
}
