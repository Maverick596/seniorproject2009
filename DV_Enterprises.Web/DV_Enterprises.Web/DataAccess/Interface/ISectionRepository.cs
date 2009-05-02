using System;
using System.Collections.Generic;
using DV_Enterprises.Web.Domain;

namespace DV_Enterprises.Web.DataAccess.Interface
{
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