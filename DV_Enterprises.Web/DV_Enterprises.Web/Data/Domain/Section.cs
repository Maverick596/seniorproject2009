using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Abstract;
using DV_Enterprises.Web.Data.Domain.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class Section : DomainModel, ISection
    {
        #region Static properties

        #endregion

        #region Instance properties

        public int ID { get; set; }
        public string Name { get; set; }
        public int GreenhouseID { get; set; }
        public int CropID { get; set; }
        public Guid UserID { get; set; }
        public bool IsTempertureActivated { get; set; }
        public int? IdealTemperture { get; set; }
        public int? TempertureTreshold { get; set; }
        public bool IsLightActivated { get; set; }
        public int? IdealLightIntensity { get; set; }
        public int? LightIntensityTreshold { get; set; }
        public bool IsHumidityActivated { get; set; }
        public int? IdealHumidity { get; set; }
        public int? HumidityTreshold { get; set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private set; }
        public DateTime? DateDeleted { get; private set; }

        #endregion

        # region Static Methods

        /// <summary>
        /// Find all Section's
        /// </summary>
        /// <returns>return an IQueryable collection of Section</returns>
        public static IQueryable<Section> All()
        {
            return All(null);
        }

        /// <summary>
        /// Find all Section's
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>return an IQueryable collection of Section</returns>
        public static IQueryable<Section> All(DataContext dc)
        {
            dc = dc ?? Conn.GetContext();
            var r = from s in dc.Sections
                    select new Section
                               {
                                   ID = s.SectionID,
                                   Name = s.Name,
                                   GreenhouseID = s.GreenhouseID,
                                   CropID = s.CropID,
                                   UserID = s.UserID,
                                   IsTempertureActivated = s.IsTemeratureActivited,
                                   IdealTemperture = s.IdealTemperature,
                                   TempertureTreshold = s.TemperatureThreshold,
                                   IsLightActivated = s.IsLightActivited,
                                   IdealLightIntensity = s.IdealLightIntensity,
                                   LightIntensityTreshold = s.LightIntensityThreshold,
                                   IsHumidityActivated = s.IsHumidityActivited,
                                   IdealHumidity = s.IdealHumidity,
                                   HumidityTreshold = s.HumidityThreshold,
                                   DateCreated = s.DateCreated,
                                   DateUpdated = s.DateUpdated
                               };
            return r;
        }

        /// <summary>
        /// Find an Section by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a Section</returns>
        public static Section Find(int id)
        {
            return Find(null, id);
        }

        /// <summary>
        /// Find an Section by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a Section</returns>
        public static Section Find(DataContext dc, int id)
        {
            return All(dc).Where(s => s.ID == id).SingleOrDefault();
        }

        /// <summary>
        /// Save a Section
        /// </summary>
        /// <param name="section"></param>
        /// <returns>returns the id of the saved section</returns>
        public static int Save(Section section)
        {
            return Save(null, section);
        }

        /// <summary>
        /// Save a Section
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="section"></param>
        /// <returns>returns the id of the saved section</returns>
        public static int Save(DataContext dc, Section section)
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
            dbSection.CropID = section.CropID;
            dbSection.UserID = section.UserID;
            dbSection.IsTemeratureActivited = section.IsTempertureActivated;
            dbSection.IdealTemperature = section.IdealTemperture;
            dbSection.TemperatureThreshold = section.TempertureTreshold;
            dbSection.IsLightActivited = section.IsLightActivated;
            dbSection.IdealLightIntensity = section.IdealLightIntensity;
            dbSection.LightIntensityThreshold = section.LightIntensityTreshold;
            dbSection.IsHumidityActivited = section.IsHumidityActivated;
            dbSection.IdealHumidity = section.IdealHumidity;
            dbSection.HumidityThreshold = section.HumidityTreshold;
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
        public static void Delete(Section section)
        {
            Delete(null, section);
        }

        /// <summary>
        /// Delete a single 
        /// </summary>
        /// <param name="section"></param>
        public static void Delete(DataContext dc, Section section)
        {
            dc = dc ?? Conn.GetContext();
            var dbSection = dc.Sections.Where(s => s.SectionID == section.ID).SingleOrDefault();
            if (dbSection == null) return;
            dc.Sections.Attach(dbSection, true);
            dc.Sections.DeleteOnSubmit(dbSection);
            dc.SubmitChanges();
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Save Section
        /// </summary>
        /// <returns>returns the id of the saved section</returns>
        public int Save()
        {
            return Save(this);
        }
        
        /// <summary>
        /// Save Section
        /// </summary>
        /// <returns>returns the id of the saved section</returns>
        public int Save(DataContext dc)
        {
            return Save(dc, this);
        }

        /// <summary>
        /// Delete Section
        /// </summary>
        public void Delete()
        {
            Delete(this);
        }

        /// <summary>
        /// Delete Section
        /// </summary>
        public void Delete(DataContext dc)
        {
            Delete(dc, this);
        }

        #endregion
    }
}