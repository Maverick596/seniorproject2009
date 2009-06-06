using System.Collections.Generic;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository.Interface
{
    [PluginFamily("Default")]
    public interface IProductRepository
    {
        #region Static properties

        #endregion

        #region Instance properties

        Connection Conn { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        IList<Domain.Product> All(DataContext dc);
        Domain.Product Find(DataContext dc, int id);
        int Save(DataContext dc, Domain.Product model);
        void Delete(DataContext dc, Domain.Product model);
        #endregion
    }
}