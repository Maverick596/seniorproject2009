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

public partial class Greenhouses_AddCrop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var p = new Preset
        {
            ID = 0,
            Name = txtCropName.Text,
            IdealTemperature = Convert.ToInt32(txtIdealTemp.Text),
            TemperatureThreshold = Convert.ToInt32(txtTempRange.Text),
            IdealLightIntensity = Convert.ToInt32(txtLightRange.Text),
            LightIntensityThreshold = Convert.ToInt32(txtLightRange.Text),
            IdealHumidity = Convert.ToInt32(txtHumidity.Text),
            HumidityThreshold = Convert.ToInt32(txtHumidityRange.Text)

        };
        p.Save();
    }
}
