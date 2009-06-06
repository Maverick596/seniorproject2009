using System;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Data.Repository.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository
{
    [Pluggable("Default")]
    public class TaskTypeRepository : ITaskTypeRepository
    {
        #region Static properties

        #endregion

        #region Instance properties

        public Connection Conn { get; set; }

        #endregion

        #region Static methods

        #endregion

        #region Instance methods

        public TaskTypeRepository()
        {
            Conn = new Connection();
        }

        /// <summary>
        /// Find all TaskType's
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <returns>return an IQueryable collection of TaskType</returns>
        public IQueryable<Domain.TaskType> All(DataContext dc)
        {
            dc = dc ?? Conn.GetContext();
            var r = from t in dc.TaskTypes
                    select new Domain.TaskType
                    {
                        ID = t.TaskTypeId,
                        Name = t.Name,
                        Type = (TaskTypes)Enum.Parse(typeof(TaskTypes), t.Name)
                    };
            return r;
        }

        /// <summary>
        /// Find an TaskType by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a TaskType</returns>
        public Domain.TaskType Find(DataContext dc, int id)
        {
            return All(dc).Where(t => t.ID == id).SingleOrDefault();
        }

        /// <summary>
        /// Find TaskType by it's Enum type
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Domain.TaskType Find(DataContext dc, TaskTypes type)
        {
            var result = All(dc).Where(t => t.Name == type.ToString()).SingleOrDefault();
            if (result == null)
            {
                result = new Domain.TaskType
                {
                    Name = type.ToString(),
                    Type = type
                };
                result.Save();
            }

            return result;
        }

        /// <summary>
        /// Save a TaskType
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="taskType"></param>
        /// <returns>returns the id of the saved taskType</returns>
        public int Save(DataContext dc, Domain.TaskType taskType)
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
        /// <param name="dc">DataContext</param>
        /// <param name="taskType"></param>
        public void Delete(DataContext dc, Domain.TaskType taskType)
        {
            dc = dc ?? Conn.GetContext();
            var dbTaskType = dc.TaskTypes.Where(t => t.TaskTypeId == taskType.ID).SingleOrDefault();
            if (dbTaskType == null) return;
            dc.TaskTypes.Attach(dbTaskType, true);
            dc.TaskTypes.DeleteOnSubmit(dbTaskType);
            dc.SubmitChanges();
        }

        #endregion
    }
}