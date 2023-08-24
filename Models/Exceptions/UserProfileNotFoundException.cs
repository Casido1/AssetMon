using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Models.Exceptions
{
    public class UserProfileNotFoundException : NotFoundException
    {
        public UserProfileNotFoundException(string userId) : base($"The user with id: {userId} doesn't exist in the database.")
        {
                
        }
    }
}
