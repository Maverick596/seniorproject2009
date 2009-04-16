using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DV_Enterprises.Web.DAL;

namespace DV_Enterprises.Web.BLL
{
    [DataObject(true)]
    public partial class Crop : BaseCropEntity
    {
        // Public propertities

        // Private propertities
        private static DataContext _sharedContext;

        // Public Methods
        // Public Methods
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IEnumerable<Crop_NoBody> GetCrops()
        {
            List<Crop_NoBody> crops = GetCropsQuery().ToList();
            _sharedContext.Dispose();
            return crops;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IEnumerable<Crop_NoBody> GetCrops(int startRowIndex, int MaximumRows)
        {
            List<Crop_NoBody> crops;

            // TODO: Add other conditions before executing query
            crops = GetCropsQuery().Skip(startRowIndex).Take(MaximumRows).ToList();
            _sharedContext.Dispose();

            return crops;
        }

        public static int GetCropCount()
        {
            // TODO: Add other conditions before executing query
            int cropCount = GetCropsQuery().Count();
            _sharedContext.Dispose();

            return cropCount;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Crop GetCropByID(int cropId)
        {
            using (DataContext context = GetContext())
            {
                return context.Crops.Where(c => c.CropId == cropId).SingleOrDefault();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static void InsertCrop(Crop crop)
        {
            // TODO: sanitize values
            crop.Height = crop.Height;
            crop.Width = crop.Width;
            crop.Length = crop.Length;
            crop.Name = crop.Name;
            crop.MaxTemperature = crop.MaxTemperature;
            crop.MinTemperature = crop.MinTemperature;
            crop.MaxHumidity = crop.MaxHumidity;
            crop.MinHumidity = crop.MinHumidity;

            using (DataContext context = GetContext())
            {
                context.Crops.InsertOnSubmit(crop);
                context.SubmitChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateCrop(Crop changedCrop)
        {
            // TODO: sanitize values
            changedCrop.Height = changedCrop.Height;
            changedCrop.Width = changedCrop.Width;
            changedCrop.Length = changedCrop.Length;
            changedCrop.Name = changedCrop.Name;
            changedCrop.MaxTemperature = changedCrop.MaxTemperature;
            changedCrop.MinTemperature = changedCrop.MinTemperature;
            changedCrop.MaxHumidity = changedCrop.MaxHumidity;
            changedCrop.MinHumidity = changedCrop.MinHumidity;

            using (DataContext context = GetContext())
            {
                context.Crops.Attach(changedCrop, true);
                context.SubmitChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteCrop(Crop crop)
        {
            using (DataContext context = GetContext())
            {
                context.Crops.Attach(crop);
                context.Crops.DeleteOnSubmit(crop);
                context.SubmitChanges();
            }
            // TODO: create logging project that will log events
            // new RecordDeletedEvent("greenhouse", greenhouse.ID, null).Raise();
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteCrop(int cropId)
        {
            using (DataContext context = GetContext())
            {
                Crop crop = context.Crops.Where(c => c.CropId == cropId).SingleOrDefault();
                context.Crops.DeleteOnSubmit(crop);
                context.SubmitChanges();
            }
            // TODO: create logging project that will log events
            // new RecordDeletedEvent("greenhouse", greenhouseID, null).Raise();
        }

        //Private Methods

        private static IOrderedQueryable<Crop_NoBody> GetCropsQuery()
        {
            _sharedContext = GetContext();

            _sharedContext.DeferredLoadingEnabled = false;

            return _sharedContext.Crops.Select(c => new Crop_NoBody
            {
                CropId = c.CropId,
                Height = c.Height,
                Length = c.Length,
                Width = c.Width,
                Name = c.Name,
                MaxTemperature = c.MaxTemperature,
                MinTemperature = c.MinTemperature,
                MaxHumidity = c.MaxHumidity,
                MinHumidity = c.MinHumidity,
            }).OrderByDescending(c => c.CropId);
        }
    }

    public class Crop_NoBody : Crop { }
}