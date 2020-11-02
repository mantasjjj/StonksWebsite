using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stonks
{
    static class FinancialPlanController
    {
        public static List<FinancialPlan> FinancialPlans { get; set; } = new List<FinancialPlan>();
        public static FinancialPlan ActivePlan { get; set; }

        public static void UpdateActive()
        {
            ActivePlan = FinancialPlans.Last();
        }

        public static void AddNewPlan (bool copyPrevious = false)
        {
            if (copyPrevious)
            {
                FinancialPlans.Add((FinancialPlan)(FinancialPlans.Count > 1 ? FinancialPlans.ElementAt(FinancialPlans.Count - 2).Clone() : new FinancialPlan())); UpdateActive();
                UpdateActive();
            }
            else
            {
                FinancialPlans.Add(new FinancialPlan());
                UpdateActive();
            }
        }
    }
}
