using System;
using StructureMap;

namespace DV_Enterprises.Web.Service.Interface
{
    [PluginFamily("Default")]
    public interface IWebContext
    {
        bool IsAdmin(string username);
        Int32 ProductId { get; }
        Int32 GreenhouseId { get; }
    }
}