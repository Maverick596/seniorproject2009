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

public partial class Greenhouses_ManageSection : System.Web.UI.Page
{
    private static int SectionID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["section"] == null) return;

        SectionID = Int32.Parse(Request.QueryString["section"]);
    }
}
