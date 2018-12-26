using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;

namespace AppName.Web.App_Start.AutofacModules
{
    public class ControlerModule : Module
    {
        protected  override  void Load (ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(ControlerModule).Assembly);
        }
    }
}