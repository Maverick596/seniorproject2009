using System;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain.Interface
{
    [PluginFamily("Default")]
    public interface ISection : IDomainModel
    {
        #region Static properties

        #endregion

        #region Instance properties

        new int ID { get; set; }
        string Name { get; set; }
        int GreenhouseID { get; set; }
        int PresetID { get; set; }
        Preset Preset { get; }
        Guid UserID { get; set; }
        bool IsTemperatureActivated { get; set; }
        int? IdealTemperature { get; set; }
        int? TemperatureThreshold { get; set; }
        bool IsLightActivated { get; set; }
        int? IdealLightIntensity { get; set; }
        int? LightIntensityThreshold { get; set; }
        bool IsHumidityActivated { get; set; }
        int? IdealHumidity { get; set; }
        int? HumidityThreshold { get; set; }
        bool IsWaterLevelActivated { get; set; }
        int? IdealWaterLevel { get; set; }
        int? WaterLevelThreshold { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }

        #endregion
    }
}