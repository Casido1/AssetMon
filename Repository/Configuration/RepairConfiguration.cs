using AssetMon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Data.Configuration
{
    public class RepairConfiguration : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder)
        {
            builder.HasData
            (
                new Repair
                {
                    Id = "f6040dcd-c639-4b07-94ce-0c7ef58d7250",
                    RepairName = "Shoe brakes",
                    Amount = 3000,
                    AssetId = "3e187f49-53b8-4049-b12d-3c80ab7a9048"
                },

                new Repair
                {
                    Id = "8c5ccdaa-eda0-4d29-94cc-aac10a0883f1",
                    RepairName = "Shoe brakes",
                    Amount = 3000,
                    AssetId = "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2"
                }
            ); ;
        }
    }
}
