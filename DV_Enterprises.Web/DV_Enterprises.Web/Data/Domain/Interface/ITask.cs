using System;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain.Interface
{
    [PluginFamily("Default")]
    public interface ITask : IDomainModel
    {
        #region Static properties

        #endregion

        #region Instance properties

        new int ID { get; set; }
        int SectionID { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        double Interval { get; set; }
        int TaskTypeId { get; set; }
        TaskType TaskType { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }

        #endregion
    }
}