//using System;
//using System.Collections.Generic;
//using System.Linq;
//using DV_Enterprises.Web.Data.DataAccess.Interface;
//using DV_Enterprises.Web.Data.Domain;
//using DV_Enterprises.Web.Service.Interface;
//using StructureMap;

//namespace DV_Enterprises.Web.Service.Impl
//{
//    [Pluggable("Default")]
//    public class GreenhouseService : IGreenhouseService
//    {
//        private readonly IGreenhouseRepository _repository;

//        public GreenhouseService()
//        {
//            _repository = ObjectFactory.GetInstance<IGreenhouseRepository>();
//        }

//        public IList<Greenhouse> GetGreenhouses()
//        {
//            return _repository.GetGreenhouses().ToList();
//        }

//        public Greenhouse GetGreenhouse(int greenhouseID)
//        {
//            return _repository.GetGreenhouses().Where(g => g.ID == greenhouseID).SingleOrDefault();
//        }

//        public int SaveGreenhouse(Greenhouse greenhouse)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}