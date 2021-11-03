using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SampleLegacy
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ECommerceDataHazelCast.Instance.InitializeAsync().Wait();
        }

        void Application_End(object sender, EventArgs e)
        {
            ECommerceDataHazelCast.Instance.ShutdownAsync().Wait();
        }
    }
}