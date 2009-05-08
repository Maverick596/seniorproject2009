//using System;
//using DV_Enterprises.Web.Data.Domain;
//using StructureMap;

//namespace DV_Enterprises.Web.Service.Interface
//{
//    [PluginFamily("Default")]
//    public interface ISectionService
//    {
//        int SaveSection(Section section);
//        bool IsOwnerOrAdministrator(Guid userId, Int32 sectionId);
//        bool IsOwner(Guid userId, Int32 sectionId);
//        bool IsAdministrator(Int32 userId, Int32 sectionId);
//        bool IsMember(Guid userId, Int32 sectionId);
//    }
//}