using AssetMon.Data.Repositories.Extensions.Utility;
using AssetMon.Models;
using System.Linq.Dynamic.Core;

namespace AssetMon.Data.Repositories.Extensions
{
    public static class RepositoryVehicleRepairExtension
    {
        public static IQueryable<VehicleRepair> FilterVehicleRepairs(this IQueryable<VehicleRepair> repairs, DateTime startDate, DateTime endDate) =>
            repairs.Where(r => r.Date >= startDate && r.Date <= endDate);

        public static IQueryable<VehicleRepair> Sort(this IQueryable<VehicleRepair> repairs, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return repairs.OrderBy(r => r.Date);

            var orderQuery = OrderQueryBuilder.CreateOderQuery<VehicleRepair>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return repairs.OrderBy(r => r.Date);
            return repairs.OrderBy(orderQuery);
        }
    }
}
