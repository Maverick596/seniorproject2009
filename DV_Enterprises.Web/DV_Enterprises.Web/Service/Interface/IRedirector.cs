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

        void GoToHomePage();
        void GoToErrorPage();
        void GoToSignupPage();
    }
}