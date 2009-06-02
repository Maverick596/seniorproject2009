using System;
using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Interface;
using DV_Enterprises.Web.Data.Utility;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class Greenhouse : IGreenhouse
    {
        #region Static properties

        private static readonly Repository.Greenhouse Repository = new Repository.Greenhouse();

        #endregion

        #region Instance properties

        private List<Guid> _userIDs;
        private LazyList<Section> _sections;

        public int ID { get; set; }
        public Address Address { get; set; }
        public LazyList<Section> Sections
        {
            get { return _sections ?? (Sections = new LazyList<Section>(LoadSections(ID))); }
            set { _sections = value; }
        }
        public List<Guid> UserIDs
        {
            get { return _userIDs ?? (UserIDs = LoadUsers(Sections)); }
            set { _userIDs = value; }
        }

        #endregion

        # region Static Methods

        /// <summary>
        /// Find all Greenhouse's
        /// </summary>
        /// <returns>return an IQueryable collection of Greenhouse</returns>
        public static IList<Greenhouse> All()
        {
            return All(null);
        }

        /// <summary>
        /// Find all Greenhouse's
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>return an IQueryable collection of Greenhouse</returns>
        public static IList<Greenhouse> All(DataContext dc)
        {
            return Repository.All(dc);
        }

        /// <summary>
        /// Find an Greenhouse by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a Greenhouse</returns>
        public static Greenhouse Find(int id)
        {
            return Find(null, id);
        }

        /// <summary>
        /// Find an Greenhouse by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a Greenhouse</returns>
        public static Greenhouse Find(DataContext dc, int id)
        {
            return Repository.Find(dc, id);
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


        /// <summary>
        /// Loads all connected sections
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="gId"></param>
        /// <returns></returns>
        private static IQueryable<Section> LoadSections(DataContext dc, int gId)
        {
            return Repository.LoadSections(dc, gId);
        }

        private static IQueryable<Section> LoadSections(int gId)
        {
            return LoadSections(null, gId);
        }

        private static List<Guid> LoadUsers(IEnumerable<Section> sections)
        {
            return Repository.LoadUsers(sections);
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