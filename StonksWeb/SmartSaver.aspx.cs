using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace StonksWeb
{
    public struct ExpenseMap
    {
        public readonly ExpenseType Type;
        public readonly TextBox Text;
        public readonly HtmlInputGenericControl Slider;

        public ExpenseMap(ExpenseType type, TextBox text, HtmlInputGenericControl slider)
        {
            Type = type;
            Text = text;
            Slider = slider;
        }
    }

    public partial class SmartSaver : Page
    {
        private static List<ExpenseMap> expenseMap;
        private static bool DeadlineReachedVisible = false;
        private static List<String> ReachedGoalNames = new List<String>();

        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (ExpenseMap map in expenseMap)
            {
                var expense = FinancialPlanController.ActivePlan.GetExpense(map.Type);
                if (expense != null)
                {
                    map.Slider.Value = expense.Value.ToString();
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            expenseMap = new List<ExpenseMap>()
            {
                new ExpenseMap(ExpenseType.Housing, TextBoxHousingActual, HousingSlider),
                new ExpenseMap(ExpenseType.Groceries, TextBoxGroceriesActual, GroceriesSlider),
                new ExpenseMap(ExpenseType.Transportation, TextBoxTransportationActual, TransportationSlider),
                new ExpenseMap(ExpenseType.Entertainment, TextBoxEntertainmentActual, EntertainmentSlider),
                new ExpenseMap(ExpenseType.Health, TextBoxHealthActual, HealthSlider),
                new ExpenseMap(ExpenseType.Shopping, TextBoxShoppingActual, ShoppingSlider),
                new ExpenseMap(ExpenseType.Utilities, TextBoxUtilitiesActual, UtilitiesSlider),
                new ExpenseMap(ExpenseType.Other, TextBoxOtherActual, OtherSlider)
            };

            Double savings = FinancialPlanController.ActivePlan.Income - FinancialPlanController.ActivePlan.GetSpendings();
            Income.InnerText = FinancialPlanController.ActivePlan.Income.ToString("€#.#");
            Spendings.InnerText = FinancialPlanController.ActivePlan.GetSpendings().ToString("€#.#");
            Savings.InnerText = savings.ToString("€#.#");
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            foreach (ExpenseMap map in expenseMap)
            {
                var expense = FinancialPlanController.ActivePlan.GetExpense(map.Type);
                if (expense != null)
                {
                    map.Text.Text = expense.Value.ToString();
                }
            }
        }

        protected void SetRangeSlider()
        {
        }

        [System.Web.Services.WebMethod]
        public static void UpdateValue()
        {
            HtmlInputGenericControl slider = new HtmlInputGenericControl();
            FinancialPlanController.ActivePlan.ModifyExpensePlannedValue(expenseMap.Where(x => x.Slider == slider).FirstOrDefault().Type, Double.Parse(slider.Value));
            expenseMap.Where(x => x.Slider == slider).FirstOrDefault().Text.Text = slider.Value;
        }

        public static void OnDeadlineReached(object source, EventArgs args)
        {
            DeadlineReachedVisible = true;
            ReachedGoalNames.Add(((FinancialGoal)source).Name);
        }
    }
}