using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Service;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace Greenhouses
{
    public partial class ViewGreenhouse : Page
    {
        private readonly IWebContext _webContext;
        private readonly IRedirector _redirector;

        public ViewGreenhouse()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (_webContext.GreenhouseId <= 0) return;
            Bind();
        }

        private void Bind()
        {
            var greenhouse = Greenhouse.Find(_webContext.GreenhouseId);
            LoadData(greenhouse);
            LoadLocation(greenhouse.Address);
            LoadSection(greenhouse.Sections.ToList());
        }

        public void LoadData(Greenhouse greenhouse)
        {
            Page.Title = string.Format("{0} &mdash; Smart Greenhouse Solutions", greenhouse);
            litGreenhouseTitle.Text = greenhouse.ToString();
        }

        public void LoadLocation(Address address)
        {
            tbxSteetAddress1.Text = litStreetAddress1.Text = address.StreetLine1;
            if (!string.IsNullOrEmpty(address.StreetLine2))
            {
                litStreetAddress2.Visible = true;
                litStreetAddress2BR.Visible = true;
                tbxSteetAddress2.Text = litStreetAddress2.Text = address.StreetLine2;
            }
            else
            {
                litStreetAddress2.Visible = false;
                litStreetAddress2BR.Visible = false;
            }
            tbxCity.Text = litCity.Text = address.City;
            tbxState.Text = litState.Text = address.StateOrProvince;
            tbxCountry.Text = litCountry.Text = address.Country;
            tbxZipCode.Text = litZip.Text = address.Zip.ToString();
            cboIsDefault.Checked = address.IsDefault;
        }

        public void LoadSection(List<Section> sections)
        {
            lvSections.DataSource = sections;
            lvSections.DataBind();
        }

        public void lvSections_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var ddlPreset = e.Item.FindControl("ddlPreset") as DropDownList;

            if (ddlPreset != null)
            {
                ddlPreset.DataSource = Preset.All();
                ddlPreset.DataTextField = "Name";
                ddlPreset.DataValueField = "ID";
                ddlPreset.DataBind();
            }

            var litIsTemperatureActivated = e.Item.FindControl("litIsTemperatureActivated") as Literal;
            var pnlTemperature = e.Item.FindControl("pnlTemperature") as Panel;
            if (litIsTemperatureActivated != null)
            {
                if (bool.Parse(litIsTemperatureActivated.Text))
                {
                    if (pnlTemperature != null) pnlTemperature.Visible = true;
                }
                else
                {
                    if (pnlTemperature != null) pnlTemperature.Visible = false;
                }
            }

            var litIsLightActivated = e.Item.FindControl("litIsLightActivated") as Literal;
            var pnlLighting = e.Item.FindControl("pnlLighting") as Panel;
            if (litIsLightActivated != null)
            {
                if (bool.Parse(litIsLightActivated.Text))
                {
                    if (pnlLighting != null) pnlLighting.Visible = true;
                }
                else
                {
                    if (pnlLighting != null) pnlLighting.Visible = false;
                }
            }

            var litIsHumidityActivated = e.Item.FindControl("litIsHumidityActivated") as Literal;
            var pnlHumidity = e.Item.FindControl("pnlHumidity") as Panel;
            if (litIsHumidityActivated != null)
            {
                if (bool.Parse(litIsHumidityActivated.Text))
                {
                    if (pnlHumidity != null) pnlHumidity.Visible = true;
                }
                else
                {
                    if (pnlHumidity != null) pnlHumidity.Visible = false;
                }
            }

            var lblNoModules = e.Item.FindControl("lblNoModules") as Label;
            if (litIsTemperatureActivated != null && litIsLightActivated != null && litIsHumidityActivated != null)
            {
                if (!bool.Parse(litIsTemperatureActivated.Text) && !bool.Parse(litIsLightActivated.Text) && !bool.Parse(litIsHumidityActivated.Text))
                {
                    if (lblNoModules != null) lblNoModules.Visible = true;
                }
            }
        }

        protected void lvSections_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            CloseInsert();
            lvSections.EditIndex = e.NewEditIndex;
            Bind();
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
            Bind();
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
                    UpdateSection(e.Item);
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
            lvSections.InsertItemPosition = InsertItemPosition.FirstItem;
            ((LinkButton)sender).Visible = false;
            Bind();

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
            lbNewSection.Visible = true;
        }

        private void UpdateSection(Control item)
        {
            new Section
                {
                    ID = Convert.ToInt32(((Literal)item.FindControl("litSectionID")).Text),
                    Name = ((TextBox)item.FindControl("tbxName")).Text,
                    GreenhouseID = _webContext.GreenhouseId,
                    UserID = new Guid(((Literal)item.FindControl("litUserID")).Text),
                    PresetID = Convert.ToInt32(((DropDownList)item.FindControl("ddlPreset")).SelectedValue),
                    IsTemperatureActivated = ((CheckBox)item.FindControl("cboIsTemperatureActivated")).Checked,
                    IdealTemperature = ((TextBox)item.FindControl("tbxIdealTemperature")).Text.ToNullableInt(),
                    TemperatureThreshold = ((TextBox)item.FindControl("tbxTemperatureTreshold")).Text.ToNullableInt(),
                    IsLightActivated = ((CheckBox)item.FindControl("cboIsLightActivated")).Checked,
                    IdealLightIntensity = ((TextBox)item.FindControl("tbxIdealLightIntensity")).Text.ToNullableInt(),
                    LightIntensityThreshold = ((TextBox)item.FindControl("tbxLightIntensityTreshold")).Text.ToNullableInt(),
                    IsHumidityActivated = ((CheckBox)item.FindControl("cboIsHumidityActivated")).Checked,
                    IdealHumidity = ((TextBox)item.FindControl("tbxIdealHumidity")).Text.ToNullableInt(),
                    HumidityThreshold = ((TextBox)item.FindControl("tbxHumidityTreshold")).Text.ToNullableInt()
                }.Save();
            lvSections.EditIndex = -1;
            Bind();
        }


        /// <summary>
        /// inserts a new section. At the moment it only inserts the current User as the section owner
        /// </summary>
        /// <param name="item">ListView item. This should be a section</param>
        private void InsertSection(Control item)
        {
            new Section
                {
                    ID = 0,
                    Name = ((TextBox)item.FindControl("tbxName")).Text,
                    GreenhouseID = _webContext.GreenhouseId,
                    UserID = new Guid(Membership.GetUser().ProviderUserKey.ToString()),
                    PresetID = Convert.ToInt32(((DropDownList)item.FindControl("ddlPreset")).SelectedValue),
                    IsTemperatureActivated = ((CheckBox)item.FindControl("cboIsTemperatureActivated")).Checked,
                    IdealTemperature = ((TextBox)item.FindControl("tbxIdealTemperature")).Text.ToNullableInt(),
                    TemperatureThreshold = ((TextBox)item.FindControl("tbxTemperatureTreshold")).Text.ToNullableInt(),
                    IsLightActivated = ((CheckBox)item.FindControl("cboIsLightActivated")).Checked,
                    IdealLightIntensity = ((TextBox)item.FindControl("tbxIdealLightIntensity")).Text.ToNullableInt(),
                    LightIntensityThreshold = ((TextBox)item.FindControl("tbxLightIntensityTreshold")).Text.ToNullableInt(),
                    IsHumidityActivated = ((CheckBox)item.FindControl("cboIsHumidityActivated")).Checked,
                    IdealHumidity = ((TextBox)item.FindControl("tbxIdealHumidity")).Text.ToNullableInt(),
                    HumidityThreshold = ((TextBox)item.FindControl("tbxHumidityTreshold")).Text.ToNullableInt()
                }.Save();
            CloseInsert();
            Bind();
        }

        private void DeleteSection(Control item)
        {
            var s = Section.Find(Convert.ToInt32(((Literal)item.FindControl("litSectionID")).Text));
            s.Delete();
            Bind();
        }

        public string PresetValue(int? s)
        {
            return s == null ? string.Empty : string.Format("<span class='section_preset'>{0}</span>", s.ToString());
        }

        protected void linkEdit_Click(object sender, EventArgs e)
        {
            linkEdit.Visible = false;
            pnlEditGreenhouse.Visible = true;
            pnlGreenhouseAddress.Visible = false;
        }

        protected void butUpdateGreenhouse_Click(object sender, EventArgs e)
        {
            var g = new Greenhouse
                {
                    ID = _webContext.GreenhouseId,
                    Address = new Address
                                  {
                                      City = tbxCity.Text,
                                      Country = tbxCountry.Text,
                                      IsDefault = cboIsDefault.Checked,
                                      StateOrProvince = tbxState.Text,
                                      StreetLine1 = tbxSteetAddress1.Text,
                                      StreetLine2 = tbxSteetAddress2.Text,
                                      Zip = tbxZipCode.Text.ToNullableInt()
                                  }
                };
            g.Save();
            LoadLocation(g.Address);
            linkEdit.Visible = true;
            pnlEditGreenhouse.Visible = false;
            pnlGreenhouseAddress.Visible = true;
        }

        protected void linkCancelUpdateGreenhouse_Click(object sender, EventArgs e)
        {
            linkEdit.Visible = true;
            pnlEditGreenhouse.Visible = false;
            pnlGreenhouseAddress.Visible = true;
        }
    }
}