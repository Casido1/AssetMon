using AssetMon.Data.Repositories.Extensions.Utility;
using AssetMon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;

namespace AssetMon.Data.Repositories.Extensions
{
    public static class RepositoryVehicleExtension
    {
        public static IQueryable<Vehicle> FilterVehicles(this IQueryable<Vehicle> payments, DateTime startDate, DateTime endDate) =>
            payments.Where(p => p.StartDate >= startDate && p.StartDate <= endDate);

        public static IQueryable<Vehicle> Search(this IQueryable<Vehicle> vehicles, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return vehicles;

            var loweCaseTerm = searchTerm.Trim().ToLower();

            return vehicles.Where(v => v.Name.ToLower().Contains(searchTerm));
        }

        public static IQueryable<Vehicle> Sort(this IQueryable<Vehicle> vehicles, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return vehicles.OrderBy(p => p.StartDate);

            var orderQuery = OrderQueryBuilder.CreateOderQuery<Vehicle>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return vehicles.OrderBy(p => p.StartDate);

            return vehicles.OrderBy(orderQuery);
        }
    }
}
