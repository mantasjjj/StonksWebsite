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
            TextBoxIncome.Text = Global.financialPlan.Income.ToString();
            foreach (KeyValuePair<ExpenseType, TextBox> boxType in boxTypeList)
            {
                var expense = Global.financialPlan.GetExpense(boxType.Key);
                if (expense != null)
                {
                    boxType.Value.Text = expense.Value.ToString();
                }
            }
        }

        protected void saveFinances(object sender, EventArgs e)
        {
            if (Double.TryParse(TextBoxIncome.Text, out double income))
            {
                Global.financialPlan.Income = income;
            }
            foreach (KeyValuePair<ExpenseType, TextBox> boxType in boxTypeList)
            {
                if (Double.TryParse(boxType.Value.Text, out double value))
                {
                    Global.financialPlan.AddExpense(new Expense(boxType.Key, value, value));
                }
            }
        }
    }
}