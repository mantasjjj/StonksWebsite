using Stonks;
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
        FinancialPlan financialPlan = new FinancialPlan();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_Render(object sender, EventArgs e)
        {
            TextBoxIncome.Text = financialPlan.Income.ToString();
        }

        protected void saveFinances(object sender, EventArgs e)
        {
            financialPlan.Income = Double.Parse(TextBoxIncome.Text);
            financialPlan.AddExpense(new Expense(ExpenseType.Housing, Double.Parse(TextBoxHousing.Text), Double.Parse(TextBoxHousing.Text)));
            financialPlan.AddExpense(new Expense(ExpenseType.Groceries, Double.Parse(TextBoxGroceries.Text), Double.Parse(TextBoxGroceries.Text)));
            financialPlan.AddExpense(new Expense(ExpenseType.Transport, Double.Parse(TextBoxTransportation.Text), Double.Parse(TextBoxTransportation.Text)));
            financialPlan.AddExpense(new Expense(ExpenseType.Entertainment, Double.Parse(TextBoxEntertainment.Text), Double.Parse(TextBoxEntertainment.Text)));
            financialPlan.AddExpense(new Expense(ExpenseType.Shopping, Double.Parse(TextBoxShopping.Text), Double.Parse(TextBoxShopping.Text)));
            financialPlan.AddExpense(new Expense(ExpenseType.Health, Double.Parse(TextBoxHealth.Text), Double.Parse(TextBoxHealth.Text)));
            financialPlan.AddExpense(new Expense(ExpenseType.Utilities, Double.Parse(TextBoxUtilities.Text), Double.Parse(TextBoxUtilities.Text)));
            financialPlan.AddExpense(new Expense(ExpenseType.Other, Double.Parse(TextBoxOther.Text), Double.Parse(TextBoxOther.Text)));
        }
    }
}