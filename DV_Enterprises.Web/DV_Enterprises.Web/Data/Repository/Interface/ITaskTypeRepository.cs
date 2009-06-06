using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository.Interface
{
    [PluginFamily("Default")]
    public interface ITaskTypeRepository
    {
        #region Static properties

        #endregion

        #region Instance properties

        Connection Conn { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods
        IQueryable<Domain.TaskType> All(DataContext dc);
        Domain.TaskType Find(DataContext dc, int id);
        Domain.TaskType Find(DataContext dc, TaskTypes type);
        int Save(DataContext dc, Domain.TaskType model);
        void Delete(DataContext dc, Domain.TaskType model);
        #endregion
    }
}