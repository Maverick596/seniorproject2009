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
        //private static int ManagingGreenhouseID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ViewGreenhousePresenter();
            _presenter.Init(this, IsPostBack);

            //if (Session["greenhouseID"] == null)
            //{
            //    Response.Redirect("~/Greenhouses/Default.aspx");
            //}

            //if (!Page.IsPostBack)
            //{
            //    ManagingGreenhouseID = Int32.Parse(Session["greenhouseID"].ToString());
            //    lblGreenhouseID.Text = ManagingGreenhouseID.ToString();
            //}
        }

        public void LoadData(Greenhouse greenhouse)
        {
            lblGreenhouseTitle.Text = greenhouse.ToString();
        }

        public void LoadLocation(Address address)
        {
            //lblAddress.Text = address.StreetLine1;
        }

        public void LoadSection(List<Section> sections)
        {
            lvSections.DataSource = sections;
            lvSections.DataBind();
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

        protected void lvSections_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            CloseInsert();
            lvSections.EditIndex = e.NewEditIndex;
            _presenter.BindSections();
        }


        protected void lvSections_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            _presenter.BindSections();
        }


        protected void lvSections_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            if (e.CancelMode == ListViewCancelMode.CancelingInsert)
            {
                CloseInsert();
            }
            else
            {
                lvSections.EditIndex = -1;
            }
            _presenter.BindSections();
        }

        protected void lvSections_ItemUpdating(object sender, ListViewUpdateEventArgs e) { }

        protected void lvSections_ItemDeleting(object sender, ListViewDeleteEventArgs e) { }

        protected void lvSections_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Insert":
                    // Save new section
                    break;
                case "Update":
                    // update editied section
                    break;
                case "Delete":
                    // delete old section
                    break;
            }
        }

        protected void lbNewSection_Click(object sender, EventArgs e)
        {
            lvSections.EditIndex = -1;
            lvSections.InsertItemPosition = InsertItemPosition.LastItem;
            ((LinkButton)sender).Visible = false;

        }

        private void CloseInsert()
        {
            lvSections.InsertItemPosition = InsertItemPosition.None;
            lvSections.FindControl("lbNewSection").Visible = true;
        }


    }
}