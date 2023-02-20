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
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData
            (
                new AppUser
                {
                    Id = "1ee125f5-3be4-4bda-ae4c-d471762c414c",
                    FirstName = "Ahmed",
                    LastName = "Sani",
                    Email = "ahmedsani@gmail.com",
                },

                new AppUser
                {
                    Id = "6c649c3c-a0f1-4065-832a-193cd3d9085d",
                    FirstName = "Idris",
                    LastName = "Salisu",
                    Email = "idrissalisu@gmail.com",
                },

                new AppUser
                {
                    Id = "21443f16-6bfb-4b07-8f35-d4a876266d5b",
                    FirstName = "Abubakar",
                    LastName = "Mohammed",
                    Email = "abubakarmohammed@gmail.com",
                },

                new AppUser
                {
                    Id = "d23d56ce-9953-4647-b594-340a50bf7320",
                    FirstName = "Hamza",
                    LastName = "Isah",
                    Email = "hamzaisah@gmail.com",
                },

                new AppUser
                {
                    Id = "666e993e-bd32-4097-a572-702228c0df60",
                    FirstName = "Ugochukwu",
                    LastName = "Anunihu",
                    Email = "ugochukwu.anunihu@gmail.com",
                }
            );
        }
    }
}
