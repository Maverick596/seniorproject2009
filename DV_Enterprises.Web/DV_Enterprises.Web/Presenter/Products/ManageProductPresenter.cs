using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Presenter.Products.Interface;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Presenter.Products
{
    public class ManageProductPresenter
    {
        private IManageProduct _view;
        private readonly IWebContext _webContext;
        private readonly IRedirector _redirector;

        public ManageProductPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }

        public void Init(IManageProduct view, bool isPostBack)
        {
            _view = view;

            if (!_webContext.IsAdmin)
                _redirector.GoToHomePage();

            if(_webContext.ProductId > 0 && !isPostBack)
            {
                _view.LoadData(Product.Find((_webContext.ProductId)));
            }
        }

        public void SaveProduct(Product product)
        {
            product.Save();
        }
    }
}