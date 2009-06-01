using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
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
            Page.Title = string.Format("{0} &mdash; Smart Greenhouse Solutions", greenhouse);
            lblGreenhouseTitle.Text = greenhouse.ToString();
        }

        public void LoadLocation(Address address)
        {
            lblAddress.Text = address.StreetLine1 + "<br />";

            if (address.StreetLine2 != "")
            {
                lblAddress.Text += address.StreetLine2 + "<br />";
            }

            lblAddress.Text += address.City + ", " +
                               address.StateOrProvince + " " +
                               address.Zip +
                                "<br /><br />";
        }

        public void LoadSection(List<Section> sections)
        {
            lvSections.DataSource = sections;
            lvSections.DataBind();
        }

        public void lvSections_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var ddlPreset = e.Item.FindControl("ddlPreset") as DropDownList;
            var tlstTemperature = e.Item.FindControl("tlstTemperature") as TaskList;
            var tlstLightIntensity = e.Item.FindControl("tlstLightIntensity") as TaskList;
            var tlstHumidity = e.Item.FindControl("tlstHumidity") as TaskList;
            var litSectionID = e.Item.FindControl("litSectionID") as Literal;

            ////binding SectionIDs to Task Buttons - Start
            //var tempTask = e.Item.FindControl("lbNewTemperatureTask") as LinkButton;
            //tempTask.CommandArgument = litSectionID.Text;

            //var lightIntensityTask = e.Item.FindControl("lbNewLightIntensityTask") as LinkButton;
            //lightIntensityTask.CommandArgument = litSectionID.Text;

            //var humidityTask = e.Item.FindControl("lbNewHumidityTask") as LinkButton;
            //humidityTask.CommandArgument = litSectionID.Text;
            ////binding SectionIDs to Task Buttons - Done

            if (ddlPreset != null)
            {
                ddlPreset.DataSource = Preset.All();
                ddlPreset.DataTextField = "Name";
                ddlPreset.DataValueField = "ID";
                ddlPreset.DataBind();
            }

            if (tlstTemperature != null)
            {
                tlstTemperature.SectionID = Convert.ToInt32(litSectionID.Text);
                tlstTemperature.Type = TaskTypes.Temperature;
            }

            if (tlstLightIntensity != null)
            {
                tlstLightIntensity.SectionID = Convert.ToInt32(litSectionID.Text);
                tlstLightIntensity.Type = TaskTypes.LightIntensity;
            }

            if (tlstHumidity != null)
            {
                tlstHumidity.SectionID = Convert.ToInt32(litSectionID.Text);
                tlstHumidity.Type = TaskTypes.Humidity;
            }
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
            ListViewDataItem listView = item as ListViewDataItem;

            //testing reading values from ListView
            //String sectionID = (listView.FindControl("litSectionID") as Literal).Text;

            var s = new Section
                        {
                            ID = Int32.Parse((listView.FindControl("litSectionID") as Literal).Text),
                            Name = (listView.FindControl("tbxName") as TextBox).Text,
                            GreenhouseID = _presenter.GreenhouseID,
                            UserID = new Guid((listView.FindControl("litUserID") as Literal).Text),
                            PresetID = Int32.Parse((listView.FindControl("ddlPreset") as DropDownList).SelectedValue),
                            IsTemperatureActivated = (listView.FindControl("cboIsTemperatureActivated") as CheckBox).Checked,
                            IdealTemperature = Int32.Parse((listView.FindControl("tbxIdealTemperature") as TextBox).Text),
                            TemperatureTreshold = Int32.Parse((listView.FindControl("tbxTemperatureTreshold") as TextBox).Text),
                            IsLightActivated = (listView.FindControl("cboIsLightActivated") as CheckBox).Checked,
                            IdealLightIntensity = Int32.Parse((listView.FindControl("tbxIdealLightIntensity") as TextBox).Text),
                            LightIntensityTreshold = Int32.Parse((listView.FindControl("tbxLightIntensityTreshold") as TextBox).Text),
                            IsHumidityActivated = (listView.FindControl("cboIsHumidityActivated") as CheckBox).Checked,
                            IdealHumidity = Int32.Parse((listView.FindControl("tbxIdealHumidity") as TextBox).Text),
                            HumidityTreshold = Int32.Parse((listView.FindControl("tbxHumidityTreshold") as TextBox).Text),
                            //original code:

                            //ID = Convert.ToInt32(((Literal)item.FindControl("litSectionID")).Text),
                            //Name = ((TextBox)item.FindControl("tbxName")).Text,
                            //GreenhouseID = _presenter.GreenhouseID,
                            //UserID = new Guid(((Literal)item.FindControl("litUserID")).Text),
                            //PresetID = Convert.ToInt32(((DropDownList)item.FindControl("ddlPreset")).SelectedValue),
                            //IsTemperatureActivated = ((CheckBox)item.FindControl("cboIsTemperatureActivated")).Checked,
                            //IdealTemperature = Parse(((TextBox)item.FindControl("tbxIdealTemperature")).Text),
                            //TemperatureTreshold = Parse(((TextBox)item.FindControl("tbxTemperatureTreshold")).Text),
                            //IsLightActivated = ((CheckBox)item.FindControl("cboIsLightActivated")).Checked,
                            //IdealLightIntensity = Parse(((TextBox)item.FindControl("tbxIdealLightIntensity")).Text),
                            //LightIntensityTreshold = Parse(((TextBox)item.FindControl("tbxLightIntensityTreshold")).Text),
                            //IsHumidityActivated = ((CheckBox)item.FindControl("cboIsHumidityActivated")).Checked,
                            //IdealHumidity = Parse(((TextBox)item.FindControl("tbxIdealHumidity")).Text),
                            //HumidityTreshold = Parse(((TextBox)item.FindControl("tbxHumidityTreshold")).Text)
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
                            IdealTemperature = Parse(((TextBox)item.FindControl("tbxIdealTemperature")).Text),
                            TemperatureTreshold = Parse(((TextBox)item.FindControl("tbxTemperatureTreshold")).Text),
                            IsLightActivated = ((CheckBox)item.FindControl("cboIsLightActivated")).Checked,
                            IdealLightIntensity = Parse(((TextBox)item.FindControl("tbxIdealLightIntensity")).Text),
                            LightIntensityTreshold = Parse(((TextBox)item.FindControl("tbxLightIntensityTreshold")).Text),
                            IsHumidityActivated = ((CheckBox)item.FindControl("cboIsHumidityActivated")).Checked,
                            IdealHumidity = Parse(((TextBox)item.FindControl("tbxIdealHumidity")).Text),
                            HumidityTreshold = Parse(((TextBox)item.FindControl("tbxHumidityTreshold")).Text)
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

        private static int? Parse(string s)
        {
            int result;
            if (int.TryParse(s, out result))
                result = 0;
            return result == 0 ? (int?) null : result;
        }

        protected void lbManage_Click(object sender, EventArgs e)
        {
            const string windowName = "ManageGreenhouse";
            const string url = "ManageGreenhouse.aspx";
            const string windowAttribute = "toolbar=no,menu=no,status=no,width=420,height=400";
            var clientscript = string.Format("window.open('{0}', '{1}', '{2}')", url, windowName, windowAttribute);

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", clientscript, true);
        }

        protected void lbNewlbNewTemperatureTask_OnClick(object sender, EventArgs e)
        {
            var button = sender as LinkButton;

            String sectionID = button.CommandArgument;

            const string windowName = "AddTask";
            string url = "AddTask.aspx?&TaskType=Temperature&SectionID=" + sectionID;
            const string windowAttribute = "toolbar=no,menu=no,status=no,width=420,height=400";
            var clientscript = string.Format("window.open('{0}', '{1}', '{2}')", url, windowName, windowAttribute);

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", clientscript, true);
        }

        protected void lbNewLightIntensityTask_OnClick(object sender, EventArgs e)
        {
            var button = sender as LinkButton;

            String sectionID = button.CommandArgument;

            const string windowName = "AddTask";
            string url = "AddTask.aspx?&TaskType=LightIntensity&SectionID=" + sectionID;
            const string windowAttribute = "toolbar=no,menu=no,status=no,width=420,height=400";
            var clientscript = string.Format("window.open('{0}', '{1}', '{2}')", url, windowName, windowAttribute);

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", clientscript, true);
        }

        protected void lbNewHumidityTask_OnClick(object sender, EventArgs e)
        {
            var button = sender as LinkButton;

            String sectionID = button.CommandArgument;

            const string windowName = "AddTask";
            string url = "AddTask.aspx?&TaskType=Humidity&SectionID=" + sectionID;
            const string windowAttribute = "toolbar=no,menu=no,status=no,width=420,height=400";
            var clientscript = string.Format("window.open('{0}', '{1}', '{2}')", url, windowName, windowAttribute);

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", clientscript, true);
        }
    }
}