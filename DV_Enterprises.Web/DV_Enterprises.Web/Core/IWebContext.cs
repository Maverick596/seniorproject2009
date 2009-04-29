using System;
using DV_Enterprises.Web.Core.Domain;
using StructureMap;

namespace DV_Enterprises.Web.Core
{
    [PluginFamily("Default")]
    public interface IWebContext
    {
        //string SearchText { get; }

        Guid AccoutID { get; }
        bool LoggedIn { get; set;}
        Account CurrentUser { get; set;}
        string UsernameToVerify { get; }

    }
}