using System;
using System.Linq;
using System.Collections.Generic;
using DV_Enterprises.Web.DataAccess.Interface;
using DV_Enterprises.Web.Domain;
using StructureMap;

namespace DV_Enterprises.Web.DataAccess.Impl
{
    [Pluggable("Default")]
    public class SectionRepository : ISectionRepository
    {
        private readonly Connection conn;

        public  SectionRepository()
        {
            conn = new Connection();
        }

        public List<Section> GetSections()
        {
            List<Section> restult;
            using (var dc = conn.GetContext())
            {
                IEnumerable<Section> sections = dc.Sections;
                restult = sections.ToList();
            }
            return restult;
        }

        public List<Section> GetSections(Guid userId)
        {
            throw new NotImplementedException();
        }


        public List<Section> GetSections(Greenhouse greenhouse)
        {
            List<Section> restult;
            using (var dc = conn.GetContext())
            {
                IEnumerable<Section> sections = dc.Sections.Where(s => s.Greenhouse == greenhouse);
                restult = sections.ToList();
            }
            return restult;
        }

        public List<Section> GetSectionsOwned(Guid userId)
        {
            List<Section> restult;
            using (var dc = conn.GetContext())
            {
                IEnumerable<Section> sections = dc.Sections.Where(s => s.UserId == userId);
                restult = sections.ToList();
            }
            return restult;
        }

        public List<Section> GetLatestSections()
        {
            throw new NotImplementedException();
        }

        public Section GetSection(int sectionId)
        {
            Section restult;
            using (var dc = conn.GetContext())
            {
                restult = dc.Sections.Where(s => s.SectionId == sectionId).FirstOrDefault();
            }
            return restult;
        }

        public int SaveSection(Section section)
        {
            using (var dc = conn.GetContext())
            {
                if(section.SectionId > 0)
                {
                    dc.Sections.Attach(section, true);
                }
                else
                {
                    dc.Sections.InsertOnSubmit(section);
                }
                dc.SubmitChanges();
            }
            return section.SectionId;
        }

        public void DeleteSection(Section section)
        {
            using (var dc = conn.GetContext())
            {
                dc.Sections.Attach(section, true);
                dc.Sections.DeleteOnSubmit(section);
                dc.SubmitChanges();
            }
        }

        public void DeleteSection(int sectionId)
        {
            using (var dc = conn.GetContext())
            {
                Section section = dc.Sections.Where(s => s.SectionId == sectionId).FirstOrDefault();
                dc.Sections.DeleteOnSubmit(section);
                dc.SubmitChanges();
            }
        }

        public bool IsOwner(Guid userId, int sectionId)
        {
            var result = false;
            using (var dc = conn.GetContext())
            {
                if(dc.Sections.Where(s => s.UserId == userId && s.SectionId == sectionId).FirstOrDefault() != null)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}