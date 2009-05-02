using System;
using System.Collections.Generic;
using DV_Enterprises.Web.Domain;
using StructureMap;

namespace DV_Enterprises.Web.DataAccess.Interface
{
    [PluginFamily("Default")]
    public interface IGreenhouseRepository
    {
        List<Greenhouse> GetGreenhouses (Guid userId);
        List<Greenhouse> GetGreenhousesOwned (Guid userId);
        List<Greenhouse> GetLatestGreenhouses();
        Greenhouse GetGreenhouse(int greenhouseId);
        Int32 Save(Greenhouse greenhouse);
        void Delete(Greenhouse greenhouse);
        void Delete(int greenhouseId);
        bool IsOwner(Guid userId, int greenhouseId);

    }
}