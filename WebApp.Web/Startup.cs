﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApp.Web.Startup))]
namespace WebApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
