using System;
using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository.Interface
{
    [PluginFamily("Default")]
    public interface IGreenhouseRepository
    {
        #region Static properties

        #endregion

        #region Instance properties

        Connection Conn { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        IQueryable<Domain.Greenhouse> All(DataContext dc);
        int Save(DataContext dc, Domain.Greenhouse model);
        void Delete(DataContext dc, Domain.Greenhouse model);
        IQueryable<Domain.Section> LoadSections(DataContext dc, int greenhouseID);
        IQueryable<Domain.GreenhouseUser> LoadGreenhouseUsers(DataContext dc, int greenhouseID);
        #endregion
    }
}