using System;
using DV_Enterprises.Web.DataAccess.Interface;
using DV_Enterprises.Web.Presenter.Products.Interface;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Presenter.Products
{
    public class ViewProductPresenter
    {
        private IViewProduct _view;
        private IProductRepository _productRepository;
        private IProductService _productService;
        private IWebContext _webContext;

        public ViewProductPresenter()
        {
            _productRepository = ObjectFactory.GetInstance<IProductRepository>();
            _productService = ObjectFactory.GetInstance<IProductService>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IViewProduct view, bool isPostBack)
        {
            _view = view;
            if (!isPostBack && _webContext.ProductId > 0)
                LoadData();
        }

        public void LoadData()
        {
            var product = _productRepository.GetProduct(_webContext.ProductId);
            _view.LoadData(product);

            // TODO: Add auth and extra atuss
        }
    }
}