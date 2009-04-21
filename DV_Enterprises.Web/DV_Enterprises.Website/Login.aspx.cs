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

public partial class LoginPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {
        if (Roles.IsUserInRole(UsernameTextBox.Text, "Administrator"))
        {
            Master.Admin = UsernameTextBox.Text;
            Master.ShowAdminLoggedIn();
            
            Response.Redirect("~/Admin/Default.aspx");
        }
        else
        {
            CustomerDataSetTableAdapters.SelectCustomerTableAdapter tba = new CustomerDataSetTableAdapters.SelectCustomerTableAdapter();
            DataTable tbl = new DataTable();
            tbl = tba.GetData(UsernameTextBox.Text);

            if (tbl.Rows.Count > 0)
            {
                DataRow dr = tbl.Rows[0];

                //User information found in database!  Capture information into a session variable.
                Session["Username"] = dr["Username"].ToString();

                Master.FirstName = dr["FirstName"].ToString();
                Master.LastName = dr["LastName"].ToString();

                Master.ShowUserLoggedIn();

                // Redirect to account page
                Response.Redirect("~/Account/Default.aspx");
            }
        }
    }
    protected void CancelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}
