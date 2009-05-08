//using System;
//using System.Linq;
//using DV_Enterprises.Web.Data.Domain;
//using StructureMap;

//namespace DV_Enterprises.Web.Data.DataAccess.Interface
//{
//    [PluginFamily("Default")]
//    public interface IGreenhouseRepository
//    {
//        IQueryable<Greenhouse> GetGreenhouses();
//        IQueryable<Address> GetLocations();
//        Address GetLocation(int locationId);
//        IQueryable<Section> GetSections();
//        IQueryable<Section> GetSections(int greenhouseId);
//        //Greenhouse GetGreenhouse(int greenhouseId);
//        Int32 Save(Greenhouse greenhouse);
//        void Delete(Greenhouse greenhouse);
//    }
//}