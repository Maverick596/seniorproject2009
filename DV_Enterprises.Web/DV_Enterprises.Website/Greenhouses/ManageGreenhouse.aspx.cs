using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Greenhouses_ManageGreenhouse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // Capture form information and store in database

        // Close current window and refresh Parent window

        ClientScript.RegisterStartupScript(this.GetType(), "CloseCurrentandRefreshParent", "window.opener.document.forms[0].submit();self.close();", true);
    }
}
