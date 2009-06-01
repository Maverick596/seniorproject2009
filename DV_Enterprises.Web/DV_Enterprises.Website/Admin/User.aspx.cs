using System;
using System.Web.Profile;
using System.Web.Security;
using System.Web.UI;

public partial class Admin_User : Page
{
    private MembershipUserCollection users = Membership.GetAllUsers();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Id"] == null && IsPostBack) return;
        var userName = Request.QueryString["Id"];
        MembershipUser user = users[userName];
        ProfileCommon  userProfile = Profile.GetProfile(user.UserName);
        
        lblUserName.Text = user.UserName;
        lblEmail.Text = string.Format("&lt;a href=mailto:{0}&gt;{0}&lt;a&gt", user.Email);
        lblFullAddress.Text = userProfile.Details.Address;
        lblPhone.Text = userProfile.Details.Phone;
        lblName.Text = userProfile.Details.Name;

        var roles = string.Empty;
        foreach(var role in Roles.GetRolesForUser())
        {
            roles = role.ToString();
        }

        lblRoles.Text = roles;
    }
    protected void lvGreenhouses_SelectedIndexChanged(object sender, EventArgs e)
    {

    }



    protected void btnDelete_Click(object sender, EventArgs e)
    {
        users.Remove(User.Identity.Name);
    }
}
