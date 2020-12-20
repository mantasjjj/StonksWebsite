using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StonksWeb
{
    public partial class Finances : Page
    {
        Dictionary<ExpenseType, TextBox> boxTypeList;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            boxTypeList = new Dictionary<ExpenseType, TextBox>()
            {
                { ExpenseType.Housing, TextBoxHousing },
                { ExpenseType.Groceries, TextBoxGroceries },
                { ExpenseType.Transportation, TextBoxTransportation },
                { ExpenseType.Entertainment, TextBoxEntertainment },
                { ExpenseType.Health, TextBoxHealth },
                { ExpenseType.Shopping, TextBoxShopping },
                { ExpenseType.Utilities, TextBoxUtilities },
                { ExpenseType.Other, TextBoxOther }
            };
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            TextBoxIncome.Text = FinancialPlanController.ActivePlan.Income.ToString();
            foreach (KeyValuePair<ExpenseType, TextBox> boxType in boxTypeList)
            {
                var expense = FinancialPlanController.ActivePlan.GetExpense(boxType.Key);
                if (expense != null)
                {
                    boxType.Value.Text = expense.Value.ToString();
                }
            }
        }

        protected void SaveFinances(object sender, EventArgs e)
        {
            if (Double.TryParse(TextBoxIncome.Text, out double income))
            {
                FinancialPlanController.ActivePlan.Income = income;
            }
            foreach (KeyValuePair<ExpenseType, TextBox> boxType in boxTypeList)
            {
                if (Double.TryParse(boxType.Value.Text, out double value))
                {
                    FinancialPlanController.ActivePlan.AddExpense(new Expense(boxType.Key, value, value));
                }
            }
            DBConnector.SaveFinancialPlans(FinancialPlanController.FinancialPlans, 1); // default user id
        }
    }
} 