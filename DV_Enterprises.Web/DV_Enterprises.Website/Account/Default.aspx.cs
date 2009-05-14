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

public partial class Customer_Default : System.Web.UI.Page
{
    MembershipUser user = System.Web.Security.Membership.GetUser();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        var d = Profile.Details;
        if (d == null) return;
        lblFirstName.Text = d.FirstName;
        lblLastName.Text = d.LastName;
        lblEmail.Text = user.Email;
        lblPhone.Text = d.Phone;
        lblAddress.Text = d.Address;
        lblCity.Text = d.City;
        lblState.Text = d.State;
        lblZipCode.Text = d.ZipCode;
    }
}
