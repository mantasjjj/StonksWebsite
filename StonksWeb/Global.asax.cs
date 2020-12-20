using System;
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
        public static string saveFilePath = "D:\\financialPlan.bin";

        void Application_Start(object sender, EventArgs e)
        {
            try
            {
                FinancialPlanController.FinancialPlans = DBConnector.GetFinancialPlanList(1); // default user id
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