using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using DV_Enterprises.Web.DataAccess.Interface;
using DV_Enterprises.Web.Domain;
using StructureMap;

namespace DV_Enterprises.Web.DataAccess.Impl
{
    [Pluggable("Default")]
    public class GreenhouseRepository : IGreenhouseRepository
    {
        private Connection _conn;

        public GreenhouseRepository()
        {
            _conn = new Connection();
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
            var result = new List<Greenhouse>();
            using (var dc = _conn.GetContext())
            {
                IEnumerable<Greenhouse> greenhouses = dc.Greenhouses.OrderBy(g => g.GreenhouseId);
                result = greenhouses.ToList();
            }
            return result;
        }

        public Greenhouse GetGreenhouse(int greenhouseId)
        {
            var result = new Greenhouse();
            using (var dc = _conn.GetContext())
            {
                result = dc.Greenhouses.Where(g => g.GreenhouseId == greenhouseId).SingleOrDefault();
            }
            return result;
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