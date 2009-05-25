using System.Collections.Generic;
using System.Security.Principal;
using DV_Enterprises.Web.Data.Domain;

namespace DV_Enterprises.Web.Presenter.Products.Interface
{
    public interface IDefault
    {
        void LoadData(List<Product> products);
        IPrincipal User { get; }
    }
}