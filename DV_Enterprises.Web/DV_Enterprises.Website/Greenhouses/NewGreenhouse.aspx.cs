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

public partial class Greenhouses_NewGreenhouse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e){}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        var greenhouse = new Greenhouse
        {
            Address = new Address
                    {
                        ID = 0,
                        StreetLine1 = txtAddress1.Text,
                        StreetLine2 = txtAddress2.Text,
                        City = txtCity.Text,
                        StateOrProvince = txtState.Text,
                        Zip = Convert.ToInt32(txtZipCode.Text),
                        Country = txtCountry.Text
                    }
        };
        greenhouse.Save();

        // Close current window and refresh Parent window
        ClientScript.RegisterStartupScript(this.GetType(), "CloseCurrentandRefreshParent", "window.opener.document.forms[0].submit();self.close();", true);
    }                if (greenhouse.Address != null)
                    greenhouse.Address.Save();
}