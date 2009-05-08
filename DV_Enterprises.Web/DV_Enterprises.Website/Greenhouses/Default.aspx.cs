using System;
using System.Collections.Generic;
using System.Web.UI;
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
    }
}