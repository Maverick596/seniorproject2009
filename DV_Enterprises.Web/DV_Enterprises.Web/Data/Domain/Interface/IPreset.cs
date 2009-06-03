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
        int? IdealTemperature { get; set; }
        int? TemperatureThreshold { get; set; }
        int? IdealLightIntensity { get; set; }
        int? LightIntensityThreshold { get; set; }
        int? IdealHumidity { get; set; }
        int? HumidityThreshold { get; set; }
        int? IdealWaterLevel { get; set; }
        int? WaterLevelThreshold { get; set; }
        bool IsGlobal { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }

        #endregion
    }
}