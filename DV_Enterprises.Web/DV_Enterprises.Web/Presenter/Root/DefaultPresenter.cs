using DV_Enterprises.Web.Presenter.Root.Interface;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Presenter.Root
{
    public class DefaultPresenter
    {
        private IDefault _view;
        private IWebContext _webContext;

        public DefaultPresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IDefault view)
        {
            _view = view;
        }
    }
}