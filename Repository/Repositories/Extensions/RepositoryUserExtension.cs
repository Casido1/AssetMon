using AssetMon.Data.Repositories.Extensions.Utility;
using AssetMon.Models;
using System.Linq.Dynamic.Core;

namespace AssetMon.Data.Repositories.Extensions
{
    public static class RepositoryUserExtension
    {
        public static IQueryable<UserProfile> FilterUsers(this IQueryable<UserProfile> users, DateTime startDate, DateTime endDate) =>
          users.Where(u => u.CreatedOn >= startDate && u.CreatedOn <= endDate);

        public static IQueryable<UserProfile> Search(this IQueryable<UserProfile> users, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return users;

            var loweCaseTerm = searchTerm.Trim().ToLower();

            return users.Where(u => u.UserName.ToLower().Contains(searchTerm));
        }

        public static IQueryable<UserProfile> Sort(this IQueryable<UserProfile> users, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return users.OrderBy(u => u.CreatedOn);

            var orderQuery = OrderQueryBuilder.CreateOderQuery<Vehicle>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return users.OrderBy(u => u.CreatedOn);

            return users.OrderBy(orderQuery);
        }
    }
}
