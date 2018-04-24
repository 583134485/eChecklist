using Gdc.Apps.Echecklist.Providers.Implement;
using Gdc.Apps.Echecklist.Providers.Interface;
using Gdc.Apps.Echecklist.Repositories.Interface;
using Gdc.Apps.Echecklist.Repositories.Implement;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
namespace Gdc.Apps.Echecklist.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IInstanceService, InstanceService>(Lifestyle.Transient);
            container.Register<ITemplateService, TemplateService>(Lifestyle.Transient);
            container.Register<IStepService, StepService>(Lifestyle.Transient);
            container.Register<IWorkflowService, WorkflowService>(Lifestyle.Transient);
            container.Register<IWtemplateService, WtemplateService>(Lifestyle.Transient);

            container.Register<IInstanceRepositories, InstanceRepositories>(Lifestyle.Singleton);
            container.Register<ITemplateRepositories, TemplateRepositories>(Lifestyle.Singleton);
            container.Register<IStepRepositories, StepRepositories>(Lifestyle.Singleton);
            container.Register<IWorkflowRepositories, WorkflowRepositories>(Lifestyle.Singleton);
            container.Register<IWTemplateRepositories, WTemplateRepositories>(Lifestyle.Transient);
            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            // 使api返回为json 
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}
