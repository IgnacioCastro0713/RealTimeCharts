using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RealTimeCharts.Web.Startup))]

namespace RealTimeCharts.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}