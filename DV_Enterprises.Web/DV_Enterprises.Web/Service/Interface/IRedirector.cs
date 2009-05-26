using StructureMap;

namespace DV_Enterprises.Web.Service.Interface
{
    [PluginFamily("Default")]
    public interface IRedirector
    {
        void GoToProducts();
        void GoToViewProduct(int productId);
        void GoToManageProduct(int productId);
        void GoToManageProduct();

        void GoToGreenhouses();
        void GoToViewGreenhouse(int productId);
        void GoToManageGreenhouse(int productId);
        void GoToManageGreenhouse();

        void GoToHomePage();
        void GoToErrorPage();
        void GoToSignupPage();
    }
}