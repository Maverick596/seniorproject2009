using System.Linq;
using DV_Enterprises.Web.Data.Domain;

namespace DV_Enterprises.Web.Data.Filters
{
    public static class GreenhouseUserFilters
    {
        public static IQueryable<GreenhouseUser> ByID(this IQueryable<GreenhouseUser> qry, int greenhouseUserID)
        {
            return from g in qry
                   where g.ID == greenhouseUserID
                   select g;
        }

        public static IQueryable<GreenhouseUser> ByGreenhouseID(this IQueryable<GreenhouseUser> qry, int greenhouseID)
        {
            return from g in qry
                   where g.GreenhouseID == greenhouseID
                   select g;
        }

        public static IQueryable<GreenhouseUser> ByUser(this IQueryable<GreenhouseUser> qry, string username)
        {
            return from g in qry
                   where g.Username.ToLower() == username.ToLower()
                   select g;
        }
    }
}