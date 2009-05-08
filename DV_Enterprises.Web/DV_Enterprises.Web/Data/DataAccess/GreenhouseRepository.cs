//using System;
//using System.Linq;
//using DV_Enterprises.Web.Data.DataAccess.Interface;
//using DV_Enterprises.Web.Data.Utility;
//using StructureMap;
//using Greenhouse=DV_Enterprises.Web.Data.Domain.Greenhouse;
//using Address=DV_Enterprises.Web.Data.Domain.Address;
//using Section=DV_Enterprises.Web.Data.Domain.Section;

//namespace DV_Enterprises.Web.Data.DataAccess
//{
//    [Pluggable("Default")]
//    public class GreenhouseRepository : IGreenhouseRepository
//    {
//        private readonly Connection _conn;

//        public GreenhouseRepository()
//        {
//            _conn = new Connection();
//        }

//        public IQueryable<Greenhouse> GetGreenhouses()
//        {
//            IQueryable<Greenhouse> result;
//            using (var dc = _conn.GetContext())
//            {
//                result = from g in dc.Greenhouses
//                         let location = GetLocation(g.Address.LocationId)
//                         let sections = GetSections(g.GreenhouseId)
//                         select new Greenhouse
//                                    {
//                                        ID = g.GreenhouseId,
//                                        Address = location,
//                                        Sections = new LazyList<Section>(sections)
//                                    };
//            }
//            return result;
//        }

//        public IQueryable<Address> GetLocations()
//        {
//            IQueryable<Address> result;
//            using (var dc = _conn.GetContext())
//            {
//                result = from l in dc.Locations
//                         select new Address
//                                    {
//                                        ID = l.LocationId,
//                                        Address1 = l.AddressLine1,
//                                        Address2 = l.AddressLine2,
//                                        City = l.City,
//                                        Country = l.Country,
//                                        State = l.State,
//                                        Zip = (int)l.Zip
//                                    };
//            }
//            return result;
//        }

//        public Address GetLocation(int locationId)
//        {
//            return GetLocations().Where(l => l.ID == locationId).SingleOrDefault();
//        }

//        public IQueryable<Section> GetSections()
//        {
//            IQueryable<Section> result;
//            using (var dc = _conn.GetContext())
//            {
//                result = from s in dc.Sections
//                         select new Section
//                                    {
//                                        ID = s.SectionId,
//                                        Name = s.Name,
//                                        GreenhouseId = s.GreenhouseId
//                                    };
//            }
//            return result;
//        }

//        public IQueryable<Section> GetSections(int greenhouseId)
//        {
//            return GetSections().Where(s => s.GreenhouseId == greenhouseId);
//        }

//        public int Save(Greenhouse greenhouse)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(Greenhouse greenhouse)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}