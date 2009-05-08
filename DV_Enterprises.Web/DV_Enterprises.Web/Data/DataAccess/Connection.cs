using DV_Enterprises.Web.Data.DataAccess.SqlRepository;

namespace DV_Enterprises.Web.Data.DataAccess
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