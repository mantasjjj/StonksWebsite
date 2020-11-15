using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StonksWeb
{
    public partial class SmartSaver : Page
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
            foreach (KeyValuePair<ExpenseType, TextBox> boxType in boxTypeList)
            {
                var expense = FinancialPlanController.ActivePlan.GetExpense(boxType.Key);
                if (expense != null)
                {
                    boxType.Value.Text = expense.Value.ToString();
                }
            }
        }

    }
}