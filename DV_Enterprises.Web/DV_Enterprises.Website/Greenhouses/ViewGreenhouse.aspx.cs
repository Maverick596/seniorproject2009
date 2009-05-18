using System;
using System.Collections.Generic;
using System.Web.UI;
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
            lvSections.DataSource = sections;
            lvSections.DataBind();
        }
    }
}