using System;
using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Repository.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Repository
{
    [Pluggable("Default")]
    public class ProductRepository:IProductRepository
    {
        #region  Static properties

        #endregion

        #region Instance properties

        public Connection Conn { get; set; }

        #endregion

        #region  Static methods

        #endregion

        #region Instance methods

        public ProductRepository()
        {
            Conn = new Connection();
        }

        /// <summary>
        /// Find all Product's
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>return an IQueryable collection of Product</returns>
        public  IList<Domain.Product> All(DataContext dc)
        {
            dc = dc ?? Conn.GetContext();
            var r = from p in dc.Products
                    select new Domain.Product
                    {
                        ID = p.ProductID,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        IsActive = p.IsActive,
                        Image = p.Image,
                        DateUpdated = p.DateUpdated,
                        DateCreated = p.DateCreated
                    };
            return r.ToList();
        }

        /// <summary>
        /// Find an Product by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a Product</returns>
        public Domain.Product Find(DataContext dc, int id)
        {
            return All(dc).Where(p => p.ID == id).SingleOrDefault();
        }

        /// <summary>
        /// Save a Product
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="product"></param>
        /// <returns>returns the id of the saved product</returns>
        public  int Save(DataContext dc, Domain.Product product)
        {
            dc = dc ?? Conn.GetContext();
            var dbProduct = dc.Products.Where(p => p.ProductID == product.ID).SingleOrDefault();
            var isNew = false;
            if (dbProduct == null)
            {
                dbProduct = new Product();
                isNew = true;
            }

            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.IsActive = product.IsActive;
            dbProduct.Image = product.Image;
            dbProduct.DateUpdated = DateTime.Now;

            if (isNew)
            {
                dbProduct.DateCreated = DateTime.Now;
                dc.Products.InsertOnSubmit(dbProduct);
            }
            dc.SubmitChanges();
            return dbProduct.ProductID;
        }

        /// <summary>
        /// Delete a single product
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="product"></param>
        public void Delete(DataContext dc, Domain.Product product)
        {
            dc = dc ?? Conn.GetContext();
            var dbProduct = dc.Products.Where(p => p.ProductID == product.ID).SingleOrDefault();
            if (dbProduct == null) return;
            dc.Products.Attach(dbProduct, true);
            dc.Products.DeleteOnSubmit(dbProduct);
            dc.SubmitChanges();
        }

        #endregion
    }
}