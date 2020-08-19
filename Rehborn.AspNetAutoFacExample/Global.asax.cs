using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;
using Rehborn.AspNetAutoFacExample.Domain;
using Rehborn.AspNetAutoFacExample.Infrastructure;
using LogLevel = NLog.LogLevel;

namespace Rehborn.AspNetAutoFacExample
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var nlogConfig = new LoggingConfiguration();
            var traceTarget = new TraceTarget("trace")
            {
                Layout = "${date}|${level:uppercase=true}|${message} ${exception}|${logger}|${all-event-properties}"
            };
            nlogConfig.AddTarget(traceTarget);
            nlogConfig.AddRuleForAllLevels(traceTarget, "*");
            var fileTarget = new FileTarget("file")
            {
                Layout = "${date}|${level:uppercase=true}|${message} ${exception}|${logger}|${all-event-properties}",
                FileName = Path.Combine(Assembly.GetExecutingAssembly().Location, "nlogoutput.log")
            };
            nlogConfig.AddTarget(fileTarget);
            nlogConfig.AddRuleForAllLevels(fileTarget, "*");

            var consoleTarget = new ConsoleTarget
            {
                Name = "console",
                Layout = "${longdate}|${level:uppercase=true}|${logger}|${message}",
            };
            nlogConfig.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget, "*");

            LogManager.Configuration = nlogConfig;

            var services = new ServiceCollection();
            services.AddLogging(options => options.AddNLog(nlogConfig));

            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(WebApiApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();


            builder.RegisterType<ValuesRepository>()
                .As<IValuesRepository>()
                .InstancePerLifetimeScope();

            // OPTIONAL: Enable action method parameter injection (RARE).
            //builder.InjectActionInvoker();

            builder.Populate(services);


            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
