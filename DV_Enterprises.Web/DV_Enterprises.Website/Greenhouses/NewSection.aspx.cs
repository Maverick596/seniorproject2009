using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DV_Enterprises.Web.Data.Domain;
public partial class Greenhouses_NewSection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {
        var s = new Section
        {
          Name = txtSectionName.Text,
          PresetID = Convert.ToInt32(ddlCropName.SelectedValue),
          IdealTemperature = Convert.ToInt32(ddlTemp.SelectedValue),
          TemperatureTreshold = Convert.ToInt32(ddlTemp.SelectedValue),
          IdealLightIntensity = Convert.ToInt32(ddlLight.SelectedValue),
          LightIntensityTreshold = Convert.ToInt32(ddlLightThreshold.SelectedValue),
          IdealHumidity = Convert.ToInt32(ddlHumidity.SelectedValue),
          HumidityTreshold = Convert.ToInt32(ddlHumidityThreshold.SelectedValue),
         
                    
        };
        s.Save();
    }
}
