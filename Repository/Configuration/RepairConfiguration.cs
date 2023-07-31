using AssetMon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetMon.Data.Configuration
{
    public class RepairConfiguration : IEntityTypeConfiguration<VehicleRepair>
    {
        public void Configure(EntityTypeBuilder<VehicleRepair> builder)
        {
            builder.HasData
            (
                new VehicleRepair
                {
                    Id = "f6040dcd-c639-4b07-94ce-0c7ef58d7250",
                    RepairName = "Shoe brakes",
                    Amount = 3000,
                    VehicleId = "3e187f49-53b8-4049-b12d-3c80ab7a9048"
                },

                new VehicleRepair
                {
                    Id = "8c5ccdaa-eda0-4d29-94cc-aac10a0883f1",
                    RepairName = "Shoe brakes",
                    Amount = 3000,
                    VehicleId = "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2"
                }
            ); ;
        }
    }
}
