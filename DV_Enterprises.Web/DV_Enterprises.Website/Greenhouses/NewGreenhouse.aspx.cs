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
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;

public partial class Greenhouses_NewGreenhouse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        // Capture form information and store in database
        DataContext db = new DataContext();
        Address newAddress = new Address();
        newAddress.StreetLine1 = txtAddress1.Text;
        newAddress.StreetLine2 = txtAddress2.Text;
        newAddress.City = txtCity.Text;
        newAddress.StateOrProvince = txtState.Text;
        newAddress.Zip = Convert.ToInt32(txtZipCode.Text);
        newAddress.Country = txtCountry.Text;
        newAddress.DateCreated = DateTime.Now;

        db.Addresses.InsertOnSubmit(newAddress);
        
        
        db.SubmitChanges();

        Greenhouse newGreenhouse = new Greenhouse();
        newGreenhouse.AddressID = newAddress.AddressID;

        db.Greenhouses.InsertOnSubmit(newGreenhouse);
        db.SubmitChanges();

        

        // Close current window and refresh Parent window

        ClientScript.RegisterStartupScript(this.GetType(), "CloseCurrentandRefreshParent", "window.opener.document.forms[0].submit();self.close();", true);
    }
}
