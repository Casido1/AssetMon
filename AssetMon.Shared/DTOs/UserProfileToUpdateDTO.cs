using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Shared.DTOs
{
    public class UserProfileToUpdateDTO
    {
        public string AppUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateOnly DateOfBirth { get; set; }
    }
}
