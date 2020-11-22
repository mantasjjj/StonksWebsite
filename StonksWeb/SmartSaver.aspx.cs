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
        Dictionary<ExpenseType, global::System.Web.UI.HtmlControls.HtmlInputGenericControl> sliderTypeList;
        Dictionary<ExpenseType, TextBox> textBoxTypeList;

        protected void Page_Load(object sender, EventArgs e)
        {
            sliderTypeList = new Dictionary<ExpenseType, global::System.Web.UI.HtmlControls.HtmlInputGenericControl>()
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
            textBoxTypeList = new Dictionary<ExpenseType, TextBox>()
            {
                { ExpenseType.Housing, TextBoxHousing},
                { ExpenseType.Groceries, TextBoxGroceries },
                { ExpenseType.Transportation, TextBoxTransportation },
                { ExpenseType.Entertainment, TextBoxEntertainment },
                { ExpenseType.Health, TextBoxHealth },
                { ExpenseType.Shopping, TextBoxShopping },
                { ExpenseType.Utilities, TextBoxUtilities },
                { ExpenseType.Other, TextBoxOther }
            };

            foreach (KeyValuePair<ExpenseType, global::System.Web.UI.HtmlControls.HtmlInputGenericControl> sliderType in sliderTypeList)
            {
                var expense = FinancialPlanController.ActivePlan.GetExpense(sliderType.Key);
                if (expense != null)
                {
                    sliderType.Value.Value = expense.Value.ToString();
                }
            }

            foreach (KeyValuePair<ExpenseType, TextBox> boxType in textBoxTypeList)
            {
                var expense = FinancialPlanController.ActivePlan.GetExpense(boxType.Key);
                if (expense != null)
                {
                    boxType.Value.Text = expense.Value.ToString();
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