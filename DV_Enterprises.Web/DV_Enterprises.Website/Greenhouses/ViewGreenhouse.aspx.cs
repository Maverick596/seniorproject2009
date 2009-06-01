using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Controls;
using DV_Enterprises.Web.Data.Domain;
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
            litStreetAddress1.Text = address.StreetLine1;
            if (address.StreetLine2 != null)
            {
                litStreetAddress2.Text = address.StreetLine2;
            }
            else
            {
                litStreetAddress2.Visible = false;
                litStreetAddress2BR.Visible = false;
            }
            litCity.Text = address.City;
            litState.Text = address.StateOrProvince;
            litZip.Text = address.Zip.ToString();
        }

        public void LoadSection(List<Section> sections)
        {
            lvSections.DataSource = sections;
            lvSections.DataBind();
        }

        public void lvSections_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var ddlPreset = e.Item.FindControl("ddlPreset") as DropDownList;
            //var tlstTemperature = e.Item.FindControl("tlstTemperature") as TaskList;
            //var tlstLightIntensity = e.Item.FindControl("tlstLightIntensity") as TaskList;
            //var tlstHumidity = e.Item.FindControl("tlstHumidity") as TaskList;
            //var litSectionID = e.Item.FindControl("litSectionID") as Literal;


            if (ddlPreset != null)
            {
                ddlPreset.DataSource = Preset.All();
                ddlPreset.DataTextField = "Name";
                ddlPreset.DataValueField = "ID";
                ddlPreset.DataBind();
            }

            //if (tlstTemperature != null)
            //{
            //    tlstTemperature.SectionID = Convert.ToInt32(litSectionID.Text);
            //    tlstTemperature.Type = TaskTypes.Temperature;
            //}

            //if (tlstLightIntensity != null)
            //{
            //    tlstLightIntensity.SectionID = Convert.ToInt32(litSectionID.Text);
            //    tlstLightIntensity.Type = TaskTypes.LightIntensity;
            //}

            //if (tlstHumidity != null)
            //{
            //    tlstHumidity.SectionID = Convert.ToInt32(litSectionID.Text);
            //    tlstHumidity.Type = TaskTypes.Humidity;
            //}
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
            //_redirector.GoToViewGreenhouse(_webContext.GreenhouseId);
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

        private void SaveSection(Control item)
        {
            new Section
                {
                    ID = Convert.ToInt32(((Literal) item.FindControl("litSectionID")).Text),
                    Name = ((TextBox) item.FindControl("tbxName")).Text,
                    GreenhouseID = _webContext.GreenhouseId,
                    UserID = new Guid(((Literal) item.FindControl("litUserID")).Text),
                    PresetID = Convert.ToInt32(((DropDownList) item.FindControl("ddlPreset")).SelectedValue),
                    IsTemperatureActivated = ((CheckBox) item.FindControl("cboIsTemperatureActivated")).Checked,
                    IdealTemperature = Parse(((TextBox) item.FindControl("tbxIdealTemperature")).Text),
                    TemperatureThreshold = Parse(((TextBox) item.FindControl("tbxTemperatureTreshold")).Text),
                    IsLightActivated = ((CheckBox) item.FindControl("cboIsLightActivated")).Checked,
                    IdealLightIntensity = Parse(((TextBox) item.FindControl("tbxIdealLightIntensity")).Text),
                    LightIntensityThreshold = Parse(((TextBox) item.FindControl("tbxLightIntensityTreshold")).Text),
                    IsHumidityActivated = ((CheckBox) item.FindControl("cboIsHumidityActivated")).Checked,
                    IdealHumidity = Parse(((TextBox) item.FindControl("tbxIdealHumidity")).Text),
                    HumidityThreshold = Parse(((TextBox) item.FindControl("tbxHumidityTreshold")).Text)
                }.Save();
            lvSections.EditIndex = -1;
            Bind();
            //_redirector.GoToViewGreenhouse(_webContext.GreenhouseId);
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
                    Name = ((TextBox) item.FindControl("tbxName")).Text,
                    GreenhouseID = _webContext.GreenhouseId,
                    UserID = new Guid(Membership.GetUser().ProviderUserKey.ToString()),
                    PresetID = Convert.ToInt32(((DropDownList) item.FindControl("ddlPreset")).SelectedValue),
                    IsTemperatureActivated = ((CheckBox) item.FindControl("cboIsTemperatureActivated")).Checked,
                    IdealTemperature = Parse(((TextBox) item.FindControl("tbxIdealTemperature")).Text),
                    TemperatureThreshold = Parse(((TextBox) item.FindControl("tbxTemperatureTreshold")).Text),
                    IsLightActivated = ((CheckBox) item.FindControl("cboIsLightActivated")).Checked,
                    IdealLightIntensity = Parse(((TextBox) item.FindControl("tbxIdealLightIntensity")).Text),
                    LightIntensityThreshold = Parse(((TextBox) item.FindControl("tbxLightIntensityTreshold")).Text),
                    IsHumidityActivated = ((CheckBox) item.FindControl("cboIsHumidityActivated")).Checked,
                    IdealHumidity = Parse(((TextBox) item.FindControl("tbxIdealHumidity")).Text),
                    HumidityThreshold = Parse(((TextBox) item.FindControl("tbxHumidityTreshold")).Text)
                }.Save();
            CloseInsert();
            //_redirector.GoToViewGreenhouse(_webContext.GreenhouseId);
            Bind();
        }

        private void DeleteSection(Control item)
        {
            var s = Section.Find(Convert.ToInt32(((Literal)item.FindControl("litSectionID")).Text));
            s.Delete();
            //_redirector.GoToViewGreenhouse(_webContext.GreenhouseId);
            Bind();
        }

        private static int? Parse(string s)
        {
            int result;
            if (!int.TryParse(s, out result))
                result = 0;
            return result == 0 ? (int?)null : result;
        }

        protected void linkEdit_Click(object sender, EventArgs e)
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