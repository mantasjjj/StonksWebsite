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
            var HousingSlider = Housing;
            var GroceriesSlider = Housing;
            var TransportationSlider = Transportation;
            var EntertainmentSlider = Entertainment;
            var HealthSlider = Health;
            var ShoppingSlider = Shopping;
            var UtilitiesSlider = Utilities;
            var OtherSlider = Other;

            HousingSlider.Value = FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Housing).Value.ToString();
            GroceriesSlider.Value = FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Groceries).Value.ToString();
            TransportationSlider.Value = FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Transportation).Value.ToString();
            EntertainmentSlider.Value = FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Entertainment).Value.ToString();
            HealthSlider.Value = FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Health).Value.ToString();
            ShoppingSlider.Value = FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Shopping).Value.ToString();
            UtilitiesSlider.Value = FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Utilities).Value.ToString();
            OtherSlider.Value = FinancialPlanController.ActivePlan.GetExpense(ExpenseType.Other).Value.ToString();
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
            foreach (KeyValuePair<ExpenseType, TextBox> boxType in boxTypeList)
            {
                var expense = FinancialPlanController.ActivePlan.GetExpense(boxType.Key);
                if (expense != null)
                {
                    boxType.Value.Text = expense.Value.ToString();
                }
            }
        }


        protected void SetRangeSlider()
        {
        }


    }
}