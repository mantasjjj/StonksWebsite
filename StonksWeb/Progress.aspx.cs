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
                chartPlanned.Series["Monthly Expenses"].Points.AddXY("Housing", FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Housing).Value);
                chartPlanned.Series["Monthly Expenses"].Points.AddXY("Groceries", FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Groceries).Value);
                chartPlanned.Series["Monthly Expenses"].Points.AddXY("Transport", FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Transportation).Value);
                chartPlanned.Series["Monthly Expenses"].Points.AddXY("Entertainment", FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Entertainment).Value);
                chartPlanned.Series["Monthly Expenses"].Points.AddXY("Health", FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Health).Value);
                chartPlanned.Series["Monthly Expenses"].Points.AddXY("Shopping", FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Shopping).Value);
                chartPlanned.Series["Monthly Expenses"].Points.AddXY("Utilities", FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Utilities).Value);
                chartPlanned.Series["Monthly Expenses"].Points.AddXY("Other", FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Other).Value);
        }
    }
}