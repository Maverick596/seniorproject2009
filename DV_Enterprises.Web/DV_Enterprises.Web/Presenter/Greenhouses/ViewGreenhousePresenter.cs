using DV_Enterprises.Web.DataAccess.Interface;
using DV_Enterprises.Web.Presenter.Greenhouses.Interface;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Presenter.Greenhouses
{
    public class ViewGreenhousePresenter
    {
        private IViewGreenhouse _view;
        private IGreenhouseRepository _greenhouseRepository;
        //private IGreenhouseService _greenhouseService;
        private ILocationRepository _locationRepository;
        private ISectionRepository _sectionrepository;
        private IWebContext _webContext;

        public ViewGreenhousePresenter()
        {
            _greenhouseRepository = ObjectFactory.GetInstance<IGreenhouseRepository>();
            //_greenhouseService = ObjectFactory.GetInstance<IGreenhouseService>();
            _locationRepository = ObjectFactory.GetInstance<ILocationRepository>();
            _sectionrepository = ObjectFactory.GetInstance<ISectionRepository>();
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IViewGreenhouse view, bool isPostBack)
        {
            _view = view;
            if (isPostBack || _webContext.GreenhouseId <= 0) return;
            var greenhouse = _greenhouseRepository.GetGreenhouse(_webContext.GreenhouseId);
            _view.LoadData(greenhouse);
            _view.LoadLocation(_locationRepository.GetLocation(greenhouse));
            _view.LoadSection(_sectionrepository.GetSections(greenhouse));
        }
    }
}