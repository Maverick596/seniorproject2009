using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace Controls
{
    public partial class TaskList : UserControl
    {
        private readonly IWebContext _webContext;
        private readonly IRedirector _redirector;
        private int _taskTypeID;

        [Category("Appearance")]
        public int SectionID { get; set; }

        [Category("Appearance")]
        public TaskTypes Type { get; set; }

        [Category("Appearance")]
        public string TaskName { get; set; }

        public int TaskTypeID
        {
            get { return _taskTypeID != 0 ? _taskTypeID : (TaskTypeID = TaskType.Find(Type).ID); }
            private set { _taskTypeID = value; }
        }

        public TaskList()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            litTaskTitle.Text = string.Format("{0} tasks", TaskName);

            if (!Page.IsPostBack)
            {
                litSectionID.Text = SectionID.ToString();
                litTaskTypeID.Text = TaskTypeID.ToString();
                litTaskName.Text = TaskName;
                BindTasks();
            }
            else
            {
                if (litSectionID.Text != string.Empty)
                {
                    SectionID = Convert.ToInt32(litSectionID.Text);
                }
                if (litTaskTypeID.Text != string.Empty)
                {
                    TaskTypeID = Convert.ToInt32(litTaskTypeID.Text);
                }
                if (litTaskName.Text != string.Empty)
                {
                    TaskName = litTaskName.Text;
                }
            }
            HidePanel();
        }

        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            ShowPanel();
        }

        protected void btnSaveTask_Click(object sender, EventArgs e)
        {
            var startHour = ddlStartTimeAmPm.SelectedValue.ToLower() == "am"
                                ? Convert.ToInt32(ddlStartTimeHours.SelectedValue)
                                : Convert.ToInt32(ddlStartTimeHours.SelectedValue) + 12;
            var startMin = Convert.ToInt32(ddlStartTimeMinutes.SelectedValue);
            var interval = Convert.ToDouble(ddlInterval.SelectedValue);

            new Task
                {
                    ID = 0,
                    SectionID = SectionID,
                    TaskTypeId = TaskTypeID,
                    StartTime =
                        new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, startHour,
                                     startMin, 0),
                    Interval = interval
                }.Save();
            HidePanel();
            _redirector.GoToViewGreenhouse(_webContext.GreenhouseId);
        }

        protected void gvwTasks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var startTime = Convert.ToDateTime(gvwTasks.Rows[e.RowIndex].Cells[0].Text);
            Task.All().Where(t => t.StartTime == startTime && t.SectionID == SectionID && t.TaskTypeId == TaskTypeID).First().Delete();
            BindTasks();
            _redirector.GoToViewGreenhouse(_webContext.GreenhouseId);
        }

        private void BindTasks()
        {
            gvwTasks.DataSource = Tasks(SectionID, TaskTypeID);
            gvwTasks.DataBind();
        }

        private void ShowPanel()
        {
            pnlAddTask.Visible = true;
            btnAddTask.Visible = false;
        }

        private void HidePanel()
        {
            btnAddTask.Visible = true;
            pnlAddTask.Visible = false;
        }

        private static List<Task> Tasks(int sectionID, int taskTypeID)
        {
            return Task.All().Where(t => t.SectionID == sectionID && t.TaskTypeId == taskTypeID).ToList();
        }
    }
}