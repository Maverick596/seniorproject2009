using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Presenter.Greenhouses;
using DV_Enterprises.Web.Presenter.Greenhouses.Interface;

namespace Greenhouses
{
    public partial class ViewGreenhouse : Page, IViewGreenhouse
    {
        private ViewGreenhousePresenter _presenter;

        //The selected GreenhouseID from the Greenhouses/Default page
        private static int ManagingGreenhouseID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ViewGreenhousePresenter();
            _presenter.Init(this, IsPostBack);

            if (Session["greenhouseID"] == null)
            {
                Response.Redirect("~/Greenhouses/Default.aspx");
            }

            if (!Page.IsPostBack)
            {
                ManagingGreenhouseID = Int32.Parse(Session["greenhouseID"].ToString());
                lblGreenhouseID.Text = ManagingGreenhouseID.ToString();
            }
        }

        public void LoadData(Greenhouse greenhouse)
        {
            return; //Does nothing now ???
        }

        public void LoadLocation(Address address)
        {
            lblAddress.Text = address.StreetLine1;
        }

        public void LoadSection(List<Section> sections)
        {
            rptSections.DataSource = sections;
            rptSections.DataBind();
        }

        protected void btnNewSection_Click(object sender, EventArgs e)
        {
            // Does nothing yet
        }

        protected void btnManageGreenhouse_Click(object sender, EventArgs e)
        {
            String clientscript = "";
            String strWindowName = "";
            String strWinAttrib = "";
            String strUrl = "";

            strWindowName = "NewGreenhouse";
            strUrl = "ManageGreenhouse.aspx";
            strWinAttrib = "toolbar=no,menu=no,status=no,width=420,height=400";
            clientscript = "window.open('" + strUrl + "','" + strWindowName + "','" + strWinAttrib + "')";

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", clientscript, true);
        }

        protected void lnkbtnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void rptSections_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void lnkBtnEditSection_Click(object sender, EventArgs e)
        {
            var button = sender as LinkButton;

            String sectionID = button.CommandArgument;
            
            String clientscript = "";
            String strWindowName = "";
            String strWinAttrib = "";
            String strUrl = "";

            strWindowName = "ManageSection";
            strUrl = "ManageSection.aspx?&section=" + sectionID;
            strWinAttrib = "toolbar=no,menu=no,status=no,width=420,height=500";
            clientscript = "window.open('" + strUrl + "','" + strWindowName + "','" + strWinAttrib + "')";

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", clientscript, true);
        }
    }
}