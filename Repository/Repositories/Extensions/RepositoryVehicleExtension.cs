using AssetMon.Data.Repositories.Extensions.Utility;
using AssetMon.Models;
using System.Linq.Dynamic.Core;

namespace AssetMon.Data.Repositories.Extensions
{
    public static class RepositoryVehicleExtension
    {
        public static IQueryable<Vehicle> FilterVehicles(this IQueryable<Vehicle> vehicles, DateTime startDate, DateTime endDate) =>
            vehicles.Where(v => v.StartDate >= startDate && v.StartDate <= endDate);

        public static IQueryable<Vehicle> Search(this IQueryable<Vehicle> vehicles, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return vehicles;

            var loweCaseTerm = searchTerm.Trim().ToLower();

            return vehicles.Where(v => v.PlateNumber.ToLower().Contains(searchTerm));
        }

        public static IQueryable<Vehicle> Sort(this IQueryable<Vehicle> vehicles, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return vehicles.OrderBy(v => v.StartDate);

            var orderQuery = OrderQueryBuilder.CreateOderQuery<Vehicle>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return vehicles.OrderBy(v => v.StartDate);

            return vehicles.OrderBy(orderQuery);
        }
    }
}
