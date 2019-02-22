using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pet.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


#if !DEBUG
            System.Data.Entity.Database.SetInitializer<Database.PetDataContext>(new System.Data.Entity.MigrateDatabaseToLatestVersion<Database.PetDataContext, Database.Migrations.Configuration>());

            Database.PetDataContext authorsDBContext = new Database.PetDataContext();
            authorsDBContext.Database.Initialize(true);

            System.Data.Entity.Database.SetInitializer<Database.PetDataContext>(null);
#endif
        }
    }
}