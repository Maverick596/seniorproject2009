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

        public ManageProductPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IManageProduct view, bool isPostBack)
        {
            _view = view;

            // do some security
            if (_webContext.IsAdmin)
                return;

            if(_webContext.ProductId > 0 && !isPostBack)
            {
                _view.LoadData(Product.Find((_webContext.ProductId)));
            }
        }

        public void SaveProduct(Product product)
        {
            // Check the data
            product.Save();

        }
    }
}