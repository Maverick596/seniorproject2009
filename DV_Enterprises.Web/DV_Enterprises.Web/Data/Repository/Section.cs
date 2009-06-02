using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Repository.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository
{
    [Pluggable("Default")]
    public class Section : ISection
    {
        #region Static properties

        #endregion

        #region Instance properties

        public Connection Conn { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        public Section()
        {
            Conn = new Connection();
        }

        /// <summary>
        /// Find all Section's
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>return an IQueryable collection of Section</returns>
        public IQueryable<Domain.Section> All(DataContext dc)
        {
            dc = dc ?? Conn.GetContext();
            var r = from s in dc.Sections
                    select new Domain.Section
                    {
                        ID = s.SectionID,
                        Name = s.Name,
                        GreenhouseID = s.GreenhouseID,
                        PresetID = s.PresetID,
                        UserID = s.UserID,
                        IsTemperatureActivated = s.IsTemeratureActivited,
                        IdealTemperature = s.IdealTemperature,
                        TemperatureThreshold = s.TemperatureThreshold,
                        IsLightActivated = s.IsLightActivited,
                        IdealLightIntensity = s.IdealLightIntensity,
                        LightIntensityThreshold = s.LightIntensityThreshold,
                        IsHumidityActivated = s.IsHumidityActivited,
                        IdealHumidity = s.IdealHumidity,
                        HumidityThreshold = s.HumidityThreshold,
                        DateCreated = s.DateCreated,
                        DateUpdated = s.DateUpdated
                    };
            return r;
        }

        /// <summary>
        /// Find an Section by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a Section</returns>
        public Domain.Section Find(DataContext dc, int id)
        {
            return All(dc).Where(s => s.ID == id).SingleOrDefault();
        }

        /// <summary>
        /// Save a Section
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="section"></param>
        /// <returns>returns the id of the saved section</returns>
        public int Save(DataContext dc, Domain.Section section)
        {
            dc = dc ?? Conn.GetContext();
            var dbSection = dc.Sections.Where(s => s.SectionID == section.ID).SingleOrDefault();
            var isNew = false;
            if (dbSection == null)
            {
                dbSection = new DataAccess.SqlRepository.Section();
                isNew = true;
            }

            dbSection.Name = section.Name;
            dbSection.GreenhouseID = section.GreenhouseID;
            dbSection.PresetID = section.PresetID;
            dbSection.UserID = section.UserID;
            dbSection.IsTemeratureActivited = section.IsTemperatureActivated;
            dbSection.IdealTemperature = section.IdealTemperature;
            dbSection.TemperatureThreshold = section.TemperatureThreshold;
            dbSection.IsLightActivited = section.IsLightActivated;
            dbSection.IdealLightIntensity = section.IdealLightIntensity;
            dbSection.LightIntensityThreshold = section.LightIntensityThreshold;
            dbSection.IsHumidityActivited = section.IsHumidityActivated;
            dbSection.IdealHumidity = section.IdealHumidity;
            dbSection.HumidityThreshold = section.HumidityThreshold;
            dbSection.DateUpdated = DateTime.Now;

            if (isNew)
            {
                dbSection.DateCreated = DateTime.Now;
                dc.Sections.InsertOnSubmit(dbSection);
            }
            dc.SubmitChanges();
            return dbSection.SectionID;
        }

        /// <summary>
        /// Delete a single 
        /// </summary>
        /// <param name="section"></param>
        public void Delete(DataContext dc, Domain.Section section)
        {
            dc = dc ?? Conn.GetContext();
            var dbSection = dc.Sections.Where(s => s.SectionID == section.ID).SingleOrDefault();
            if (dbSection == null) return;
            //dc.Sections.Attach(dbSection, true);
            foreach (var task in dbSection.Tasks)
            {
                dc.Tasks.DeleteOnSubmit(task);
            }
            dc.Sections.DeleteOnSubmit(dbSection);
            dc.SubmitChanges();
        }

        #endregion
    }
}