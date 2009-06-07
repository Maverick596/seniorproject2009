using System;
using System.Linq;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Presenter.Products.Interface;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Presenter.Products
{
    public class DefaultPresenter
    {
        private IDefault _view;
        private IWebContext _webContext;
        private readonly IRedirector _redirector;

        public DefaultPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            _redirector = ObjectFactory.GetInstance<IRedirector>();
        }

        public void Init(IDefault view)
        {
            _view = view;
            _view.LoadData(Product.All().ToList());
        }

        public void EditProduct(int productId)
        {
            _redirector.GoToManageProduct(productId);
        }

        public void EditProduct()
        {
            _redirector.GoToManageProduct();
        }
    }
}