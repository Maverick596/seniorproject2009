using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Template : System.Web.UI.MasterPage
{
    public static String fName = "";
    public static String lName = "";
    public static String admin = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (fName != "" && lName != "")
        {
            ShowUserLoggedIn();
        }
        else if(admin != "")
        {
            ShowAdminLoggedIn();
        }
    }

    public String Admin
    {
        get
        {
            return admin;
        }
        set
        {
            admin = value;
        }
    }

    public String FirstName
    {
        get
        {
            return fName;
        }
        set
        {
            fName = value;
        }
    }

    public String LastName
    {
        get
        {
            return lName;
        }
        set
        {
            lName = value;
        }
    }

    public void ShowUserLoggedIn()
    {
        LoginHyperLink.Visible = false;
        LoggedInUser.Visible = true;
        LoggedInUser.Text = "Welcome, " + fName + " " + lName;
        LogOutHyperLinkButton.Visible = true;
    }

    public void ShowAdminLoggedIn()
    {
        LoginHyperLink.Visible = false;
        LoggedInUser.Visible = true;
        LoggedInUser.Text = "Welcome, " + admin + " [Administrator]";
        LogOutHyperLinkButton.Visible = true;
    }

    protected void LogOutHyperLinkButton_Click(object sender, EventArgs e)
    {
        fName = "";
        lName = "";
        admin = "";

        LoginHyperLink.Visible = true;
        LoggedInUser.Visible = false;
        LoggedInUser.Text = "";
        Response.Redirect("~/Default.aspx");
        LogOutHyperLinkButton.Visible = false;
    }
}
