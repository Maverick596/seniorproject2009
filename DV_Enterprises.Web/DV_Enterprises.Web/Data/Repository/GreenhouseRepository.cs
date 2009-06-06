using System;
using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Data.Filters;
using DV_Enterprises.Web.Data.Repository.Interface;
using DV_Enterprises.Web.Data.Utility;
using StructureMap;
using GreenhouseUser=DV_Enterprises.Web.Data.Domain.GreenhouseUser;
using Section=DV_Enterprises.Web.Data.Domain.Section;

namespace DV_Enterprises.Web.Data.Repository
{
    [Pluggable("Default")]
    public class GreenhouseRepository : IGreenhouseRepository
    {
        #region Static properties

        #endregion

        #region Instance properties

        public Connection Conn { get; set; }
        public List<string> Usernames { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        public GreenhouseRepository()
        {
            Conn = new Connection();
            Usernames = new List<string>();
        }

        /// <summary>
        /// Find all Greenhouse's
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>return an IQueryable collection of Greenhouse</returns>
        public IQueryable<Domain.Greenhouse> All(DataContext dc)
        {
            dc = dc ?? Conn.GetContext();
            var r = from g in dc.Greenhouses
                    let greenhouseUsers = LoadGreenhouseUsers(dc, g.GreenhouseID)
                    let sections = LoadSections(dc, g.GreenhouseID)
                    select new Domain.Greenhouse
                    {
                        ID = g.GreenhouseID,
                        GreenhouseUsers = new LazyList<GreenhouseUser>(greenhouseUsers),
                        Sections = new LazyList<Section>(sections),
                        Usernames = Usernames,
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
            return r;
        }

        public IQueryable<Domain.Greenhouse> All(DataContext dc, string username)
        {
            dc = dc ?? Conn.GetContext();
            var r = from g in dc.Greenhouses
                    join gu in dc.GreenhouseUsers on g.GreenhouseID equals gu.GreenhouseId
                    let greenhouseUsers = LoadGreenhouseUsers(dc, g.GreenhouseID)
                    let sections = LoadSections(dc, g.GreenhouseID)
                    where gu.User.UserName.ToLower() == username.ToLower()
                    select new Domain.Greenhouse
                    {
                        ID = g.GreenhouseID,
                        GreenhouseUsers = new LazyList<GreenhouseUser>(greenhouseUsers),
                        Sections = new LazyList<Section>(sections),
                        Usernames = Usernames,
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
            return r;
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
            //dc.Greenhouses.Attach(dbGreenhouse, true);
            foreach (var section in dbGreenhouse.Sections)
            {
                dc.Sections.DeleteOnSubmit(section);
                foreach (var task in section.Tasks)
                {
                    dc.Tasks.DeleteOnSubmit(task);
                }
            }
            dc.Greenhouses.DeleteOnSubmit(dbGreenhouse);
            dc.SubmitChanges();
        }

        public IQueryable<Section> LoadSections(DataContext dc, int greenhouseID)
        {
            return  Section.All(dc).Where(s => s.GreenhouseID == greenhouseID);
        }


        public IQueryable<GreenhouseUser> LoadGreenhouseUsers(DataContext dc, int greenhouseUserID)
        {
            Usernames.Clear();
            var r =  GreenhouseUser.All(dc).ByGreenhouseID(greenhouseUserID);
            foreach (var user in r)
            {
                Usernames.Add(user.Username);
            }
            return r;
        }

        # endregion
    }
}