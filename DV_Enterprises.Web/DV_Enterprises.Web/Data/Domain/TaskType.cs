using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Abstract;
using DV_Enterprises.Web.Data.Domain.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    public enum TaskTypes { Temperature, LightIntersity, Humidity }

    [Pluggable("Default")]
    public class TaskType : DomainModel, ITaskType
    {
        #region Static properties

        #endregion

        #region Instance properties

        public int ID { get; set; }
        public string Name { get; set; }

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
            dc = dc ?? Conn.GetContext();
            var r = from t in dc.TaskTypes
                    select new TaskType()
                               {
                                   ID = t.TaskTypeId,
                                   Name = t.Name
                               };
            return r;
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
            return All(dc).Where(t => t.ID == id).SingleOrDefault();
        }

        public static TaskType Find(TaskTypes type)
        {
            return Find(null, type);
        }

        public static TaskType Find(DataContext dc, TaskTypes type)
        {
            var result = new TaskType();
            switch (type)
            {
                case TaskTypes.Temperature:
                    result = All(dc).Where(t => t.Name.ToLower() == "temperature").SingleOrDefault();
                    break;
                case TaskTypes.LightIntersity:
                    result = All(dc).Where(t => t.Name.ToLower() == "light intersity").SingleOrDefault();
                    break;
                case TaskTypes.Humidity:
                    result = All(dc).Where(t => t.Name.ToLower() == "humidity").SingleOrDefault();
                    break;
            }
            return result;
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
            dc = dc ?? Conn.GetContext();
            var dcTaskType = dc.TaskTypes.Where(t => t.TaskTypeId == taskType.ID).SingleOrDefault();
            var isNew = false;
            if (dcTaskType == null)
            {
                dcTaskType = new DataAccess.SqlRepository.TaskType();
                isNew = true;
            }

            dcTaskType.Name = taskType.Name;

            if (isNew)
            {
                dc.TaskTypes.InsertOnSubmit(dcTaskType);
            }
            dc.SubmitChanges();
            return dcTaskType.TaskTypeId;
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
            dc = dc ?? Conn.GetContext();
            var dbTaskType = dc.TaskTypes.Where(t => t.TaskTypeId == taskType.ID).SingleOrDefault();
            if (dbTaskType == null) return;
            dc.TaskTypes.Attach(dbTaskType, true);
            dc.TaskTypes.DeleteOnSubmit(dbTaskType);
            dc.SubmitChanges();
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Save TaskType
        /// </summary>
        /// <returns>returns the id of the saved taskType</returns>
        public int Save()
        {
            return Save(this);
        }

        /// <summary>
        /// Save TaskType
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>returns the id of the saved taskType</returns>
        public int Save(DataContext dc)
        {
            return Save(dc, this);
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