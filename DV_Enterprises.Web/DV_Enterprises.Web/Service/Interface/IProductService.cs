using DV_Enterprises.Web.Domain;
using StructureMap;

namespace DV_Enterprises.Web.Service.Interface
{
    [PluginFamily("Default")]
    public interface IProductService
    {
        int SaveProduct(Product product);
    }
}