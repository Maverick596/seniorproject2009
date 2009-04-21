using System;
using DV_Enterprises.Web.DAL;

namespace DV_Enterprises.Web.BLL
{
    public class BaseCustomerEntity:BaseEntity
    {
        private static CustomerElement Settings
        {
            get { return Globals.Settings.Customers; }
        }

        protected static bool CachingEnabled
        {
            get { return Settings.EnableCaching; }
        }

        protected static DataContext GetContext()
        {
            return new DataContext(Settings.ConnectionString);
        }

        protected static void CacheData(string key, object data)
        {
            if (CachingEnabled && data != null)
            {
                Cache.Insert(key, data, null, DateTime.Now.AddSeconds(Settings.CacheDuration), TimeSpan.Zero);
            }
        }
        
    }
}