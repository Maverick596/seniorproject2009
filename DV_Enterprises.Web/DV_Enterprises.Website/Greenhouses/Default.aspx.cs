using System;
using System.Collections.Generic;
using System.Web.UI;
using DV_Enterprises.Web.Domain;
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

        public void LoadData(List<Greenhouse> greenhouses)
        {
            lvGreenhouses.DataSource = greenhouses;
            lvGreenhouses.DataBind();
        }
    }
}