using System;
using System.Linq;
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

        public DefaultPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IDefault view)
        {
            _view = view;
            if (_webContext.IsAdmin)
            {
                _view.LoadData(Greenhouse.All());
            }
            else
            {
                _view.LoadData(Greenhouse.All().Where(g => g.UserIDs.Contains(new Guid(_webContext.User.ProviderUserKey.ToString()))).ToList());    
            }
        }
    }
}