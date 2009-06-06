using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Interface;
using DV_Enterprises.Web.Data.Filters;
using DV_Enterprises.Web.Data.Utility;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class Greenhouse : IGreenhouse
    {
        #region Static properties

        private static readonly Repository.GreenhouseRepository Repository = new Repository.GreenhouseRepository();

        #endregion

        #region Instance properties

        public int ID { get; set; }
        public Address Address { get; set; }
        public LazyList<Section> Sections { get; set; }
        public LazyList<GreenhouseUser> GreenhouseUsers { get; set; }
        public List<string> Usernames { get; set; }

        #endregion

        # region Static Methods

        /// <summary>
        /// Find all Greenhouse's
        /// </summary>
        /// <returns>return an IQueryable collection of Greenhouse</returns>
        public static IQueryable<Greenhouse> All()
        {
            return All(null);
        }

        /// <summary>
        /// Find all Greenhouse's
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>return an IQueryable collection of Greenhouse</returns>
        public static IQueryable<Greenhouse> All(DataContext dc)
        {
            return Repository.All(dc);
        }

        public static IQueryable<Greenhouse> AllByUsername(string username)
        {
            return AllByUsername(null, username);
        }

        public static IQueryable<Greenhouse> AllByUsername(DataContext dc, string username)
        {
            if (username == null) All(dc);
            return Repository.All(dc, username);
        }

        public static Greenhouse ByID(int greebhouseID)
        {
            return ByID(null, greebhouseID);
        }

        public static Greenhouse ByID(DataContext dc, int greebhouseID)
        {
            return All(dc).ByID(greebhouseID);
        }

        /// <summary>
        /// Save a Greenhouse
        /// </summary>
        /// <param name="greenhouse"></param>
        /// <returns>returns the id of the saved greenhouse</returns>
        public static int Save(Greenhouse greenhouse)
        {
            return Save(null, greenhouse);
        }

        /// <summary>
        /// Save a Greenhouse
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="greenhouse"></param>
        /// <returns>returns the id of the saved greenhouse</returns>
        public static int Save(DataContext dc, Greenhouse greenhouse)
        {
            return Repository.Save(dc, greenhouse);
        }

        /// <summary>
        /// Delete a single greenhouse
        /// </summary>
        /// <param name="greenhouse"></param>
        public static void Delete(Greenhouse greenhouse)
        {
            Delete(null, greenhouse);
        }

        /// <summary>
        /// Delete a single greenhouse
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="greenhouse"></param>
        public static void Delete(DataContext dc, Greenhouse greenhouse)
        {
            Repository.Delete(dc, greenhouse);
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Save Greenhouse
        /// </summary>
        /// <returns>ID</returns>
        public int Save()
        {
            return Save(this);
        }

        /// <summary>
        /// Save Greenhouse
        /// </summary>
        /// <returns>ID</returns>
        public int Save(DataContext dc)
        {
            return Save(dc, this);
        }


        /// <summary>
        /// Delete Greenhouse
        /// </summary>
        public void Delete()
        {
            Delete(this);
        }

        /// <summary>
        /// Delete Greenhouse
        /// </summary>
        public void Delete(DataContext dc)
        {
            Delete(dc, this);
        }

        #endregion

        # region object overrides

        public override string ToString()
        {
            return string.Format("Greenhouse {0}", ID);
        }

        #endregion
    }
}