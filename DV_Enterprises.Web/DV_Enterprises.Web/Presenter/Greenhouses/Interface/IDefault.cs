using System.Collections.Generic;
using DV_Enterprises.Web.Domain;

namespace DV_Enterprises.Web.Presenter.Greenhouses.Interface
{
    public interface IDefault
    {
        void LoadData(List<Greenhouse> greenhouses);
    }
}