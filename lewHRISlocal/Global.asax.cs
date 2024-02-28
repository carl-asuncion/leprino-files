using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace lewHRISlocal
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //Added 1.10.2024 --- Unauthorized custom 401
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            if (Response.StatusCode == 401)
            {
                Response.ClearContent();
                Response.WriteFile("~/UnauthorizedAccess.aspx");
                Response.ContentType = "text/html";
            }
        }
    }
}