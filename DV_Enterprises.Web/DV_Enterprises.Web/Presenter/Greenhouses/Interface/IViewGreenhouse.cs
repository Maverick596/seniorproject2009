using System.Collections.Generic;
using DV_Enterprises.Web.Domain;

namespace DV_Enterprises.Web.Presenter.Greenhouses.Interface
{
    public interface IViewGreenhouse
    {
        void LoadData(Greenhouse greenhouse);
        void LoadLocation(Location location);
        void LoadSection(List<Section> sections);
    }
}