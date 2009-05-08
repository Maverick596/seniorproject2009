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

        /// <summary>
        /// Find all IDomainModel's
        /// </summary>
        /// <returns>return an IQueryable collection of IDomainModel</returns>
        // public static IQueryable<IDomainModel> All();

        /// <summary>
        /// Find an IDomainModel by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a IDomainModel</returns>
        // public static IDomainModel Find(int id);

        /// <summary>
        /// Save a IDomainModel
        /// </summary>
        /// <param name="model"></param>
        /// <returns>returns the id of the saved model</returns>
        // public static int Save(IDomainModel model);

        /// <summary>
        /// Delete a single 
        /// </summary>
        /// <param name="model"></param>
        // public static void Delete(IDomainModel model);

        #endregion

        #region Instance Methods

        /// <summary>
        /// Save IDomainModel
        /// </summary>
        /// <returns>returns the id of the saved model</returns>
        int Save();

        /// <summary>
        /// Delete IDomainModel
        /// </summary>
        void Delete();

        #endregion
    }
}