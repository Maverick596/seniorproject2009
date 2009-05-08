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
        int CropID { get; set; }
        Guid UserID { get; set; }
        bool IsTempertureActivated { get; set; }
        int IdealTemperture { get; set; }
        int TempertureTreshold { get; set; }
        bool IsLightActivated { get; set; }
        int IdealLightIntensity { get; set; }
        int LightIntensityTreshold { get; set; }
        bool IsHumidityActivated { get; set; }
        int IdealHumidity { get; set; }
        int HumidityTreshold { get; set; }
        DateTime DateCreated { get; }
        DateTime DateUpdated { get; }
        DateTime DateDeleted { get; }


        #endregion
    }
}