using System;
using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Abstract;
using DV_Enterprises.Web.Data.Domain.Interface;
using DV_Enterprises.Web.Data.Utility;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class Greenhouse : DomainModel, IGreenhouse
    {
        #region Static properties

        #endregion

        #region Instance properties

        public int ID { get; set; }
        public Address Address { get; set; }
        public LazyList<Section> Sections { get; set; }
        public List<Guid> UserIDs { get; set; }

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
            dc = dc ?? Conn.GetContext();
            var r = from g in dc.Greenhouses
                    let location = Address.Find(dc, g.Address.AddressID)
                    let sections = LoadSections(dc, g.GreenhouseID)
                    let users = LoadUsers(sections)
                    select new Greenhouse
                               {
                                   ID = g.GreenhouseID,
                                   Address = location,
                                   Sections = new LazyList<Section>(sections),
                                   UserIDs = users
                               };
            return r.ToList();
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
            return All(dc).Where(g => g.ID == id).SingleOrDefault();
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
            dc = dc ?? Conn.GetContext();
                var dbGreenhouse = dc.Greenhouses.Where(g => g.GreenhouseID == greenhouse.ID).SingleOrDefault();
                var isNew = false;
                if (dbGreenhouse == null)
                {
                    dbGreenhouse = new DataAccess.SqlRepository.Greenhouse();
                    isNew = true;
                }

                if (greenhouse.Address != null)
                    greenhouse.Address.Save();

                foreach (Section section in greenhouse.Sections)
                {
                    section.Save();
                }

                if (isNew)
                    dc.Greenhouses.InsertOnSubmit(dbGreenhouse);
                dc.SubmitChanges();
                return dbGreenhouse.GreenhouseID;
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
            dc = dc ?? Conn.GetContext();
                var dbGreenhouse = dc.Greenhouses.Where(g => g.GreenhouseID == greenhouse.ID).SingleOrDefault();
                if (dbGreenhouse == null) return;
                dc.Greenhouses.Attach(dbGreenhouse, true);
                dc.Greenhouses.DeleteOnSubmit(dbGreenhouse);
                dc.SubmitChanges();
            }


        /// <summary>
        /// Loads all connected sections
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="gId"></param>
        /// <returns></returns>
        private static IQueryable<Section> LoadSections(DataContext dc, int gId)
        {
            var r = Section.All(dc).Where(s => s.GreenhouseID == gId);
            return r;
        }

        private static List<Guid> LoadUsers(IEnumerable<Section> sections)
        {
            List<Guid> result = new List<Guid>();
            foreach (var section in sections)
            {
                result.Add(section.UserID);
            }
            return result;
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
    }
}