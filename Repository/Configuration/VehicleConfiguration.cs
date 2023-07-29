using AssetMon.Models;
using AssetMon.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Data.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasData
            (
                new Vehicle
                {
                    Id = "96d62347-64d8-425b-8a66-4b8cd78fc5a3",
                    Name = "TVS",
                    PlateNumber = "TVS-UMG-210-QR",
                    Color = "Blue",
                    ContractType = Contracts.ContinuedOwnership,
                    PaymentAmount = 16000,
                    PaymentFrequency = PaymentFrequency.Weekly,
                    StartDate = new DateTime(2022, 1, 1)
                },

                new Vehicle
                {
                    Id = "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2",
                    Name = "Piaggio",
                    Color = "Blue",
                    ContractType = Contracts.ContinuedOwnership,
                    PaymentAmount = 16000,
                    PaymentFrequency = PaymentFrequency.Weekly,
                    StartDate = new DateTime(2022, 1, 1)
                },

                new Vehicle
                {
                    Id = "3e187f49-53b8-4049-b12d-3c80ab7a9048",
                    Name = "TVS",
                    PlateNumber = "TVS-M4L03958",
                    Color = "Blue",
                    ContractType = Contracts.ContinuedOwnership,
                    PaymentAmount = 16000,
                    PaymentFrequency = PaymentFrequency.Weekly,
                    StartDate = new DateTime(2022, 1, 1)
                },

                new Vehicle
                {
                    Id = "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb",
                    Name = "TVS",
                    PlateNumber = "TVS-M4L03941",
                    Color = "Blue",
                    ContractType = Contracts.ContinuedOwnership,
                    PaymentAmount = 16000,
                    PaymentFrequency = PaymentFrequency.Weekly,
                    StartDate = new DateTime(2022, 1, 1)
                }
            );
        }
    }
}
