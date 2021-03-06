﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace StonksWeb
{
    public class Global : HttpApplication
    {
        public static int defaultUserId = 1;

        void Application_Start(object sender, EventArgs e)
        {
            FinancialPlanController.ActiveUser = DBConnector.GetUser(defaultUserId);
            try
            {
                FinancialPlanController.FinancialPlans = DBConnector.GetFinancialPlanList(defaultUserId);
                FinancialPlanController.UpdateActive();
            }
            catch
            {
                FinancialPlanController.AddNewPlan();
            }

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}