using Autofac;
using Autofac.Integration.WebApi;
using Autofac.Integration.Mvc;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Reflection;
using CovalmorPertamina.Web.Container;

namespace CovalmorPertamina.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ContainerBuilder builder = ContainerConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            HttpConfiguration config = GlobalConfiguration.Configuration;

            /*
             * description : Ignore point back to object
             */
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


            #region register web api
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());  
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterWebApiModelBinderProvider();
            #endregion

            #region register web mvc
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();
            #endregion

            #region resolve
            IContainer container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
    }
}
