using AssetMon.Models;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;

namespace AssetMon.Data.Repositories.Extensions
{
    public static class RepositoryPaymentExtension
    {
        public static IQueryable<Payment> FilterPayments(this IQueryable<Payment> payments, DateTime startDate, DateTime endDate) => 
            payments.Where(p => p.Date >= startDate && p.Date <= endDate);

        //Search method to tansfered to repositoryVehicleEntension static class
        //public static IQueryable<Vehicle> Search(this IQueryable<Vehicle> vehicles, string searchTerm)
        //{
        //    if(string.IsNullOrWhiteSpace(searchTerm))
        //        return vehicles;

        //    var loweCaseTerm = searchTerm.Trim().ToLower();

        //    return vehicles.Where(v => v.PlateNumber.ToLower().Contains(searchTerm));
        //}

        public static IQueryable<Payment> Sort(this IQueryable<Payment> payments, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return payments.OrderBy(p => p.Date);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Payment).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi =>
               pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)
                    continue;
                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return payments.OrderBy(p => p.Date);
            return payments.OrderBy(orderQuery);
        }

    }
}
