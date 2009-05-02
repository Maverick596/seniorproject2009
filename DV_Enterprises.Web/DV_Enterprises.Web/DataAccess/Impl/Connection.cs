using DV_Enterprises.Web.Domain;

namespace DV_Enterprises.Web.DataAccess.Impl
{
    public class Connection
    {
        public DataContext GetContext()
        {
            // maybe make more data connections
            var dc = new DataContext();
            return dc;
        }
    }
}