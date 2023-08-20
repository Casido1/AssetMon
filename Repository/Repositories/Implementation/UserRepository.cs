using AssetMon.Data.Repositories.Interface;
using AssetMon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Data.Repositories.Implementation
{
    internal sealed class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        public UserRepository(AssetMonContext context) : base(context)
        {
        }
    }
}
