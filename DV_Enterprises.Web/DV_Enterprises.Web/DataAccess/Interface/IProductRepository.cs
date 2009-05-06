using System;
using System.Collections.Generic;
using DV_Enterprises.Web.Domain;
using StructureMap;

namespace DV_Enterprises.Web.DataAccess.Interface
{
    [PluginFamily("Default")]
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProduct(int productId);
        Int32 SaveProduct(Product product);
        void DelestProduct(Product product);
        void DelestProduct(int productId);
    }
}