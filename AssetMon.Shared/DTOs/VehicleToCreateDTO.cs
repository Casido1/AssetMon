using System.ComponentModel.DataAnnotations;

namespace AssetMon.Shared.DTOs
{
    public class VehicleToCreateDTO
    {
        [MaxLength(20, ErrorMessage = "Maximum length for the Name is 20 characters.")]
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "Maximum length for the Name is 20 characters.")]
        public string PlateNumber { get; set; }

        [MaxLength(20, ErrorMessage = "Maximum length for the Name is 20 characters.")]
        public string Color { get; set; }

        public int ContractType { get; set; }

        public int Tenure { get; set; }

        public decimal PaymentAmount { get; set; }

        public int PaymentFrequency { get; set; }

        public bool IsActive { get; set; } = false;

        public DateTime StartDate { get; set; }
    }
}
