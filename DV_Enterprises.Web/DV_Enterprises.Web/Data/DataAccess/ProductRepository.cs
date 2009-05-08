//using System;
//using System.Collections.Generic;
//using System.Linq;
//using DV_Enterprises.Web.Data.DataAccess;
//using DV_Enterprises.Web.DataAccess.Interface;
//using DV_Enterprises.Web.Domain;
//using StructureMap;

//namespace DV_Enterprises.Web.DataAccess.Impl
//{
//    [Pluggable("Default")]
//    public class ProductRepository : IProductRepository
//    {
//        private Connection _conn;

//        public ProductRepository()
//        {
//            _conn =  new Connection();
//        }

//        public List<Product> GetProducts()
//        {
//            List<Product> result;
//            using (var dc = _conn.GetContext())
//            {
//                IEnumerable<Product> products = dc.Products;
//                result = products.ToList();
//            }
//            return result;
//        }

//        public Product GetProduct(int productId)
//        {
//            var result = new Product();
//            using (var dc = _conn.GetContext())
//            {
//                result = dc.Products.Where(p => p.ProductID == productId).SingleOrDefault();
//            }
//            return result;
//        }

//        public int SaveProduct(Product product)
//        {
//            using (var dc = _conn.GetContext())
//            {
//                var dbProduct = dc.Products.Where(p => p.ProductID == product.ProductID).SingleOrDefault();
//                var isNew = false;
//                if (dbProduct == null)
//                {
//                    dbProduct = new Product();
//                    isNew = true;
//                }
//                dbProduct.Name = product.Name;
//                dbProduct.Description = product.Description;
//                dbProduct.Price = product.Price;
//                dbProduct.Active = product.Active;
//                dbProduct.UpdateDate = DateTime.Now;
//                if (isNew)
//                    dc.Products.InsertOnSubmit(dbProduct);
//                dc.SubmitChanges();
//                product.ProductID = dbProduct.ProductID;
//            }
//            return product.ProductID;

//        }

//        public void DeleteProduct(Product product)
//        {
//            using (var dc = _conn.GetContext())
//            {
//                dc.Products.Attach(product, true);
//                dc.Products.DeleteOnSubmit(product);
//                dc.SubmitChanges();
//            }
//        }

//        public void DeleteProduct(int productId)
//        {
//            using (var dc = _conn.GetContext())
//            {
//                var product = dc.Products.Where(p => p.ProductID == productId).FirstOrDefault();
//                dc.Products.DeleteOnSubmit(product);
//                dc.SubmitChanges();
//            }
//        }
//    }
//}