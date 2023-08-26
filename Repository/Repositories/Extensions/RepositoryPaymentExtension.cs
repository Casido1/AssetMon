using AssetMon.Data.Repositories.Extensions.Utility;
using AssetMon.Models;
using System.Linq.Dynamic.Core;

namespace AssetMon.Data.Repositories.Extensions
{
    public static class RepositoryPaymentExtension
    {
        public static IQueryable<Payment> FilterPayments(this IQueryable<Payment> payments, DateTime startDate, DateTime endDate) => 
            payments.Where(p => p.Date >= startDate && p.Date <= endDate);

        public static IQueryable<Payment> Sort(this IQueryable<Payment> payments, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return payments.OrderBy(p => p.Date);

            var orderQuery = OrderQueryBuilder.CreateOderQuery<Payment>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return payments.OrderBy(p => p.Date);
            return payments.OrderBy(orderQuery);
        }
    }
}
