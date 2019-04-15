using Autofac;
using Autofac.Integration.WebApi;
using ConsultoriaLaSante.Services;
using ConsultoriaLaSante.Services.Interfaces;
using System;
using System.Reflection;
using System.Web.Http;

namespace ConsultoriaLaSante.Api.App_Start
{
    public class AutoFacConfigure
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}