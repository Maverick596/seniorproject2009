using System.Linq;
using DV_Enterprises.Web.Data.Domain;
using DV_Enterprises.Web.Presenter.Greenhouses.Interface;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Presenter.Greenhouses
{
    public class ViewGreenhousePresenter
    {
        private IViewGreenhouse _view;
        private readonly IWebContext _webContext;

        public ViewGreenhousePresenter()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(IViewGreenhouse view, bool isPostBack)
        {
            _view = view;
            if (isPostBack || _webContext.GreenhouseId <= 0) return;
            var greenhouse = Greenhouse.Find(_webContext.GreenhouseId);
            _view.LoadData(greenhouse);
            _view.LoadLocation(greenhouse.Address);
            _view.LoadSection(greenhouse.Sections.ToList());
        }
    }
}