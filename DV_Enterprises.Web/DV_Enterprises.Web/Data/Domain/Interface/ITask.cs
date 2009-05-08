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
        TimeSpan StartTime { get; set; }
        TimeSpan EndTime { get; set; }
        TimeSpan Interval { get; set; }
        int TaskTypeId { get; set; }
        DateTime DateCreated { get; }
        //DateTime DateUpdated { get; }
        DateTime? DateDeleted { get; }

        #endregion
    }
}