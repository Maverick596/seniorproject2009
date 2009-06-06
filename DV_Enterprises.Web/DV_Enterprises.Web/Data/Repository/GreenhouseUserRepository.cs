using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Repository.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository
{
    [Pluggable("Default")]
    public class GreenhouseUserRepository : IGreenhouseUserRepository
    {
        #region Static properties

        #endregion

        #region Instance properties

        public Connection Conn { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        public GreenhouseUserRepository()
        {
            Conn = new Connection();
        }

        public IQueryable<Domain.GreenhouseUser> All(DataContext dc)
        {
            dc = dc ?? Conn.GetContext();
            var r = from gu in dc.GreenhouseUsers
                    select new Domain.GreenhouseUser
                    {
                        ID = gu.GreenhouseUserId,
                        UserID = gu.UserId,
                        Username = gu.User.UserName,
                        GreenhouseID = gu.GreenhouseId
                    };
            return r;
        }

        public Domain.GreenhouseUser Find(DataContext dc, int id)
        {
            return All(dc).Where(gu => gu.ID == id).SingleOrDefault();
        }

        public int Save(DataContext dc, Domain.GreenhouseUser greenhouseUser)
        {
            dc = dc ?? Conn.GetContext();
            var dbGreenhouseUser = dc.GreenhouseUsers.Where(g => g.GreenhouseUserId == greenhouseUser.ID).SingleOrDefault();
            var isNew = false;
            if (dbGreenhouseUser == null)
            {
                dbGreenhouseUser = new GreenhouseUser();
                isNew = true;
            }

            dbGreenhouseUser.UserId = greenhouseUser.UserID;
            dbGreenhouseUser.GreenhouseId = greenhouseUser.GreenhouseID;

            if (isNew)
            {
                dc.GreenhouseUsers.InsertOnSubmit(dbGreenhouseUser);
            }
            dc.SubmitChanges();

            greenhouseUser.ID = dbGreenhouseUser.GreenhouseId;

            return greenhouseUser.ID;
        }

        public void Delete(DataContext dc, Domain.GreenhouseUser greenhouseUser)
        {
            dc = dc ?? Conn.GetContext();
            var dbGreenhouseUser = dc.GreenhouseUsers.Where(g => g.GreenhouseUserId == greenhouseUser.ID).SingleOrDefault();
            if (dbGreenhouseUser == null) return;
            //dc.Greenhouses.Attach(dbGreenhouse, true);
            foreach (var section in dbGreenhouseUser.Greenhouse.Sections)
            {
                dc.Sections.DeleteOnSubmit(section);
                foreach (var task in section.Tasks)
                {
                    dc.Tasks.DeleteOnSubmit(task);
                }
            }
            dc.GreenhouseUsers.DeleteOnSubmit(dbGreenhouseUser);
            dc.SubmitChanges();
        }

        #endregion
    }
}