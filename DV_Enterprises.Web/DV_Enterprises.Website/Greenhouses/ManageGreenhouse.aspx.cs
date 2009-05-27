using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DV_Enterprises.Web.Data.Domain;

public partial class Greenhouses_ManageGreenhouse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Grab Information from Database and Display it on screen
        //var managegreenhouse = new Greenhouse
        //{
        //    Address = new Address
        //    {
        //        ID = 0,
        //        txtAddress1.Text = StreetLine1,
        //        txtAddress2.Text = StreetLine2,
        //        txtCity.Text = City,
        //        txtState.Text = StateOrProvince,
        //        Convert.ToInt32(txtZipCode.Text) = Zip,
        //        txtCountry.Text = Country
        //    }
        //};
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // Capture form information and store in database
        var managegreenhouse = new Greenhouse
        {
            Address = new Address
            {
                StreetLine1 = txtAddress1.Text,
                StreetLine2 = txtAddress2.Text,
                City = txtCity.Text,
                StateOrProvince = txtState.Text,
                Zip = Convert.ToInt32(txtZipCode.Text),
                Country = txtCountry.Text
            }
        };
       
        managegreenhouse.Save();

        // Close current window and refresh Parent window

        ClientScript.RegisterStartupScript(this.GetType(), "CloseCurrentandRefreshParent", "window.opener.document.forms[0].submit();self.close();", true);
    }
}
