using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DV_Enterprises.Web.DAL;

namespace DV_Enterprises.Web.BLL
{
    [DataObject(true)]
    public partial class Greenhouse : BaseGreenhouseEntity
    {
        // Public propertities

        //Private propertities
        private static DataContext _sharedContext;

        // Public Methods
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IEnumerable<Greenhouse_NoBody> GetGreenhouses()
        {
            List<Greenhouse_NoBody> greenhouses = GetGreenhousesQuery().ToList();
            _sharedContext.Dispose();
            return greenhouses;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IEnumerable<Greenhouse_NoBody> GetGreenhouses(int startRowIndex, int MaximumRows)
        {
            List<Greenhouse_NoBody> greenhouses;

            // TODO: Add other conditions before executing query
            greenhouses = GetGreenhousesQuery().Skip(startRowIndex).Take(MaximumRows).ToList();
            _sharedContext.Dispose();

            return greenhouses;
        }

        public static int GetGreenHouseCount()
        {
            // TODO: Add other conditions before executing query
            int greenhouseCount = GetGreenhousesQuery().Count();
            _sharedContext.Dispose();

            return greenhouseCount;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Greenhouse GetGreenhouseByID(int greenhouseID)
        {
            //Greenhouse greenhouse = GetGreenhousesQuery().Where(g => g.ID == greenhouseID).SingleOrDefault();
            //sharedContext.Dispose();

            //return greenhouse;

            using (DataContext context = GetContext())
            {
                return context.Greenhouses.Where(g => g.GreenhouseId == greenhouseID).SingleOrDefault();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static void InsertGreenhouse(Greenhouse greenhouse)
        {
            // TODO: sanitize values
            greenhouse.Height = greenhouse.Height;
            greenhouse.Width = greenhouse.Width;
            greenhouse.Length = greenhouse.Length;

            using (DataContext context = GetContext())
            {
                context.Greenhouses.InsertOnSubmit(greenhouse);
                context.SubmitChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateGreenhouse(Greenhouse changedGreenhouse)
        {
            // TODO: sanitize values
            changedGreenhouse.Height = changedGreenhouse.Height;
            changedGreenhouse.Width = changedGreenhouse.Width;
            changedGreenhouse.Length = changedGreenhouse.Length;

            using (DataContext context = GetContext())
            {
                context.Greenhouses.Attach(changedGreenhouse, true);
                context.SubmitChanges();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteGreenhouse(Greenhouse greenhouse)
        {
            using (DataContext context = GetContext())
            {
                context.Greenhouses.Attach(greenhouse);
                context.Greenhouses.DeleteOnSubmit(greenhouse);
                context.SubmitChanges();
            }
            // TODO: create logging project that will log events
            // new RecordDeletedEvent("greenhouse", greenhouse.ID, null).Raise();
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteGreenhouse(int greenhouseID)
        {
            using (DataContext context = GetContext())
            {
                Greenhouse greenhouse = context.Greenhouses.Where(g => g.GreenhouseId == greenhouseID).SingleOrDefault();
                context.Greenhouses.DeleteOnSubmit(greenhouse);
                context.SubmitChanges();
            }
            // TODO: create logging project that will log events
            // new RecordDeletedEvent("greenhouse", greenhouseID, null).Raise();
        }

        //Private Methods

        private static IOrderedQueryable<Greenhouse_NoBody> GetGreenhousesQuery()
        {
            _sharedContext = GetContext();

            _sharedContext.DeferredLoadingEnabled = false;

            return _sharedContext.Greenhouses.Select(g => new Greenhouse_NoBody
            {
                GreenhouseId = g.GreenhouseId,
                Width = g.Width,
                Height = g.Height,
                Length = g.Length
            }).OrderByDescending(g => g.GreenhouseId);
        }
    }

    public class Greenhouse_NoBody : Greenhouse { }
}