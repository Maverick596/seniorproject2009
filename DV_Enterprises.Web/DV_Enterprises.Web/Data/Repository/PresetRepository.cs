using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Repository.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository
{
    [Pluggable("Default")]
    public class PresetRepository:IPresetRepository
    {
        #region Static properties

        #endregion

        #region Instance properties

        public Connection Conn { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        public PresetRepository()
        {
            Conn = new Connection();
        }

        /// <summary>
        /// Find all Preset's
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <returns>return an IQueryable collection of Preset</returns>
        public IQueryable<Domain.Preset> All(DataContext dc)
        {
            dc = dc ?? Conn.GetContext();
            var r = from p in dc.Presets
                    select new Domain.Preset
                    {
                        ID = p.PresetID,
                        Name = p.Name,
                        UserID = p.UserID,

                        IdealTemperature = p.IdealTemperature,
                        TemperatureThreshold = p.TemperatureThreshold,

                        IdealLightIntensity = p.IdealLightIntensity,
                        LightIntensityThreshold = p.LightIntensityThreshold,

                        IdealHumidity = p.IdealHumidity,
                        HumidityThreshold = p.HumidityThreshold,

                        IdealWaterLevel = p.IdealWaterLevel,
                        WaterLevelThreshold = p.WaterLevelThreshold,

                        IsGlobal = p.IsGlobal,
                        DateCreated = p.DateCreated,
                        DateUpdated = p.DateUpdated
                    };
            return r;
        }

        /// <summary>
        /// Find an Preset by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a Preset</returns>
        public Domain.Preset Find(DataContext dc, int id)
        {
            return All(dc).Where(p => p.ID == id).SingleOrDefault();
        }

        /// <summary>
        /// Save a Preset
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="preset"></param>
        /// <returns>returns the id of the saved preset</returns>
        public int Save(DataContext dc, Domain.Preset preset)
        {
            dc = dc ?? Conn.GetContext();
            var dbPreset = dc.Presets.Where(p => p.PresetID == preset.ID).SingleOrDefault();
            var isNew = false;
            if (dbPreset == null)
            {
                dbPreset = new Preset();
                isNew = true;
            }

            dbPreset.Name = preset.Name;
            dbPreset.UserID = preset.UserID;
            dbPreset.IdealTemperature = preset.IdealTemperature;
            dbPreset.TemperatureThreshold = preset.TemperatureThreshold;
            dbPreset.IdealLightIntensity = preset.IdealLightIntensity;
            dbPreset.LightIntensityThreshold = preset.LightIntensityThreshold;
            dbPreset.IdealHumidity = preset.IdealHumidity;
            dbPreset.HumidityThreshold = preset.HumidityThreshold;
            dbPreset.IdealWaterLevel = preset.IdealWaterLevel;
            dbPreset.WaterLevelThreshold = preset.WaterLevelThreshold;
            dbPreset.IsGlobal = preset.IsGlobal;
            dbPreset.DateUpdated = DateTime.Now;

            if (isNew)
            {
                dbPreset.DateCreated = DateTime.Now;
                dc.Presets.InsertOnSubmit(dbPreset);
            }
            dc.SubmitChanges();
            return dbPreset.PresetID;
        }

        /// <summary>
        /// Delete a single Preset
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="preset"></param>
        public void Delete(DataContext dc, Domain.Preset preset)
        {
            dc = dc ?? Conn.GetContext();
            var dbPreset = dc.Presets.Where(p => p.PresetID == preset.ID).SingleOrDefault();
            if (dbPreset == null) return;
            dc.Presets.Attach(dbPreset, true);
            dc.Presets.DeleteOnSubmit(dbPreset);
            dc.SubmitChanges();
        }

        #endregion
    }
}