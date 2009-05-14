using System;
using System.Collections.Generic;
using System.Linq;
using DV_Enterprises.Web.Data.DataAccess.SqlRepository;
using DV_Enterprises.Web.Data.Domain.Abstract;
using DV_Enterprises.Web.Data.Domain.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Data.Domain
{
    [Pluggable("Default")]
    public class Product : DomainModel, IProduct
    {
        #region Static properties

        #endregion

        #region Instance properties

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public DateTime? UpdateDate { get; private set; }
        public string Path { get; set; }

        #endregion

        # region Static Methods

        /// <summary>
        /// Find all Product's
        /// </summary>
        /// <returns>return an IQueryable collection of Product</returns>
        public static IList<Product> All()
        {
            return All(null);
        }

        /// <summary>
        /// Find all Product's
        /// </summary>
        /// <param name="dc"></param>
        /// <returns>return an IQueryable collection of Product</returns>
        public static IList<Product> All(DataContext dc)
        {
            dc = dc ?? Conn.GetContext();
            var r = from p in dc.Products
                    select new Product
                               {
                                   ID = p.ProductID,
                                   Name = p.Name,
                                   Description = p.Description,
                                   Price = p.Price,
                                   Active = p.Active,
                                   UpdateDate = p.UpdateDate,
                                   Path = p.Path
                               };
            return r.ToList();
        }

        /// <summary>
        /// Find an Product by it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a Product</returns>
        public static Product Find(int id)
        {
            return Find(null, id);
        }

        /// <summary>
        /// Find an Product by it's id.
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="id"></param>
        /// <returns>returns a Product</returns>
        public static Product Find(DataContext dc, int id)
        {
            return All(dc).Where(p => p.ID == id).SingleOrDefault();
        }

        /// <summary>
        /// Save a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>returns the id of the saved product</returns>
        public static int Save(Product product)
        {
            return Save(null, product);
        }

        /// <summary>
        /// Save a Product
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="product"></param>
        /// <returns>returns the id of the saved product</returns>
        public static int Save(DataContext dc, Product product)
        {
            dc = dc ?? Conn.GetContext();
            var dbProduct = dc.Products.Where(p => p.ProductID == product.ID).SingleOrDefault();
            var isNew = false;
            if (dbProduct == null)
            {
                dbProduct = new DataAccess.SqlRepository.Product();
                isNew = true;
            }

            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.Active = product.Active;
            dbProduct.UpdateDate = DateTime.Now;
            dbProduct.Path = product.Path;

            if (isNew)
                dc.Products.InsertOnSubmit(dbProduct);
            dc.SubmitChanges();
            return dbProduct.ProductID;
        }

        /// <summary>
        /// Delete a single product
        /// </summary>
        /// <param name="product"></param>
        public static void Delete(Product product)
        {
            Delete(null, product);
        }

        /// <summary>
        /// Delete a single product
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="product"></param>
        public static void Delete(DataContext dc, Product product)
        {
            dc = dc ?? Conn.GetContext();
            var dbProduct = dc.Products.Where(p => p.ProductID == product.ID).SingleOrDefault();
            if (dbProduct == null) return;
            dc.Products.Attach(dbProduct, true);
            dc.Products.DeleteOnSubmit(dbProduct);
            dc.SubmitChanges();
        }


        #endregion

        #region Instance Methods

        /// <summary>
        /// Save Product
        /// </summary>
        /// <returns>returns the id of the saved product</returns>
        public int Save()
        {
            return Save(this);
        }

        /// <summary>
        /// Save Product
        /// </summary>
        /// <returns>returns the id of the saved product</returns>
        public int Save(DataContext dc)
        {
            return Save(dc, this);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        public void Delete()
        {
            Delete(this);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        public void Delete(DataContext dc)
        {
            Delete(dc, this);
        }

        #endregion
    }
}