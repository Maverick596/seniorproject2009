using DV_Enterprises.Web.Data.Domain.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class Address : IAddress
    {
        #region Static properties

        #endregion

        #region Instance properties

        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string Country { get; set; }
        public int? Zip { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public bool IsDefault { get; set; }

        #endregion

        # region Static Methods

        #endregion

        #region Instance Methods

        #endregion
    }
}