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
        bool IsActive { get; set; }
        string Image { get; set; }
        DateTime? DateUpdated { get; set; }
        DateTime DateCreated { get; set; }

        #endregion
    }
}