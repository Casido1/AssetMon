using AssetMon.Models;

namespace AssetMon.Shared.DTOs
{
    public class UserProfileDTO
    {
        public string AppUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PhotoUrl { get; set; }

        public DateTime DateOfBirth { get; set; }

        public AddressDTO Address { get; set; }
    }
}
