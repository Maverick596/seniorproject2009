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
using DV_Enterprises.Web.Domain;

public partial class Customer_Default : System.Web.UI.Page
{
    MembershipUser user = System.Web.Security.Membership.GetUser();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        var d = Profile.Details;
        if (d == null) return;
        FirstNameLBL.Text = d.FirstName;
        LastNameLBL.Text = d.LastName;
        LastNameLBL.Text = user.Email;
        EmailLBL.Text = d.Phone;
        phoneLBL.Text = d.Address;
        AddressLBL.Text = d.City;
        CityLBL.Text = d.State;
        ZipCodeLBL.Text = d.ZipCode;
        
    }
 }

    

