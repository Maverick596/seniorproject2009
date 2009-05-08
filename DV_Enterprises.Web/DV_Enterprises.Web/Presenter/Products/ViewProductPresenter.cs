using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Presenter.Products.Interface;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Presenter.Products
{
    public class ViewProductPresenter
    {
        private IViewProduct _view;
        private readonly IWebContext _webContext;

        public ViewProductPresenter()
        {
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
            _view.LoadData(Product.Find(_webContext.ProductId));

            // TODO: Add auth and extra atuss
        }
    }
}