using System;
using System.Collections.Generic;
using DV_Enterprises.Web.Data.Utility;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain.Interface
{
    [PluginFamily("Default")]
    public interface IGreenhouse : IDomainModel
    {
        #region Static properties

        #endregion

        #region Instance properties

        new int ID { get; set; }
        int AddressID { get; set; }
        Address Address { get; set; }
        LazyList<Section> Sections { get; set; }
        List<Guid> UserIDs { get; set; }

        #endregion
    }
}