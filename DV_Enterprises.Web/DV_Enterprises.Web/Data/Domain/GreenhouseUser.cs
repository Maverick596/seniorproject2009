using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;

namespace DV_Enterprises.Web.Data.Domain
{
    public class GreenhouseUser
    {
        #region Static properties

        private static readonly Repository.GreenhouseUserRepository Repository = new Repository.GreenhouseUserRepository();

        #endregion

        public int ID { get; set; }
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public int GreenhouseID { get; set; }
        public Greenhouse Greenhouse { get; set; }

        #region Static Methods

        public static IQueryable<GreenhouseUser> All()
        {
            return All(null);
        }

        public static IQueryable<GreenhouseUser> All(DataContext dc)
        {
            return Repository.All(dc);
        }

        static public GreenhouseUser Find(int id)
        {
            return Find(null, id);
        }

        static public GreenhouseUser Find(DataContext dc, int id)
        {
            return Repository.Find(dc, id);
        }

        public static int Save(GreenhouseUser greenhouseUser)
        {
            return Save(null, greenhouseUser);
        }

        public static int Save(DataContext dc, GreenhouseUser greenhouseUser)
        {
            return Repository.Save(dc, greenhouseUser);
        }

        public static void Delete(GreenhouseUser greenhouseUser)
        {
            Delete(null, greenhouseUser);
        }

        public static void Delete(DataContext dc, GreenhouseUser greenhouseUser)
        {
            Repository.Delete(dc, greenhouseUser);
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Save GreenhouseUser
        /// </summary>
        /// <returns>ID</returns>
        public int Save()
        {
            return Save(this);
        }

        /// <summary>
        /// Save GreenhouseUser
        /// </summary>
        /// <returns>ID</returns>
        public int Save(DataContext dc)
        {
            return Save(dc, this);
        }


        /// <summary>
        /// Delete GreenhouseUser
        /// </summary>
        public void Delete()
        {
            Delete(this);
        }

        /// <summary>
        /// Delete GreenhouseUser
        /// </summary>
        public void Delete(DataContext dc)
        {
            Delete(dc, this);
        }

        #endregion
    }
}