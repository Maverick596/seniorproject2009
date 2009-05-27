using StructureMap;

namespace DV_Enterprises.Web.Data.Domain.Interface
{
    [PluginFamily("Default")]
    public interface IAddress
    {
        #region Static properties

        #endregion

        #region Instance properties

        string City { get; set; }
        string StateOrProvince { get; set; }
        string Country { get; set; }
        int? Zip { get; set; }
        string StreetLine1 { get; set; }
        string StreetLine2 { get; set; }
        bool IsDefault { get; set; }

        #endregion
        
    }
}