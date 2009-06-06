namespace DV_Enterprises.Web.Data.Domain
{
    /// <summary>
    /// Tasks override the automatic settings that come from the sensors and may be dangerous
    /// </summary>
    public enum TaskTypes
    { 
        // Humidity Control Module
        Humidifying,
        Dehumidifying,

        // Water Level Control Module
        Watering,
        NoWatering,
        
        // Lighting Control Module
        Lighting, OverrideLighting,
        
        // Temperature Contro Module
        Heating,
        Cooling
    }
}