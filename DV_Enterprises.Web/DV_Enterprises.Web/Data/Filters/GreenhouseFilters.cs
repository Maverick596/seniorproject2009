using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.Domain;

namespace DV_Enterprises.Web.Data.Filters
{
    public static class GreenhouseFilters
    {
        public static Greenhouse ByID(this IQueryable<Greenhouse> qry, int greenhouseID)
        {
            return (qry.Where(g => g.ID == greenhouseID)).SingleOrDefault();
        }

        public static IQueryable<Greenhouse> ByUser(this IQueryable<Greenhouse> qry, string username)
        {
            return qry.Where(g => g.Usernames.Contains(username));
        }
    }
}