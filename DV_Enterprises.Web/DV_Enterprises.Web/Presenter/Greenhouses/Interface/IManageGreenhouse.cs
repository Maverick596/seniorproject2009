using System.Security.Principal;

namespace DV_Enterprises.Web.Presenter.Greenhouses.Interface
{
    public interface IManageGreenhouse
    {
        IPrincipal User { get; }
    }
}