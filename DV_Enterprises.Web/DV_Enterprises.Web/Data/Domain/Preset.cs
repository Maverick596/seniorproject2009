using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class Preset : IPreset
    {
        #region Static properties

        private static readonly Repository.PresetRepository Repository = new Repository.PresetRepository();

        #endregion

        #region Instance properties

        public int ID { get; set; }
        public string Name { get; set; }
        public Guid? UserID { get; set; }
        public int? IdealTemperature { get; set; }
        public int? TemperatureThreshold { get; set; }
        public int? IdealLightIntensity { get; set; }
        public int? LightIntensityThreshold { get; set; }
        public int? IdealHumidity { get; set; }
        public int? HumidityThreshold { get; set; }
        public int? IdealWaterLevel { get; set; }
        public int? WaterLevelThreshold { get; set; }
        public bool IsGlobal { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        #endregion

        # region Static Methods

        /// <summary>
        /// Find all Preset's
        /// </summary>
        /// <returns>return an IQueryable collection of Preset</returns>
        public static IQueryable<Preset> All()
        {
            return All(null);
        }
        
        /// <summary>
        /// Find all Preset's
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <returns>return an IQueryable collection of Preset</returns>
        public static IQueryable<Preset> All(DataContext dc)
        {
            return Repository.All(dc);
        }

        /// <summary>
        /// Find an Preset by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a Preset</returns>
        public static Preset Find(int id)
        {
            return Find(null, id);
        }
         
        /// <summary>
        /// Find an Preset by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a Preset</returns>
        public static Preset Find(DataContext dc, int id)
        {
            return Repository.Find(dc, id);
        }

        /// <summary>
        /// Save a Preset
        /// </summary>
        /// <param name="preset"></param>
        /// <returns>returns the id of the saved preset</returns>
        public static int Save(Preset preset)
        {
            return Save(null, preset);
        }

        /// <summary>
        /// Save a Preset
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="preset"></param>
        /// <returns>returns the id of the saved preset</returns>
        public static int Save(DataContext dc, Preset preset)
        {
            return Repository.Save(dc, preset);
        }

        /// <summary>
        /// Delete a single Preset
        /// </summary>
        /// <param name="preset"></param>
        public static void Delete(Preset preset)
        {
            Delete(null, preset);
        }
        
        /// <summary>
        /// Delete a single Preset
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="preset"></param>
        public static void Delete(DataContext dc, Preset preset)
        {
            Repository.Delete(dc,preset);
        }
         
        #endregion

        #region Instance Methods

        /// <summary>
        /// Save Preset
        /// </summary>
        /// <returns>returns the id of the saved crop</returns>
        public int Save()
        {
            return Save(this);
        }

        /// <summary>
        /// Save Preset
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>returns the id of the saved crop</returns>
        public int Save(DataContext dc)
        {
            return Save(dc, this);
        }

        /// <summary>
        /// Delete Preset
        /// </summary>
        public void Delete()
        {
            Delete(this);
        }

        /// <summary>
        /// Delete Preset
        /// </summary>
        /// <param name="dc"></param>
        public void Delete(DataContext dc)
        {
            Delete(dc, this);
        }

        #endregion

    }
}