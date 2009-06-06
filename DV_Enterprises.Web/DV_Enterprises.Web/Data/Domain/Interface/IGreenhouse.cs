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
        Address Address { get; set; }
        LazyList<Section> Sections { get; set; }
        LazyList<GreenhouseUser> GreenhouseUsers { get; set; }
        List<string> Usernames { get; set; }
        #endregion
    }
}