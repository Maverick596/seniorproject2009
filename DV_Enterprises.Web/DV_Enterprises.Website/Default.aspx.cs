using System;
using System.Web.UI;
//using DV_Enterprises.Web.Presenter.Root;
//using DV_Enterprises.Web.Presenter.Root.Interface;

public partial class Default : Page//, IDefault
{
    //private DefaultPresenter _presenter;

    protected void Page_Load(object sender, EventArgs e)
    {
        //_presenter = new DefaultPresenter();
        //_presenter.Init(this);
    }

    protected void lbMeanGreens_Click(object sender, EventArgs e)
    {
        Response.Redirect("MeanGreens.aspx");
    }
    protected void lbFacebook_Click(object sender, EventArgs e)
    {
        const string windowName = "Facebook";
        const string url = "http://www.facebook.com/profile.php?id=1846000627&ref=profile";
        const string windowAttribute = "toolbar=yes,menu=yes,status=yes,width=620,height=400";
        var clientscript = string.Format("window.open('{0}', '{1}', '{2}')", url, windowName, windowAttribute);

        ClientScript.RegisterStartupScript(this.GetType(), "Popup", clientscript, true);
    }

    protected void lbTwitter_Click(object sender, EventArgs e)
    {
        const string windowName = "Twitter";
        const string url = "http://twitter.com/SmartGreen";
        const string windowAttribute = "toolbar=yes,menu=yes,status=yes,width=620,height=400";
        var clientscript = string.Format("window.open('{0}', '{1}', '{2}')", url, windowName, windowAttribute);

        ClientScript.RegisterStartupScript(this.GetType(), "Popup", clientscript, true);
    }
}
