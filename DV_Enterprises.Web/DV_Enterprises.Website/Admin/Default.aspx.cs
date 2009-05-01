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

public partial class Admin_Default : Page
{
    private readonly MembershipUserCollection allUsers = Membership.GetAllUsers();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        string[] alphabet = "A;B;C;D;E;F;G;H;I;J;K;L;M;N;O;P;Q;R;S;T;U;V;W;X;Y;Z;ALL".Split(';');

        rptAlphabet.DataSource = alphabet;
        rptAlphabet.DataBind();
    }

    protected void btnUserSearch_Click(object sender, EventArgs e)
    {
        bool searchByEmail = ddlUserSearchTypes.SelectedValue == "E-mail";
        gvUsers.Attributes.Add("SearchText","%" + txtUserSearch.Text + "%");
        gvUsers.Attributes.Add("SearchByEmail", searchByEmail.ToString());
        BindAllUsers(false);
    }

    protected void rptAlphabet_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        gvUsers.Attributes.Add("SearchByEmail", false.ToString());
        switch (e.CommandArgument.ToString().Length)
        {
            case 1:
                gvUsers.Attributes.Add("SearchText", e.CommandArgument.ToString() + "%");
                BindAllUsers(false);
                break;
            default:
                gvUsers.Attributes.Add("SearchText", "");
                BindAllUsers(false);
                break;
        }
    }

    protected void GvUsersDataBind()
    {
        gvUsers.DataSource = Membership.GetAllUsers();
        gvUsers.DataBind();
    }

    protected void BindAllUsers(bool reloadUsers)
    {
        MembershipUserCollection users = null;
        string searchText = string.Empty;
        bool searchByEmail = false;

        if (reloadUsers)
        {
            users = Membership.GetAllUsers();
        }
        if (!string.IsNullOrEmpty(gvUsers.Attributes["SearchText"]))
        {
            searchText = gvUsers.Attributes["SearchText"];
        }
        if (!string.IsNullOrEmpty(gvUsers.Attributes["SeachByEmail"]))
        {
            searchByEmail = bool.Parse(gvUsers.Attributes["SeachByEmail"]);
        }
        if(searchText.Length > 0)
        {
            users = searchByEmail ? Membership.FindUsersByEmail(searchText) : Membership.FindUsersByName(searchText);
        }
        else
        {
            users = allUsers;
        }
        gvUsers.DataSource = users;
        gvUsers.DataBind();
    }
}
