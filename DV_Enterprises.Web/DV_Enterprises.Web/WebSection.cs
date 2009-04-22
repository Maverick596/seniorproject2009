using System.Configuration;

namespace DV_Enterprises.Web
{
    public class WebSection : ConfigurationSection
    {
        [ConfigurationProperty("defaultConnectionStringName", DefaultValue = "LocalSqlServer")]
        public string DefaultConnectionStringName
        {
            get { return (string)base["defaultConnectionStringName"]; }
            set { base["connectionStdefaultConnectionStringNameringName"] = value; }
        }

        [ConfigurationProperty("defaultCacheDuration", DefaultValue = "600")]
        public int DefaultCacheDuration
        {
            get { return (int)base["defaultCacheDuration"]; }
            set { base["defaultCacheDuration"] = value; }
        }

        [ConfigurationProperty("greenhouses", IsRequired = true)]
        public GreenhouseElement Greenhouses
        {
            get { return (GreenhouseElement)base["greenhouses"]; }
        }

        [ConfigurationProperty("crops", IsRequired = true)]
        public CropElement Crops
        {
            get { return (CropElement)base["crops"]; }
        }

        [ConfigurationProperty("customers", IsRequired = true)]
        public CustomerElement Customers
        {
            get { return (CustomerElement)base["customers"]; }
        }
    }
}