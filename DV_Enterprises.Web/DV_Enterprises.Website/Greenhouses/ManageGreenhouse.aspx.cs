using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Greenhouses_ManageGreenhouse : System.Web.UI.Page
{
    //The selected GreenhouseID from the Greenhouses/Default page
    private static int ManagingGreenhouseID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["greenhouseID"] == null)
        {
            Response.Redirect("~/Greenhouses/Default.aspx");
        }
        
        if (!Page.IsPostBack)
        {
            ManagingGreenhouseID = Int32.Parse(Session["greenhouseID"].ToString());
        }
    }
}
