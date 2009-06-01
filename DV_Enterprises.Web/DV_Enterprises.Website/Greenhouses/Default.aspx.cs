using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Presenter.Greenhouses;
using DV_Enterprises.Web.Presenter.Greenhouses.Interface;

namespace Greenhouses
{
    public partial class Default : Page, IDefault
    {
        private DefaultPresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new DefaultPresenter();
            _presenter.Init(this);
        }

        public void LoadData(IList<Greenhouse> greenhouses)
        {
            lvGreenhouses.DataSource = greenhouses;
            lvGreenhouses.DataBind();
        }

        protected void lvGreenhouses_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var linkGreenhouseName = e.Item.FindControl("linkGreenhouseName") as HyperLink;
            var litGreenhouseId = e.Item.FindControl("litGreenhouseId") as Literal;
            var lbView = e.Item.FindControl("lbView") as LinkButton;

            lbView.Attributes.Add("GreenhouseID", litGreenhouseId.Text);
            linkGreenhouseName.NavigateUrl = string.Format("~/Greenhouses/ViewGreenhouse.aspx?GreenhouseID={0}",litGreenhouseId.Text);
        }

        protected void lbView_Click(object sender, EventArgs e)
        {
            var lbView = sender as LinkButton;
            _presenter.Redirector.GoToViewGreenhouse(Convert.ToInt32(lbView.Attributes["GreenhouseID"]));
        }

        protected void btnSelectGreenhouse_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            int id = button.Text.IndexOf(':');

            String greenhouseID = button.Text.Substring(id + 1);

            //Store the text of the button, the Greenhouse's ID, into a session variable.
            Session["greenhouseID"] = greenhouseID;

            //Redirect to ViewGreenhouse.aspx
            Response.Redirect("ViewGreenhouse.aspx");
        }

        protected void btnNewGreenhouse_Click(object sender, EventArgs e)
        {
            const string windowName = "NewGreenhouse";
            const string url = "NewGreenhouse.aspx";
            const string windowAttribute = "toolbar=no,menu=no,status=no,width=620,height=400";
            var clientscript = string.Format("window.open('{0}', '{1}', '{2}')", url, windowName, windowAttribute);

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", clientscript, true);
        }
    }
}