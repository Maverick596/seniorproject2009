using System.Web.Configuration;

namespace DV_Enterprises.Web
{
    public class Globals
    {
        public static readonly WebSection Settings =
            (WebSection)WebConfigurationManager.GetSection("smartGreenhouse");

        // IMPORTAT: Maybe we will have different themes in the different sections of the site
        public static string ThemesSelectorID = string.Empty;

        static Globals() { }
    }
}