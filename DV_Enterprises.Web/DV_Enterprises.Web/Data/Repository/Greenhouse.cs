using System;
using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Data.Repository.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository
{
    [Pluggable("Default")]
    public class Greenhouse : IGreenhouse
    {
        #region Static properties

        #endregion

        #region Instance properties

        public Connection Conn { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        public Greenhouse()
        {
            Conn = new Connection();
        }

        /// <summary>
        /// Find all Greenhouse's
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>return an IQueryable collection of Greenhouse</returns>
        public IList<Domain.Greenhouse> All(DataContext dc)
        {
            dc = dc ?? Conn.GetContext();
            var r = from g in dc.Greenhouses
                    select new Domain.Greenhouse
                    {
                        ID = g.GreenhouseID,
                        Address = new Address
                        {
                            City = g.City,
                            StateOrProvince = g.StateOrProvince,
                            Country = g.Country,
                            Zip = g.Zip,
                            StreetLine1 = g.StreetLine1,
                            StreetLine2 = g.StreetLine2,
                            IsDefault = g.IsDefault,
                        }

                    };
            return r.ToList();
        }

        /// <summary>
        /// Find an Greenhouse by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a Greenhouse</returns>
        public Domain.Greenhouse Find(DataContext dc, int id)
        {
            return All(dc).Where(g => g.ID == id).SingleOrDefault();
        }

        /// <summary>
        /// Save a Greenhouse
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="greenhouse"></param>
        /// <returns>returns the id of the saved greenhouse</returns>
        public int Save(DataContext dc, Domain.Greenhouse greenhouse)
        {
            dc = dc ?? Conn.GetContext();
            var dbGreenhouse = dc.Greenhouses.Where(g => g.GreenhouseID == greenhouse.ID).SingleOrDefault();
            var isNew = false;
            if (dbGreenhouse == null)
            {
                dbGreenhouse = new DataAccess.SqlRepository.Greenhouse();
                isNew = true;
            }

            dbGreenhouse.City = greenhouse.Address.City;
            dbGreenhouse.Country = greenhouse.Address.Country;
            dbGreenhouse.StateOrProvince = greenhouse.Address.StateOrProvince;
            dbGreenhouse.Zip = greenhouse.Address.Zip;
            dbGreenhouse.StreetLine1 = greenhouse.Address.StreetLine1;
            dbGreenhouse.StreetLine2 = greenhouse.Address.StreetLine2;
            dbGreenhouse.IsDefault = greenhouse.Address.IsDefault;
            dbGreenhouse.DateUpdated = DateTime.Now;

            if (isNew)
            {
                dbGreenhouse.DateCreated = DateTime.Now;
                dc.Greenhouses.InsertOnSubmit(dbGreenhouse);
            }
            dc.SubmitChanges();

            greenhouse.ID = dbGreenhouse.GreenhouseID;

            foreach (Domain.Section section in greenhouse.Sections)
            {
                section.Save();
            }

            return greenhouse.ID;
        }

        /// <summary>
        /// Delete a single greenhouse
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="greenhouse"></param>
        public void Delete(DataContext dc, Domain.Greenhouse greenhouse)
        {
            dc = dc ?? Conn.GetContext();
            var dbGreenhouse = dc.Greenhouses.Where(g => g.GreenhouseID == greenhouse.ID).SingleOrDefault();
            if (dbGreenhouse == null) return;
            dc.Greenhouses.Attach(dbGreenhouse, true);
            dc.Greenhouses.DeleteOnSubmit(dbGreenhouse);
            dc.SubmitChanges();
        }

        public IQueryable<Domain.Section> LoadSections(DataContext dc, int gId)
        {
            var r = Domain.Section.All(dc).Where(s => s.GreenhouseID == gId);
            return r;
        }

        public IQueryable<Domain.Section> LoadSections(int gId)
        {
            var r = Domain.Section.All().Where(s => s.GreenhouseID == gId);
            return r;
        }

        public List<Guid> LoadUsers(IEnumerable<Domain.Section> sections)
        {
            var result = new List<Guid>();
            foreach (var section in sections)
            {
                result.Add(section.UserID);
            }
            return result;
        }

        # endregion
    }
}