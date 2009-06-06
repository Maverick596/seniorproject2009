using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Data.Filters;
using DV_Enterprises.Web.Service;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace Greenhouses
{
    public partial class Default : Page
    {
        private readonly IWebContext _webContext;
        private readonly IRedirector _redirector;

        public Default()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            Bind();
        }

        private void Bind()
        {
            if (User.IsInRole("administrator"))
            {
                LoadData(Greenhouse.All());
                lbNewGreenhouse.Visible = true;
            }
            else
            {
                lbNewGreenhouse.Visible = false;
                LoadData(Greenhouse.AllByUsername(User.Identity.Name));
            }
        }

        public void LoadData(IQueryable<Greenhouse> greenhouses)
        {
            if (greenhouses != null)
            {
                lvGreenhouses.DataSource = greenhouses;
                lvGreenhouses.DataBind();
            }
        }

        protected void lbNewGreenhouse_Click(object sender, EventArgs e)
        {
            lvGreenhouses.EditIndex = -1;
            lvGreenhouses.InsertItemPosition = InsertItemPosition.FirstItem;
            ((LinkButton)sender).Visible = false;
            Bind();
        }

        protected void lbView_Click(object sender, EventArgs e)
        {
            var lbView = sender as LinkButton;
            if (lbView != null) _redirector.GoToViewGreenhouse(Convert.ToInt32(lbView.Attributes["GreenhouseID"]));
        }

        protected void lvGreenhouses_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var linkGreenhouseName = e.Item.FindControl("linkGreenhouseName") as HyperLink;
            var litGreenhouseId = e.Item.FindControl("litGreenhouseId") as Literal;
            var lbView = e.Item.FindControl("lbView") as LinkButton;

            if (linkGreenhouseName != null && litGreenhouseId != null)
                linkGreenhouseName.NavigateUrl = string.Format("~/Greenhouses/ViewGreenhouse.aspx?GreenhouseID={0}", litGreenhouseId.Text);

            if (lbView != null && litGreenhouseId != null) lbView.Attributes.Add("GreenhouseID", litGreenhouseId.Text);

            if (!User.IsInRole("administrator"))
            {
                var lbDelete = e.Item.FindControl("lbDelete") as LinkButton;
                var lbEdit = e.Item.FindControl("lbEdit") as LinkButton;
                if (lbDelete != null) lbDelete.Visible = false;
                if (lbEdit != null) lbEdit.Visible = false;
            }
        }

        protected void lvGreenhouses_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            CloseInsert();
            lvGreenhouses.EditIndex = e.NewEditIndex;
            Bind();
        }

        protected void lvGreenhouses_ItemInserting(object sender, ListViewInsertEventArgs e) { }
        protected void lvGreenhouses_ItemUpdating(object sender, ListViewUpdateEventArgs e) { }
        protected void lvGreenhouses_ItemDeleting(object sender, ListViewDeleteEventArgs e) { }

        protected void lvGreenhouses_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            if (e.CancelMode == ListViewCancelMode.CancelingInsert)
            {
                CloseInsert();
            }
            else
            {
                lvGreenhouses.EditIndex = -1;
            }
            Bind();
        }

        protected void lvGreenhouses_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Insert":
                    // Save new section
                    InsertGreenhouse(e.Item);
                    break;
                case "Update":
                    // update editied section
                    UpdateGreenhouse(e.Item);
                    break;
                case "Delete":
                    // delete old section
                    DeleteGreenhouse(e.Item);
                    break;
            }
        }

        private void CloseInsert()
        {
            lvGreenhouses.InsertItemPosition = InsertItemPosition.None;
            lbNewGreenhouse.Visible = true;
        }

        private void InsertGreenhouse(Control item)
        {
            new Greenhouse
            {
                ID = 0,
                Address = new Address
                {
                    City = ((TextBox)item.FindControl("tbxCity")).Text,
                    Country = ((TextBox)item.FindControl("tbxCountry")).Text,
                    IsDefault = ((CheckBox)item.FindControl("cboIsDefault")).Checked,
                    StateOrProvince = ((TextBox)item.FindControl("tbxState")).Text,
                    StreetLine1 = ((TextBox)item.FindControl("tbxSteetAddress1")).Text,
                    StreetLine2 = ((TextBox)item.FindControl("tbxSteetAddress2")).Text,
                    Zip = ((TextBox)item.FindControl("tbxZipCode")).Text.ToNullableInt()
                }
            }.Save();
            CloseInsert();
            Bind();
        }

        private void UpdateGreenhouse(Control item)
        {
            new Greenhouse
            {
                ID = Convert.ToInt32(((TextBox)item.FindControl("litGreenhouseID")).Text),
                Address = new Address
                {
                    City = ((TextBox)item.FindControl("tbxCity")).Text,
                    Country = ((TextBox)item.FindControl("tbxCountry")).Text,
                    IsDefault = ((CheckBox)item.FindControl("cboIsDefault")).Checked,
                    StateOrProvince = ((TextBox)item.FindControl("tbxState")).Text,
                    StreetLine1 = ((TextBox)item.FindControl("tbxSteetAddress1")).Text,
                    StreetLine2 = ((TextBox)item.FindControl("tbxSteetAddress2")).Text,
                    Zip = ((TextBox)item.FindControl("tbxZipCode")).Text.ToNullableInt()
                }
            }.Save();
            lvGreenhouses.EditIndex = -1;
            Bind();
        }

        private void DeleteGreenhouse(Control item)
        {
            var s = Greenhouse.ByID(Convert.ToInt32(((Literal)item.FindControl("litGreenhouseID")).Text));
            s.Delete();
            Bind();
        }
    }
}