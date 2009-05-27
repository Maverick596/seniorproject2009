using System;
using System.Web.Security;
using DV_Enterprises.Web.Domain;

public partial class Account_Edit : System.Web.UI.Page
{
    MembershipUser user = System.Web.Security.Membership.GetUser();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        var d = Profile.Details;
        if (d == null) return;
        txtFirstName.Text = d.FirstName;
        txtLastName.Text = d.LastName;
        txtEmail.Text = user.Email;
        txtPhone.Text = d.Phone;
        txtAddress.Text = d.Address;
        txtCity.Text = d.City;
        txtState.Text = d.State;
        txtZipCode.Text = d.ZipCode;
    }

    protected void UpdateProfile()
    {
        var d = new Details
                    {
                        FirstName = txtFirstName.Text, 
                        LastName = txtLastName.Text, 
                        Phone = txtPhone.Text,
                        Address = txtAddress.Text,
                        City = txtCity.Text,
                        State = txtState.Text,
                        ZipCode = txtZipCode.Text
                    };
        user.Email = txtEmail.Text;
        System.Web.Security.Membership.UpdateUser(user);
        Profile.Details = d;
    }

    protected void butUpdateProfile_Click(object sender, EventArgs e)
    {
        UpdateProfile();
        Response.Redirect("~/Account/default.aspx");
    }
   
}
