using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Repository.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository
{
    [Pluggable("Default")]
    public class Preset:IPreset
    {
        #region Static properties

        #endregion

        #region Instance properties

        public Connection Conn { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        public Preset()
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
            var r = from c in dc.Presets
                    select new Domain.Preset
                    {
                        ID = c.PresetID,
                        Name = c.Name,
                        UserID = c.UserID,
                        IdealTemperature = c.IdealTemperature,
                        TemperatureThreshold = c.TemperatureThreshold,
                        IdealLightIntensity = c.IdealLightIntensity,
                        LightIntensityThreshold = c.LightIntensityTreshold,
                        IdealHumidity = c.IdealHumidity,
                        HumidityThreshold = c.HumidityThreshold,
                        IsGlobal = c.IsGlobal,
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateUpdated
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
            return All(dc).Where(c => c.ID == id).SingleOrDefault();
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
                dbPreset = new DataAccess.SqlRepository.Preset();
                isNew = true;
            }

            dbPreset.Name = preset.Name;
            dbPreset.UserID = preset.UserID;
            dbPreset.IdealTemperature = preset.IdealTemperature;
            dbPreset.TemperatureThreshold = preset.TemperatureThreshold;
            dbPreset.IdealLightIntensity = preset.IdealLightIntensity;
            dbPreset.LightIntensityTreshold = preset.LightIntensityThreshold;
            dbPreset.IdealHumidity = preset.IdealHumidity;
            dbPreset.HumidityThreshold = preset.HumidityThreshold;
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