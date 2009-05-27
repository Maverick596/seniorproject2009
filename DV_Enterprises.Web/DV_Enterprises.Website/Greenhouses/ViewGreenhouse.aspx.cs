using System;
using System.Collections.Generic;
using System.Web.Security;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            _presenter = new ViewGreenhousePresenter();
            _presenter.Init(this, IsPostBack);
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

        public void lvSections_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var ddlPreset = e.Item.FindControl("ddlPreset") as DropDownList;

            if (ddlPreset == null) return;
            ddlPreset.DataSource = Preset.All();
            ddlPreset.DataTextField = "Name";
            ddlPreset.DataValueField = "ID";
            ddlPreset.DataBind();
        }

        protected void lvSections_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            CloseInsert();
            lvSections.EditIndex = e.NewEditIndex;
            _presenter.BindSections();
        }

        protected void lvSections_ItemInserting(object sender, ListViewInsertEventArgs e) { }
        protected void lvSections_ItemUpdating(object sender, ListViewUpdateEventArgs e) { }
        protected void lvSections_ItemDeleting(object sender, ListViewDeleteEventArgs e) { }

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

        protected void lvSections_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Insert":
                    // Save new section
                    InsertSection(e.Item);
                    break;
                case "Update":
                    // update editied section
                    SaveSection(e.Item);
                    break;
                case "Delete":
                    // delete old section
                    DeleteSection(e.Item);
                    break;
            }
        }

        protected void lbNewSection_Click(object sender, EventArgs e)
        {

            lvSections.EditIndex = -1;
            lvSections.InsertItemPosition = InsertItemPosition.LastItem;
            ((LinkButton)sender).Visible = false;
            _presenter.BindSections();

            var ddlPreset = lvSections.InsertItem.FindControl("ddlPreset") as DropDownList;

            if (ddlPreset == null) return;
            ddlPreset.DataSource = Preset.All();
            ddlPreset.DataTextField = "Name";
            ddlPreset.DataValueField = "ID";
            ddlPreset.DataBind();
        }

        private void CloseInsert()
        {
            lvSections.InsertItemPosition = InsertItemPosition.None;
            lvSections.FindControl("lbNewSection").Visible = true;
        }

        private void SaveSection(Control item)
        {
            var s = new Section
                        {
                            ID = Convert.ToInt32(((Literal)item.FindControl("litSectionID")).Text),
                            Name = ((TextBox)item.FindControl("tbxName")).Text,
                            GreenhouseID = _presenter.GreenhouseID,
                            UserID = new Guid(((Literal)item.FindControl("litUserID")).Text),
                            PresetID = Convert.ToInt32(((DropDownList)item.FindControl("ddlPreset")).SelectedValue),
                            IsTemperatureActivated = ((CheckBox)item.FindControl("cboIsTemperatureActivated")).Checked,
                            IdealTemperature = Convert.ToInt32(((TextBox)item.FindControl("tbxIdealTemperature")).Text),
                            TemperatureTreshold =
                                Convert.ToInt32(((TextBox)item.FindControl("tbxTemperatureTreshold")).Text),
                            IsLightActivated = ((CheckBox)item.FindControl("cboIsLightActivated")).Checked,
                            IdealLightIntensity =
                                Convert.ToInt32(((TextBox)item.FindControl("tbxIdealLightIntensity")).Text),
                            LightIntensityTreshold =
                                Convert.ToInt32(((TextBox)item.FindControl("tbxLightIntensityTreshold")).Text),
                            IsHumidityActivated = ((CheckBox)item.FindControl("cboIsHumidityActivated")).Checked,
                            IdealHumidity = Convert.ToInt32(((TextBox)item.FindControl("tbxIdealHumidity")).Text),
                            HumidityTreshold = Convert.ToInt32(((TextBox)item.FindControl("tbxHumidityTreshold")).Text)
                        };
            s.Save();
            lvSections.EditIndex = -1;
            _presenter.BindSections();
        }


        /// <summary>
        /// inserts a new section. At the moment it only inserts the current User as the section owner
        /// </summary>
        /// <param name="item">ListView item. This should be a section</param>
        private void InsertSection(Control item)
        {
            var s = new Section
                        {
                            ID = 0,
                            Name = ((TextBox)item.FindControl("tbxName")).Text,
                            GreenhouseID = _presenter.GreenhouseID,
                            UserID = new Guid(Membership.GetUser().ProviderUserKey.ToString()),
                            PresetID = Convert.ToInt32(((DropDownList)item.FindControl("ddlPreset")).SelectedValue),
                            IsTemperatureActivated = ((CheckBox)item.FindControl("cboIsTemperatureActivated")).Checked,
                            IdealTemperature = Convert.ToInt32(((TextBox)item.FindControl("tbxIdealTemperature")).Text),
                            TemperatureTreshold =
                                Convert.ToInt32(((TextBox)item.FindControl("tbxTemperatureTreshold")).Text),
                            IsLightActivated = ((CheckBox)item.FindControl("cboIsLightActivated")).Checked,
                            IdealLightIntensity =
                                Convert.ToInt32(((TextBox)item.FindControl("tbxIdealLightIntensity")).Text),
                            LightIntensityTreshold =
                                Convert.ToInt32(((TextBox)item.FindControl("tbxLightIntensityTreshold")).Text),
                            IsHumidityActivated = ((CheckBox)item.FindControl("cboIsHumidityActivated")).Checked,
                            IdealHumidity = Convert.ToInt32(((TextBox)item.FindControl("tbxIdealHumidity")).Text),
                            HumidityTreshold = Convert.ToInt32(((TextBox)item.FindControl("tbxHumidityTreshold")).Text)
                        };
            s.Save();
            CloseInsert();
            _presenter.BindSections();
        }

        private void DeleteSection(Control item)
        {
            var s = Section.Find(Convert.ToInt32(((Literal)item.FindControl("litSectionID")).Text));
            s.Delete();
            _presenter.BindSections();
        }
    }
}