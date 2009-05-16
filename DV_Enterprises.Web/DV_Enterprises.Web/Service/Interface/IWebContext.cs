using System;
using System.Web.Security;
using StructureMap;

namespace DV_Enterprises.Web.Service.Interface
{
    [PluginFamily("Default")]
    public interface IWebContext
    {
        MembershipUser User { get; }
        bool IsAdmin();
        Int32 ProductId { get; }
        Int32 GreenhouseId { get; }
    }
}