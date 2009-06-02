using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class Task : ITask
    {
        #region Static properties

        private static readonly Repository.Task Repository = new Repository.Task();

        #endregion

        #region Instance properties

        private TaskType _taskType;

        public int ID { get; set; }
        public int SectionID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Interval { get; set; }
        public int TaskTypeId { get; set; }
        public TaskType TaskType
        {
            get { return _taskType ?? (TaskType = TaskType.Find(TaskTypeId)); }
            set { _taskType = value; }
        }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        #endregion

        # region Static Methods

        /// <summary>
        /// Find all Task's
        /// </summary>
        /// <returns>return an IQueryable collection of Task</returns>
        public static IQueryable<Task> All()
        {
            return All(null);
        }

        /// <summary>
        /// Find all Task's
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <returns>return an IQueryable collection of Task</returns>
        public static IQueryable<Task> All(DataContext dc)
        {
            return Repository.All(dc);
        }


        /// <summary>
        /// Find an Task by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a Task</returns>
        public static Task Find(int id)
        {
            return Find(null, id);
        }

        /// <summary>
        /// Find an Task by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a Task</returns>
        public static Task Find(DataContext dc, int id)
        {
            return Repository.Find(dc, id);
        }

        /// <summary>
        /// Save a Task
        /// </summary>
        /// <param name="task"></param>
        /// <returns>returns the id of the saved task</returns>
        public static int Save(Task task)
        {
            return Save(null, task);
        }

        /// <summary>
        /// Save a Task
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="task"></param>
        /// <returns>returns the id of the saved task</returns>
        public static int Save(DataContext dc, Task task)
        {
            return Repository.Save(dc, task);
        }

        /// <summary>
        /// Delete a single Task
        /// </summary>
        /// <param name="task"></param>
        public static void Delete(Task task)
        {
            Delete(null, task);
        }

        /// <summary>
        /// Delete a single Task
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="task"></param>
        public static void Delete(DataContext dc, Task task)
        {
            Repository.Delete(dc, task);
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Save Task
        /// </summary>
        /// <returns>returns the id of the saved task</returns>
        public int Save()
        {
            return Save(this);
        }

        /// <summary>
        /// Save Task
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>returns the id of the saved task</returns>
        public int Save(DataContext dc)
        {
            return Save(dc, this);
        }

        /// <summary>
        /// Delete Task
        /// </summary>
        public void Delete()
        {
            Delete(this);
        }

        /// <summary>
        /// Delete Task
        /// </summary>
        /// <param name="dc"></param>
        public void Delete(DataContext dc)
        {
            Delete(dc, this);
        }

        #endregion
    }
}