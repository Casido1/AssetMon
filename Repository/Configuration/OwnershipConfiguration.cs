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
    public class OwnershipConfiguration : IEntityTypeConfiguration<Ownership>
    {
        public void Configure(EntityTypeBuilder<Ownership> builder)
        {
            builder.HasData
            (
                new { AppUsersId = "666e993e-bd32-4097-a572-702228c0df60", VehiclesId = "96d62347-64d8-425b-8a66-4b8cd78fc5a3" },
                new { AppUsersId = "666e993e-bd32-4097-a572-702228c0df60", VehiclesId = "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2" },
                new { AppUsersId = "666e993e-bd32-4097-a572-702228c0df60", VehiclesId = "3e187f49-53b8-4049-b12d-3c80ab7a9048" },
                new { AppUsersId = "666e993e-bd32-4097-a572-702228c0df60", VehiclesId = "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb" },
                new { AppUsersId = "1ee125f5-3be4-4bda-ae4c-d471762c414c", VehiclesId = "96d62347-64d8-425b-8a66-4b8cd78fc5a3" },
                new { AppUsersId = "6c649c3c-a0f1-4065-832a-193cd3d9085d", VehiclesId = "1c4690e6-3e15-40f6-a6a2-7bdfe48817a2" },
                new { AppUsersId = "21443f16-6bfb-4b07-8f35-d4a876266d5b", VehiclesId = "3e187f49-53b8-4049-b12d-3c80ab7a9048" },
                new { AppUsersId = "d23d56ce-9953-4647-b594-340a50bf7320", VehiclesId = "e6ab22dc-f77a-4b94-8bef-ff8d2c9d16cb" }
           
            );
        }
    }
}
