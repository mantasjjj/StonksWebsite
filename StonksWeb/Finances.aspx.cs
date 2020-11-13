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
                { ExpenseType.Transport, TextBoxTransportation },
                { ExpenseType.Entertainment, TextBoxEntertainment },
                { ExpenseType.Shopping, TextBoxShopping },
                { ExpenseType.Health, TextBoxHealth },
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

        public void LoadExpenses()
        {
            //Income
            if (TextBoxIncome == null)
            {
                TextBoxIncome.Text = "0";
            }
            else
            {
                TextBoxIncome.Text = Convert.ToString(FinancialPlanController.ActivePlan.Income);
            }

            //Expenses
            boxTypeList.ForEach(x => x.Value.Text = (FinancialPlanController.ActivePlan.GetExpense(x.Key) != null) ? Convert.ToString(FinancialPlanController.ActivePlan.GetExpense(x.Key).Value) : "0");
        }

        protected void saveFinances(object sender, EventArgs e)
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
        }
    }
} 