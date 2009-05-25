using System.Collections.Generic;
using System.Security.Principal;
using DV_Enterprises.Web.Data.Domain;

namespace DV_Enterprises.Web.Presenter.Greenhouses.Interface
{
    public interface IDefault
    {
        void LoadData(IList<Greenhouse> greenhouses);
        IPrincipal User { get; }
    }
}