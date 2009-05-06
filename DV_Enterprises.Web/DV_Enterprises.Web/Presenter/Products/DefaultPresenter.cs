using DV_Enterprises.Web.DataAccess.Interface;
using DV_Enterprises.Web.Presenter.Products.Interface;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Presenter.Products
{
    public class DefaultPresenter
    {
        private IDefault _view;
        private IProductRepository _productRepository;
        private IWebContext _webContext;

        public DefaultPresenter()
        {
            _productRepository = ObjectFactory.GetInstance<IProductRepository>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IDefault view)
        {
            _view = view;
            _view.LoadData(_productRepository.GetProducts());
        }
    }
}