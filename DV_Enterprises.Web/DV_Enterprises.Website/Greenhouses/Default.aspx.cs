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
            rptGreenHouses.DataSource = greenhouses;
            rptGreenHouses.DataBind();
        }

        protected void btnSelectGreenhouse_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            int id = button.Text.IndexOf(':');

            String greenhouseID = button.Text.Substring(id + 1);

            //Store the text of the button, the Greenhouse's ID, into a session variable.
            Session["greenhouseID"] = greenhouseID;

            //Redirect to ManageGreenhouse.aspx
            Response.Redirect("ManageGreenhouse.aspx");
        }
    }
}