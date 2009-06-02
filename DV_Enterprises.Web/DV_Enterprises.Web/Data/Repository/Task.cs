using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Repository.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository
{
    [Pluggable("Default")]
    public class Task : ITask
    {
        #region Static properties

        #endregion

        #region Instance properties

        public Connection Conn { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        public Task()
        {
            Conn = new Connection();
        }

        /// <summary>
        /// Find all Task's
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <returns>return an IQueryable collection of Task</returns>
        public IQueryable<Domain.Task> All(DataContext dc)
        {
            dc = dc ?? Conn.GetContext();
            var r = from t in dc.Tasks
                    select new Domain.Task
                               {
                                   ID = t.TaskID,
                                   SectionID = t.SectionID,
                                   StartTime = t.StartTime,
                                   EndTime = t.EndTime,
                                   Interval = (t.EndTime.TimeOfDay - t.StartTime.TimeOfDay).TotalMinutes,
                                   TaskTypeId = t.TaskTypeID,
                                   DateCreated = t.DateCreated,
                                   DateUpdated = t.DateUpdated
                               };
            return r;
        }


        /// <summary>
        /// Find an Task by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a Task</returns>
        public Domain.Task Find(DataContext dc, int id)
        {
            return All(dc).Where(t => t.ID == id).SingleOrDefault();
        }

        /// <summary>
        /// Save a Task
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="task"></param>
        /// <returns>returns the id of the saved task</returns>
        public int Save(DataContext dc, Domain.Task task)
        {
            dc = dc ?? Conn.GetContext();
            var dbTask = dc.Tasks.Where(t => t.TaskID == task.ID).SingleOrDefault();
            var isNew = false;
            if (dbTask == null)
            {
                dbTask = new DataAccess.SqlRepository.Task();
                isNew = true;
            }

            dbTask.SectionID = task.SectionID;
            dbTask.StartTime = task.StartTime;
            dbTask.EndTime = task.StartTime.AddMinutes(task.Interval);
            dbTask.TaskTypeID = task.TaskTypeId;
            dbTask.DateUpdated = DateTime.Now;

            if (isNew)
            {
                dbTask.DateCreated = DateTime.Now;
                dc.Tasks.InsertOnSubmit(dbTask);
            }
            dc.SubmitChanges();
            return dbTask.TaskID;
        }

        /// <summary>
        /// Delete a single Task
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="task"></param>
        public void Delete(DataContext dc, Domain.Task task)
        {
            dc = dc ?? Conn.GetContext();
            var dbTask = dc.Tasks.Where(t => t.TaskID == task.ID).SingleOrDefault();
            if (dbTask == null) return;
            //dc.Tasks.Attach(dbTask, true);
            dc.Tasks.DeleteOnSubmit(dbTask);
            dc.SubmitChanges();
        }

        #endregion
    }
}