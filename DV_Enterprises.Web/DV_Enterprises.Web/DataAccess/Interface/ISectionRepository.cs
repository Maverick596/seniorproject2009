using System;
using System.Collections.Generic;
using DV_Enterprises.Web.Domain;
using StructureMap;

namespace DV_Enterprises.Web.DataAccess.Interface
{
    [PluginFamily("Default")]
    public interface ISectionRepository
    {
        List<Section> GetSections(Guid userId);
        List<Section> GetSectionsOwned(Guid userId);
        List<Section> GetLatestSections();
        Section GetSection(int sectionId);
        Int32 SaveSection(Section section);
        void DeleteSection(Section section);
        void DeleteSection(int sectionId);
        bool IsOwner(Guid userId, int sectionId);
    }
}