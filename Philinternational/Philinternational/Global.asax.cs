﻿using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace Philinternational
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
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
            legendaStato legends = new legendaStato();
            legends.PopulateAvailableLegendaStato();
            Session.Add("legendaStato", legends);
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }

        void RegisterRoutes(RouteCollection routes) {
            routes.MapPageRoute("ElencoLotto", "{capitolo}/{idpar}/{paragrafo}", "~/Lotti/elencoLotto.aspx");
            routes.MapPageRoute("InsideElencoLotto", "{capitolo}/{idpar}/{paragrafo}/{page}", "~/Lotti/elencoLotto.aspx");
            routes.MapPageRoute("OffertaLotto", "{capitolo}/{idpar}/{paragrafo}/lotto/{idlotto}", "~/Lotti/offerta.aspx");
            //routes.MapPageRoute("All Product", "Products/All", "~/AllProduct.aspx");
            //routes.MapPageRoute("Selected Product", "Products/Selected/{name}", "~/ParticularProduct.aspx");
        }


    }
}
