using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;

namespace DV_Enterprises.Web.Data.Domain.Abstract
{
    public abstract class DomainModel
    {
        #region Static variables

        protected static readonly Connection Conn = new Connection();

        #endregion
    }
}