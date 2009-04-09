using System.Web.UI;
using System.Web.UI.WebControls.WebParts;

namespace DV_Enterprises.Web.UI
{
    public class BaseWebPart : UserControl, IWebPart
    {
        public string CatalogIconImageUrl { get; set; }
        public string Description { get; set; }
        public string Subtitle { get; private set; }
        public string Title { get; set; }
        public string TitleIconImageUrl { get; set; }
        public string TitleUrl { get; set; }
    }
}