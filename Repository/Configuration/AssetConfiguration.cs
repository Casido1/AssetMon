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
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasData
            (
                new Vehicle
                {
                    Id = "96d62347-64d8-425b-8a66-4b8cd78fc5a3",
                    Name = "TVS",
                    PlateNumber = "TVS-UMG-210-QR",
                    Color = "Blue"
                }
            );
        }
    }
}
