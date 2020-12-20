using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace StonksWeb
{
    public struct ExpenseMap
    {
        public readonly ExpenseType Type;
        public readonly TextBox TextActual;
        public readonly TextBox TextPlanned;
        public readonly HtmlInputGenericControl Slider;

        public ExpenseMap(ExpenseType type, TextBox textActual, TextBox textPlanned, HtmlInputGenericControl slider)
        {
            Type = type;
            TextActual = textActual;
            TextPlanned = textPlanned;
            Slider = slider;
        }
    }

    public class FinancialGoalInfo
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public double Funds { get; set; }
        public string Deadline { get; set; }
        public string TimeToDeadline { get; set; }

        public FinancialGoalInfo(string name, double value, double funds, string deadline, string timeToDeadline )
        {
            Name = name;
            Value = value;
            Funds = funds;
            Deadline = deadline;
            TimeToDeadline = timeToDeadline;
        }
    }

    public static class MessageBox
    {
        public static void Show(this Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + Message + "');</script>"
            );
        }
    }

    public partial class SmartSaver : Page
    {
        private static List<ExpenseMap> expenseMap;
        private static bool DeadlineReachedVisible = false;
        private static List<String> ReachedGoalNames = new List<String>();

        public IEnumerable rptCustomer_GetData()
        {
            var goals = new List<FinancialGoalInfo>();
            var timeUnit = FinancialGoal.UseYears ? " years" : " months";
            foreach (FinancialGoal goal in FinancialPlanController.ActivePlan.FinancialGoals)
            {
                goals.Add(new FinancialGoalInfo(goal.Name, goal.Value, goal.AllocatedFunds, goal.GetDeadlineFormatted(), (goal.TimeToDeadline < 0 
                    ? "∞" 
                    : Math.Round(goal.TimeToDeadline, 1).ToString())
                    + timeUnit));
            }
            return goals;
        }

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
                new ExpenseMap(ExpenseType.Housing, TextBoxHousingActual, TextBoxHousing, HousingSlider),
                new ExpenseMap(ExpenseType.Groceries, TextBoxGroceriesActual, TextBoxGroceries, GroceriesSlider),
                new ExpenseMap(ExpenseType.Transportation, TextBoxTransportationActual, TextBoxTransportation, TransportationSlider),
                new ExpenseMap(ExpenseType.Entertainment, TextBoxEntertainmentActual, TextBoxEntertainment, EntertainmentSlider),
                new ExpenseMap(ExpenseType.Health, TextBoxHealthActual, TextBoxHealth, HealthSlider),
                new ExpenseMap(ExpenseType.Shopping, TextBoxShoppingActual, TextBoxShopping, ShoppingSlider),
                new ExpenseMap(ExpenseType.Utilities, TextBoxUtilitiesActual, TextBoxUtilities, UtilitiesSlider),
                new ExpenseMap(ExpenseType.Other, TextBoxOtherActual, TextBoxOther, OtherSlider)
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
                    map.TextActual.Text = expense.Value.ToString();
                    map.TextPlanned.Text = expense.PlannedValue.ToString();
                }
            }
            double maxPlanned = FinancialPlanController.ActivePlan.GetMaxExpense() * 1.2;
            foreach (ExpenseMap map in expenseMap)
            {
                var expense = FinancialPlanController.ActivePlan.GetExpense(map.Type);
                if (expense != null)
                {
                    map.Slider.Attributes.Add("max", maxPlanned.ToString());
                    map.Slider.Value = expense.PlannedValue.ToString();
                }
            }
        }

        protected void SetGoalValue(object source, EventArgs args)
        {
            for (int i = 0; i < RepeaterGoals.Items.Count; i++)
            {
                HtmlInputGenericControl currentSlider = (HtmlInputGenericControl)RepeaterGoals.Items[i].FindControl("Slider");
                TextBox currentTextBox = (TextBox)RepeaterGoals.Items[i].FindControl("TextBoxValue");

                FinancialPlanController.ActivePlan.FinancialGoals.ElementAt(i).SetDeadlineByFunds(Double.Parse(currentSlider.Value));
                DBConnector.SaveFinancialPlans(FinancialPlanController.FinancialPlans, 1); // default user id
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        protected void DeleteGoal(object sender, EventArgs args)
        {
            if (FinancialPlanController.ActivePlan.FinancialGoals.Count < 1 || RepeaterGoals.Items.Count < 1)
                return;

            Button clickedButton = (Button)sender;
            int index = 0;
            for (; index < RepeaterGoals.Items.Count; index++)
            {
                Button currentButton = (Button)RepeaterGoals.Items[index].FindControl("ButtonDeleteGoal");
                if (clickedButton == currentButton)
                    break;
            }
            FinancialPlanController.ActivePlan.FinancialGoals.RemoveAt(index);
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        public static void OnDeadlineReached(object sender, EventArgs args)
        {
            DeadlineReachedVisible = true;
            ReachedGoalNames.Add(((FinancialGoal)sender).Name);
        }

        protected void SavePlan(object sender, EventArgs e)
        {
            foreach (ExpenseMap map in expenseMap)
            {
                if (Double.TryParse(map.TextPlanned.Text, out double value))
                {
                    FinancialPlanController.ActivePlan.ModifyExpensePlannedValue(map.Type, value);
                }
            }
            DBConnector.SaveFinancialPlans(FinancialPlanController.FinancialPlans, 1); // default user id
        }

        protected void AddGoal(object sender, EventArgs e)
        {
            if (Double.TryParse(TextBoxGoalPrice.Text, out double value) && TextBoxGoalName.Text != "")
            {
                FinancialPlanController.ActivePlan.AddFinancialGoal(new FinancialGoal(value, TextBoxGoalName.Text));
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                MessageBox.Show(this, "Provided goal infomation invalid.");
            }
        }
    }
}