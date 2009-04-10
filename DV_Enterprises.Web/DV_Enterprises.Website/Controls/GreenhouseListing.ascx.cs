using System;
using System.Web.UI.WebControls;
using DV_Enterprises.Web.UI;

public partial class Controls_GreenhouseListing : BaseWebPart
{
    private bool _showPageSizePicker = true;
    public bool ShowPageSizePicker
    {
        get { return _showPageSizePicker; }
        set
        {
            _showPageSizePicker = value;
            ddlGreenhousesPerPage.Visible = value;
            lblPageSizePicker.Visible = value;
        }
    }

    private bool _enablePaging = true;
    public bool EnablePaging
    {
        get { return _enablePaging; }
        set
        {
            _enablePaging = value;
            gvwGreenhouses.PagerSettings.Visible = value;
        }
    }

    protected bool UserCanEdit { get; set; }

    protected void Page_Init(object sender, EventArgs e)
    {
        Page.RegisterRequiresControlState(this);

        bool isAuthenticated = Page.User.Identity.IsAuthenticated;
        bool isAdmin = Page.User.IsInRole("Administrators");

        UserCanEdit = (isAuthenticated && (isAdmin));
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        int pageSize = 25; // TODO: FIX Globals.Settings.Greenhouses.PageSize;
        if (ddlGreenhousesPerPage.Items.FindByValue(pageSize.ToString()) == null)
            ddlGreenhousesPerPage.Items.Add(new ListItem(pageSize.ToString(), pageSize.ToString()));
        ddlGreenhousesPerPage.SelectedValue = pageSize.ToString();
        gvwGreenhouses.PageSize = pageSize;

        gvwGreenhouses.DataBind();
    }
    protected void ddlGreenhousesPerPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvwGreenhouses.PageSize = int.Parse(ddlGreenhousesPerPage.SelectedValue);
        gvwGreenhouses.PageIndex = 0;
        gvwGreenhouses.DataBind();
    }
}
