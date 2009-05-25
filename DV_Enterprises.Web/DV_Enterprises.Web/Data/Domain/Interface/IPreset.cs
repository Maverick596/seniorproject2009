using System;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain.Interface
{
    [PluginFamily("Default")]
    public interface IPreset : IDomainModel
    {
        #region Static properties

        #endregion

        #region Instance properties

        new int ID { get; set; }
        string Name { get; set; }
        Guid? UserID { get; set; }
        int? IdealTemperture { get; set; }
        int? TempertureTreshold { get; set; }
        int? IdealLightIntensity { get; set; }
        int? LightIntensityTreshold { get; set; }
        int? IdealHumidity { get; set; }
        int? HumidityTreshold { get; set; }
        bool IsGlobal { get; set; }
        DateTime DateCreated { get; }
        DateTime DateUpdated { get; }

        #endregion
    }
}