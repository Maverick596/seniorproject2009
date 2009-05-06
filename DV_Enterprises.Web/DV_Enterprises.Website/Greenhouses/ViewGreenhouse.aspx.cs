using System;
using System.Collections.Generic;
using System.Web.UI;
using DV_Enterprises.Web.Domain;
using DV_Enterprises.Web.Presenter.Greenhouses;
using DV_Enterprises.Web.Presenter.Greenhouses.Interface;

namespace Greenhouses
{
    public partial class ViewGreenhouse : Page, IViewGreenhouse
    {
        private ViewGreenhousePresenter _presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ViewGreenhousePresenter();
            _presenter.Init(this, IsPostBack);
        }

        public void LoadData(Greenhouse greenhouse)
        {
            return; //Doee nothing now ???
        }

        public void LoadLocation(Location location)
        {
            lblAddress.Text = location.AddressLine1;
        }

        public void LoadSection(List<Section> sections)
        {
            lvSections.DataSource = sections;
            lvSections.DataBind();
        }
    }
}