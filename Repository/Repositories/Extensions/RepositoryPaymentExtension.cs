using AssetMon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
