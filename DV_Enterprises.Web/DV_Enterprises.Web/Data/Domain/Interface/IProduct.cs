using System;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain.Interface
{
    [PluginFamily("Default")]
    public interface IProduct : IDomainModel
    {
        #region Static properties

        #endregion

        #region Instance properties

        new int ID { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        bool Active { get; set; }
        DateTime? UpdateDate { get; }

        #endregion
    }
}