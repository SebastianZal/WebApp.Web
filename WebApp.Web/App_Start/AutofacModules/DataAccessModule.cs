using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.DataAccess;

namespace WebApp.Web.App_Start.AutofacModules
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Repository<>).Assembly).AsImplementedInterfaces();

            builder.RegisterType<DataContext>().InstancePerRequest();
        }
    }
}