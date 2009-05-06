using System;
using DV_Enterprises.Web.DataAccess.Interface;
using DV_Enterprises.Web.Domain;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Service.Impl
{
    [Pluggable("Default")]
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = ObjectFactory.GetInstance<IProductRepository>();
        }

        public int SaveProduct(Product product)
        {
            var result = 0;
            if(product.ProductID > 0)
            {
                result = _productRepository.SaveProduct(product);
            }
            else
            {
                result = _productRepository.SaveProduct(product);

                // setup initial relations
            }
            return result;
        }
    }
}