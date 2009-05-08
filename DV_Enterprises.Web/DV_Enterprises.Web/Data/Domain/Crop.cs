using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Abstract;
using DV_Enterprises.Web.Data.Domain.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class Crop : DomainModel, ICrop
    {
        #region Static properties

        #endregion

        #region Instance properties

        public int ID { get; set; }
        public string Name { get; set; }
        public int CropID { get; set; }
        public Guid? UserID { get; set; }
        public int? IdealTemperture { get; set; }
        public int? TempertureTreshold { get; set; }
        public int? IdealLightIntensity { get; set; }
        public int? LightIntensityTreshold { get; set; }
        public int? IdealHumidity { get; set; }
        public int? HumidityTreshold { get; set; }
        public bool IsGlobal { get; set; }
        public DateTime DateCreated { get; private set; }
        public DateTime DateUpdated { get; private set; }
        public DateTime? DateDeleted { get; private set; }

        #endregion

        # region Static Methods

        /// <summary>
        /// Find all Crop's
        /// </summary>
        /// <returns>return an IQueryable collection of Crop</returns>
        public static IQueryable<Crop> All()
        {
            return All(null);
        }
        
        /// <summary>
        /// Find all Crop's
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <returns>return an IQueryable collection of Crop</returns>
        public static IQueryable<Crop> All(DataContext dc)
        {
            dc = dc ?? Conn.GetContext();
            var r = from c in dc.Crops
                    select new Crop
                    {
                        ID = c.CropID,
                        Name = c.Name,
                        CropID = c.CropID,
                        UserID = c.UserID,
                        IdealTemperture = c.IdealTemperature,
                        TempertureTreshold = c.TemperatureThreshold,
                        IdealLightIntensity = c.IdealLightIntensity,
                        LightIntensityTreshold = c.LightIntensityTreshold,
                        IdealHumidity = c.IdealHumidity,
                        HumidityTreshold = c.HumidityThreshold,
                        IsGlobal = c.IsGlobal,
                        DateCreated = c.DateCreated,
                        DateUpdated = c.DateUpdated,
                        DateDeleted = c.DateDeleted
                    };
            return r;
        }

        /// <summary>
        /// Find an Crop by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a Crop</returns>
        public static Crop Find(int id)
        {
            return Find(null, id);
        }
         
        /// <summary>
        /// Find an Crop by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a Crop</returns>
        public static Crop Find(DataContext dc, int id)
        {
            return All(dc).Where(c => c.ID == id).SingleOrDefault();
        }

        /// <summary>
        /// Save a Crop
        /// </summary>
        /// <param name="crop"></param>
        /// <returns>returns the id of the saved crop</returns>
        public static int Save(Crop crop)
        {
            return Save(null, crop);
        }

        /// <summary>
        /// Save a Crop
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="crop"></param>
        /// <returns>returns the id of the saved crop</returns>
        public static int Save(DataContext dc, Crop crop)
        {
            dc = dc ?? Conn.GetContext();
            var dbCrop = dc.Crops.Where(c => c.CropID == crop.ID).SingleOrDefault();
            var isNew = false;
            if (dbCrop == null)
            {
                dbCrop = new DataAccess.SqlRepository.Crop();
                isNew = true;
            }

            dbCrop.Name = crop.Name;
            dbCrop.CropID = crop.CropID;
            dbCrop.UserID = crop.UserID;
            dbCrop.IdealTemperature = crop.IdealTemperture;
            dbCrop.TemperatureThreshold = crop.TempertureTreshold;
            dbCrop.IdealLightIntensity = crop.IdealLightIntensity;
            dbCrop.LightIntensityTreshold = crop.LightIntensityTreshold;
            dbCrop.IdealHumidity = crop.IdealHumidity;
            dbCrop.HumidityThreshold = crop.HumidityTreshold;
            dbCrop.IsGlobal = crop.IsGlobal;
            dbCrop.DateUpdated = DateTime.Now;

            if (isNew)
            {
                dbCrop.DateCreated = DateTime.Now;
                dc.Crops.InsertOnSubmit(dbCrop);
            }
            dc.SubmitChanges();
            return dbCrop.CropID;
        }

        /// <summary>
        /// Delete a single Crop
        /// </summary>
        /// <param name="crop"></param>
        public static void Delete(Crop crop)
        {
            Delete(null, crop);
        }
        
        /// <summary>
        /// Delete a single Crop
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="crop"></param>
        public static void Delete(DataContext dc, Crop crop)
        {
            dc = dc ?? Conn.GetContext();
            var dbCrop = dc.Crops.Where(c => c.CropID == crop.ID).SingleOrDefault();
            if (dbCrop == null) return;
            dc.Crops.Attach(dbCrop, true);
            dc.Crops.DeleteOnSubmit(dbCrop);
            dc.SubmitChanges();
        }
         

        #endregion

        #region Instance Methods

        /// <summary>
        /// Save Crop
        /// </summary>
        /// <returns>returns the id of the saved crop</returns>
        public int Save()
        {
            return Save(this);
        }

        /// <summary>
        /// Save Crop
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>returns the id of the saved crop</returns>
        public int Save(DataContext dc)
        {
            return Save(dc, this);
        }

        /// <summary>
        /// Delete Crop
        /// </summary>
        public void Delete()
        {
            Delete(this);
        }

        /// <summary>
        /// Delete Crop
        /// </summary>
        /// <param name="dc"></param>
        public void Delete(DataContext dc)
        {
            Delete(dc, this);
        }

        #endregion

    }
}