using System;
using DV_Enterprises.Web.DataAccess.Interface;
using DV_Enterprises.Web.Domain;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Service.Impl
{
    [Pluggable("Default")]
    public class SectionService : ISectionService
    {
        private ISectionRepository _sectionrepository;
        public SectionService()
        {
            _sectionrepository = ObjectFactory.GetInstance<ISectionRepository>();
        }

        public int SaveSection(Section section)
        {
            int result = 0;
            if (section.SectionId > 0)
            {
                result = _sectionrepository.SaveSection(section);
            }
            else
            {
                result = _sectionrepository.SaveSection(section);
                // build relationships with other models
            }
            return result;
        }

        public bool IsOwnerOrAdministrator(Guid userId, int sectionId)
        {
            bool result = false;
            if (IsOwner(userId, sectionId))
            {
                result = true;
            }
            return result;
        }

        public bool IsOwner(Guid userId, int sectionId)
        {
            return _sectionrepository.IsOwner(userId, sectionId);
        }

        public bool IsAdministrator(int userId, int sectionId)
        {
            throw new NotImplementedException();
        }

        public bool IsMember(Guid userId, int sectionId)
        {
            throw new NotImplementedException();
        }
    }
}