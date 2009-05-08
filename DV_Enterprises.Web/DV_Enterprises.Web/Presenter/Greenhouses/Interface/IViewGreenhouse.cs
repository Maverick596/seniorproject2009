using System.Collections.Generic;
using DV_Enterprises.Web.Data.Domain;

namespace DV_Enterprises.Web.Presenter.Greenhouses.Interface
{
    public interface IViewGreenhouse
    {
        void LoadData(Greenhouse greenhouse);
        void LoadLocation(Address address);
        void LoadSection(List<Section> sections);
    }
}