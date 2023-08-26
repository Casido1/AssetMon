using AssetMon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetMon.Data.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData
            (
                new Address
                {
                    UserProfileId = "1ee125f5-3be4-4bda-ae4c-d471762c414c",
                    Street = "3 Twin Tower, Igbogo Road, Choba",
                    City = "PortHarcourt",
                    State = "Rivers",
                    Country = "Nigeria"
                },

                new Address
                {
                    UserProfileId = "6c649c3c-a0f1-4065-832a-193cd3d9085d",
                    Street = "4 Twin Tower, Igbogo Road, Choba",
                    City = "PortHarcourt",
                    State = "Rivers",
                    Country = "Nigeria"
                },

                new Address
                {
                    UserProfileId = "21443f16-6bfb-4b07-8f35-d4a876266d5b",
                    Street = "5 Twin Tower, Igbogo Road, Choba",
                    City = "PortHarcourt",
                    State = "Rivers",
                    Country = "Nigeria"
                },

                new Address
                {
                    UserProfileId = "d23d56ce-9953-4647-b594-340a50bf7320",
                    Street = "6 Twin Tower, Igbogo Road, Choba",
                    City = "PortHarcourt",
                    State = "Rivers",
                    Country = "Nigeria"
                },

                new Address
                {
                    UserProfileId = "666e993e-bd32-4097-a572-702228c0df60",
                    Street = "4 radio Estate, Ozuoba",
                    City = "PortHarcourt",
                    State = "Rivers",
                    Country = "Nigeria"
                }
            );
        }
    }
}
