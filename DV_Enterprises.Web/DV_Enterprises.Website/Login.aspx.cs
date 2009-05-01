using System;
using System.Web.Security;
using System.Web.UI;

public partial class LoginPage : Page
{
    protected void Page_Load(object sender, EventArgs e) { }

    protected void Login_LoggedIn(object sender, EventArgs e)
    {
        var userIsUserInAdminRole = Roles.IsUserInRole(Login.UserName, "administrator");
        var userIsUserInCustomerRole = Roles.IsUserInRole(Login.UserName, "customer");

        if (userIsUserInAdminRole)
        {
            Login.DestinationPageUrl = "~/Admin/Default.aspx";
        }
        else if (userIsUserInCustomerRole)
        {
            Login.DestinationPageUrl = "~/Account/Default.aspx";
        }
        else
        {
            Login.DestinationPageUrl = "~/Default.aspx";
        }
    }
}
