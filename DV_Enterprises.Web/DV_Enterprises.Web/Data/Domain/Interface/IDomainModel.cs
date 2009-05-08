using DV_Enterprises.Web.Data.DataAccess.SqlRepository;

namespace DV_Enterprises.Web.Data.Domain.Interface
{
    /// <summary>
    /// This inteface defines the methods that all Domain models should share
    /// </summary>
    public interface IDomainModel
    {
        #region Static properties

        #endregion

        #region Instance properties

        int ID { get; set; }

        #endregion

        # region Static Methods

        /************** IDomainModel Static Methods

        /// <summary>
        /// Find all IDomainModel's
        /// </summary>
        /// <returns>return an IQueryable collection of IDomainModel</returns>
        public static IQueryable<IDomainModel> All();
        
        /// <summary>
        /// Find all IDomainModel's
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <returns>return an IQueryable collection of IDomainModel</returns>
        public static IQueryable<IDomainModel> All(DataContext dc);

        /// <summary>
        /// Find an IDomainModel by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a IDomainModel</returns>
        public static IDomainModel Find(int id);
         
        /// <summary>
        /// Find an IDomainModel by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a IDomainModel</returns>
        public static IDomainModel Find(int id);

        /// <summary>
        /// Save a IDomainModel
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="model"></param>
        /// <returns>returns the id of the saved model</returns>
        public static int Save(DataContext dc, IDomainModel model);

        /// <summary>
        /// Delete a single IDomainModel
        /// </summary>
        /// <param name="model"></param>
        // public static void Delete(IDomainModel model);
        
        /// <summary>
        /// Delete a single IDomainModel
        /// </summary>
        /// <param name="dc">DataContext</param>
        /// <param name="model"></param>
        // public static void Delete(DataContext dc, IDomainModel model);
         
        ****************/

        #endregion

        #region Instance Methods

        /// <summary>
        /// Save IDomainModel
        /// </summary>
        /// <returns>returns the id of the saved model</returns>
        int Save();

        /// <summary>
        /// Save IDomainModel
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>returns the id of the saved model</returns>
        int Save(DataContext dc);

        /// <summary>
        /// Delete IDomainModel
        /// </summary>
        void Delete();

        /// <summary>
        /// Delete IDomainModel
        /// </summary>
        /// <param name="dc"></param>
        void Delete(DataContext dc);

        #endregion
    }
}