using DV_Enterprises.Web.Data.DataAccess;

namespace DV_Enterprises.Web.Data.Domain.Abstract
{
    public abstract class DomainModel
    {
        #region Static variables

        protected static readonly Connection Conn = new Connection();

        #endregion

    }
}