using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository.Interface
{
    [PluginFamily("Default")]
    public interface ITask
    {
        #region Static properties

        #endregion

        #region Instance properties

        Connection Conn { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        IQueryable<Domain.Task> All(DataContext dc);
        Domain.Task Find(DataContext dc, int id);
        int Save(DataContext dc, Domain.Task model);
        void Delete(DataContext dc, Domain.Task model);
        #endregion
    }
}