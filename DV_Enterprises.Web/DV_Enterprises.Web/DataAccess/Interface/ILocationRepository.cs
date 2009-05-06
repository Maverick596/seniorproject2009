using System;
using System.Collections.Generic;
using DV_Enterprises.Web.Domain;
using StructureMap;

namespace DV_Enterprises.Web.DataAccess.Interface
{
    [PluginFamily("Default")]
    public interface ILocationRepository
    {
        List<Location> GetLocations();
        Location GetLocation(int locationId);
        Location GetLocation(Greenhouse greenhouse);
        Int32 SaveLocation(Location location);
        void DeleteLocation(Location location);
        void DeleteLocation(int locationId);
    }
}