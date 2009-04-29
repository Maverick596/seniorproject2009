using System.Configuration;
using System.Web.Configuration;

namespace DV_Enterprises.Web.Config
{
    public class GreenhouseElement : ConfigurationElement
    {
        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["connectionStringName"]; }
            set { base["connectionStringName"] = value; }
        }

        public string ConnectionString
        {
            get
            {
                // Return the base class' ConnectionString property.
                // The name of the connection string to use is retrieved from the site's 
                // custom config section and is used to read the setting from the <connectionStrings> section
                // If no connection string name is defined for the <greenhouses> element, the
                // parent section's DefaultConnectionString prop is used.
                string connStringName = (string.IsNullOrEmpty(ConnectionStringName) ?
                                                                                        Globals.Settings.DefaultConnectionStringName : ConnectionStringName);
                return WebConfigurationManager.ConnectionStrings[connStringName].ConnectionString;
            }
        }

        [ConfigurationProperty("enableCaching", DefaultValue = "true")]
        public bool EnableCaching
        {
            get { return (bool)base["enableCaching"]; }
            set { base["enableCaching"] = value; }
        }

        public int CacheDuration
        {
            get
            {
                int duration = (int)base["cacheDuration"];
                return (duration > 0 ? duration : Globals.Settings.DefaultCacheDuration);
            }
            set { base["cacheDuration"] = value; }
        }

        [ConfigurationProperty("pageSize", DefaultValue = "10")]
        public int PageSize
        {
            get { return (int)base["pageSize"]; }
            set { base["pageSize"] = value; }
        }
    }
}