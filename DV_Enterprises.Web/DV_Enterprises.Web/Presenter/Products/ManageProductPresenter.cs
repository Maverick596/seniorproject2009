using DV_Enterprises.Web.DataAccess.Interface;
using DV_Enterprises.Web.Domain;
using DV_Enterprises.Web.Presenter.Products.Interface;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Presenter.Products
{
    public class ManageProductPresenter
    {
        private IManageProduct _view;
        private IProductRepository _productRepository;
        private IProductService _productService;
        private IWebContext _webContext;

        public ManageProductPresenter()
        {
            _productRepository = ObjectFactory.GetInstance<IProductRepository>();
            _productService = ObjectFactory.GetInstance<IProductService>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IManageProduct view, bool isPostBack)
        {
            _view = view;

            // do some security

            if(_webContext.ProductId > 0 && !isPostBack)
            {
                _view.LoadData(_productRepository.GetProduct(_webContext.ProductId));
            }
        }

        public void SaveProduct(Product product)
        {
            // Check the data
            product.ProductID = _productService.SaveProduct(product);

        }
    }
}