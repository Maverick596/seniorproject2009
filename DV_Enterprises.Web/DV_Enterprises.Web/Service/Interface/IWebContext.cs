using StructureMap;

namespace DV_Enterprises.Web.Service.Interface
{
    [PluginFamily("Default")]
    public interface IWebContext
    {
        int ProductId { get; }
        int GreenhouseId { get; }
        int GreenhouseIdSession { get; set; }
    }
}