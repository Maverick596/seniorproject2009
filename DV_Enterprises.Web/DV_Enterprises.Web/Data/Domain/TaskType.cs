using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class TaskType : ITaskType
    {
        #region Static properties

        private static readonly Repository.TaskTypeRepository Repository = new Repository.TaskTypeRepository();

        #endregion

        #region Instance properties

        public int ID { get; set; }
        public string Name { get; set; }
        public TaskTypes Type { get; set; }

        #endregion

        # region Static Methods

        /// <summary>
        /// Find all TaskType's
        /// </summary>
        /// <returns>return an IQueryable collection of TaskType</returns>
        public static IQueryable<TaskType> All()
        {
            return All(null);
        }

        /// <summary>
        /// Find all TaskType's
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <returns>return an IQueryable collection of TaskType</returns>
        public static IQueryable<TaskType> All(DataContext dc)
        {
            return Repository.All(dc);
        }

        /// <summary>
        /// Find an TaskType by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a TaskType</returns>
        public static TaskType Find(int id)
        {
            return Find(null, id);
        }

        /// <summary>
        /// Find an TaskType by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a TaskType</returns>
        public static TaskType Find(DataContext dc, int id)
        {
            return Repository.Find(dc, id);
        }

        public static TaskType Find(TaskTypes type)
        {
            return Find(null, type);
        }

        public static TaskType Find(DataContext dc, TaskTypes type)
        {
            return Repository.Find(dc, type);
        }

        /// <summary>
        /// Save a TaskType
        /// </summary>
        /// <param name="taskType"></param>
        /// <returns>returns the id of the saved taskType</returns>
        public static int Save(TaskType taskType)
        {
            return Save(null, taskType);
        }

        /// <summary>
        /// Save a TaskType
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="taskType"></param>
        /// <returns>returns the id of the saved taskType</returns>
        public static int Save(DataContext dc, TaskType taskType)
        {
            return Repository.Save(dc, taskType);
        }

        /// <summary>
        /// Delete a single TaskType
        /// </summary>
        /// <param name="taskType"></param>
        public static void Delete(TaskType taskType)
        {
            Delete(null, taskType);
        }

        /// <summary>
        /// Delete a single TaskType
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="taskType"></param>
        public static void Delete(DataContext dc, TaskType taskType)
        {
            Repository.Delete(dc, taskType);
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Save TaskType
        /// </summary>
        /// <returns>returns the id of the saved taskType</returns>
        public int Save()
        {
            ID = Save(this);
            return ID;
        }

        /// <summary>
        /// Save TaskType
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>returns the id of the saved taskType</returns>
        public int Save(DataContext dc)
        {
            ID = Save(dc, this);
            return ID;
        }

        /// <summary>
        /// Delete TaskType
        /// </summary>
        public void Delete()
        {
            Delete(this);
        }

        /// <summary>
        /// Delete TaskType
        /// </summary>
        /// <param name="dc"></param>
        public void Delete(DataContext dc)
        {
            Delete(dc, this);
        }

        #endregion
    }
}