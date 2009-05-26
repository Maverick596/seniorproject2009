using System;
using System.Linq;
using System.Web.Security;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Presenter.Greenhouses.Interface;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Presenter.Greenhouses
{
    public class DefaultPresenter
    {
        private IDefault _view;
        private readonly IWebContext _webContext;
        public readonly IRedirector Redirector;

        public DefaultPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
            Redirector = ObjectFactory.GetInstance<IRedirector>();
        }

        public void Init(IDefault view)
        {
            _view = view;
            if (_view.User.IsInRole("administrator"))
            {
                _view.LoadData(Greenhouse.All());
            }
            else
            {
                _view.LoadData(Greenhouse.All().Where(g => g.UserIDs.Contains(new Guid(Membership.GetUser(_view.User.Identity.Name).ProviderUserKey.ToString()))).ToList());    
            }
        }
    }
}