using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StonksWeb
{
    public partial class Progress : Page
    {
        public Color Transparent { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FillChart();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            Income.InnerText = FinancialPlanController.ActivePlan.Income.ToString("€#.#");
            Spendings.InnerText = FinancialPlanController.ActivePlan.GetSpendings().ToString("€#.#");
        }

            private void FillChart()
        {
            chartPlanned.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
            chartPlanned.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Transparent;
            chartPlanned.ChartAreas[0].AxisX.LineColor = Color.White;
            chartPlanned.ChartAreas[0].AxisY.LineColor = Color.White;

            chartPlanned.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            chartPlanned.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
            chartPlanned.ChartAreas[0].BackColor = Transparent;

            //ExpensesChart 
            foreach (Expense expense in FinancialPlanController.ActivePlan.Expenses)
            {

                if (FinancialPlanController.ActivePlan.GetExpense(expense.Type) != null)
                {
                    chartPlanned.Series["Monthly Expenses"].Points
                        .AddXY(FinancialPlanController.ActivePlan.GetExpense(expense.Type).ToString(),
                        FinancialPlanController.ActivePlan.GetExpense(expense.Type).Value);
                }
            }
        }
    }
}