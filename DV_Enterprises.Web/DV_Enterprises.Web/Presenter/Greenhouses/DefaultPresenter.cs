using DV_Enterprises.Web.DataAccess.Interface;
using DV_Enterprises.Web.Presenter.Greenhouses.Interface;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Presenter.Greenhouses
{
    public class DefaultPresenter
    {
        private IDefault _view;
        private IGreenhouseRepository _greenhouseRepository;
        private IWebContext _webContext;

        public DefaultPresenter()
        {
            _greenhouseRepository = ObjectFactory.GetInstance<IGreenhouseRepository>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IDefault view)
        {
            _view = view;
            _view.LoadData(_greenhouseRepository.GetLatestGreenhouses());
        }
    }
}