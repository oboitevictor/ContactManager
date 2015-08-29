<<<<<<< HEAD
﻿using Contact.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Contact.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
<<<<<<< HEAD
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            NinjectContainer.RegisterModules(NinjectModules.Modules);
=======
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
>>>>>>> 79ef9d25f4e49f2ae4700667da71eb8041f0f4cf
        }
    }
}
