using System;
using System.Web.Security;
using System.Web.UI;

public partial class LoginPage : Page
{
    protected void Page_Load(object sender, EventArgs e) { }

    protected void Login_LoggedIn(object sender, EventArgs e)
    {
        var userIsUserInAdminRole = Roles.IsUserInRole(Login.UserName, "Administrator");

        Login.DestinationPageUrl = userIsUserInAdminRole ? "~/Admin/Default.aspx" : "~/Account/Default.aspx";
    }
}
