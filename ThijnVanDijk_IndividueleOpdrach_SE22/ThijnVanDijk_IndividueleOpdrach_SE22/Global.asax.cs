using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("ChannelPage",
                "channel/{ChannelName}",
                "~/ChannelPage.aspx", true,
                new RouteValueDictionary { 
                    {"ChannelName" , "[a-z]{1-12}"} });

            routes.MapPageRoute("VideoPage",
                "video/{VideoID}",
                "~/VideoPage.aspx", true,
                new RouteValueDictionary {
                    {"VideoID", @"/d {1-10}"} });
        }
    }
}