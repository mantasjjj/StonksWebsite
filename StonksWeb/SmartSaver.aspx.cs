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
        Dictionary<ExpenseType, object> sliderTypeList; //need help with the type of "sliders", object seems to be read-only

        protected void Page_Load(object sender, EventArgs e)
        {
            sliderTypeList = new Dictionary<ExpenseType, object>()
            {
                { ExpenseType.Housing, HousingSlider},
                { ExpenseType.Groceries, GroceriesSlider },
                { ExpenseType.Transportation, TransportationSlider },
                { ExpenseType.Entertainment, EntertainmentSlider },
                { ExpenseType.Health, HealthSlider },
                { ExpenseType.Shopping, ShoppingSlider },
                { ExpenseType.Utilities, UtilitiesSlider },
                { ExpenseType.Other, OtherSlider }
            };

            foreach (KeyValuePair<ExpenseType, object> sliderType in sliderTypeList)
            {
                var expense = FinancialPlanController.ActivePlan.GetExpense(sliderType.Key);
                if (expense != null)
                {
                    //assign the Value of the slider
                }
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            boxTypeList = new Dictionary<ExpenseType, TextBox>()
            {
                { ExpenseType.Housing, TextBoxHousingActual },
                { ExpenseType.Groceries, TextBoxGroceriesActual },
                { ExpenseType.Transportation, TextBoxTransportationActual },
                { ExpenseType.Entertainment, TextBoxEntertainmentActual },
                { ExpenseType.Health, TextBoxHealthActual },
                { ExpenseType.Shopping, TextBoxShoppingActual },
                { ExpenseType.Utilities, TextBoxUtilitiesActual },
                { ExpenseType.Other, TextBoxOtherActual }
            };

            Double savings = FinancialPlanController.ActivePlan.Income - FinancialPlanController.ActivePlan.GetSpendings();
            Income.InnerText = FinancialPlanController.ActivePlan.Income.ToString("€#.#");
            Spendings.InnerText = FinancialPlanController.ActivePlan.GetSpendings().ToString("€#.#");
            Savings.InnerText = savings.ToString("€#.#");
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