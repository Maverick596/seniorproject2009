using System;
using System.Collections.Generic;
using DV_Enterprises.Web.DataAccess.Interface;
using DV_Enterprises.Web.Domain;
using StructureMap;

namespace DV_Enterprises.Web.DataAccess.Impl
{
    [Pluggable("Default")]
    public class GreenhouseRepository : IGreenhouseRepository
    {
        private Connection conn;

        public GreenhouseRepository()
        {
            conn = new Connection();
        }

        public List<Greenhouse> GetGreenhouses(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<Greenhouse> GetGreenhousesOwned(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<Greenhouse> GetLatestGreenhouses()
        {
            throw new NotImplementedException();
        }

        public Greenhouse GetGreenhouse(int greenhouseId)
        {
            throw new NotImplementedException();
        }

        public int Save(Greenhouse greenhouse)
        {
            throw new NotImplementedException();
        }

        public void Delete(Greenhouse greenhouse)
        {
            throw new NotImplementedException();
        }

        public void Delete(int greenhouseId)
        {
            throw new NotImplementedException();
        }

        public bool IsOwner(Guid userId, int greenhouseId)
        {
            throw new NotImplementedException();
        }
    }
}