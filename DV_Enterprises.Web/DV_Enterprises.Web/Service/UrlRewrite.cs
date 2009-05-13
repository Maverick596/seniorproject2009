using System;
using System.Web;
using DV_Enterprises.Web.Service.Interface;
using StructureMap;

namespace DV_Enterprises.Web.Service
{
    public class UrlRewrite : IHttpModule
    {
        private IWebContext _webContext;

        public UrlRewrite()
        {
            _webContext = ObjectFactory.GetInstance<IWebContext>();
        }

        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += this.ApplicationOnAfterRequest;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void ApplicationOnAfterRequest(object source, EventArgs e)
        {
            var application = (HttpApplication) source;
            var context = application.Context;

            string[] extensionsToExclude = { ".axd", ".jpg", ".gif", ".png", ".xml", ".config", ".css", ".js", ".htm", ".html" };
            foreach (var s in extensionsToExclude)
            {
                if (application.Request.PhysicalPath.ToLower().Contains(s)) return;
            }

            if (!System.IO.File.Exists(application.Request.PhysicalPath))
            {
                #region products

                if (application.Request.PhysicalPath.ToLower().Contains("products"))
                {
                    var arr = application.Request.PhysicalPath.ToLower().Split('\\');
                    sting productPage
                }

                #endregion
            }
        }
    }
}