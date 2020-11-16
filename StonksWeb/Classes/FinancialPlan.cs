using System;
using System.Collections.Generic;
using System.Linq;

namespace StonksWeb
{
    [Serializable]
    class FinancialPlan : ICloneable
    {
        public DateTime DateCreated { get; set; }
        public double Income { get; set; }
        public double Savings { get; set; }
        public double PlannedSavings { get; set; }
        public List<FinancialGoal> FinancialGoals { get; set; }
        public List<Expense> Expenses { get; set; }
        public int DisplayData { get; set; }

        public FinancialPlan ()
        {
            DateCreated = DateTime.Now;
            FinancialGoals = new List<FinancialGoal>();
            Expenses = new List<Expense>();
        }

        public FinancialPlan (FinancialPlan copyFrom)
        {
            DateCreated = DateTime.Now;
            Income = copyFrom.Income;
            Savings = copyFrom.Savings;
            PlannedSavings = copyFrom.PlannedSavings;
            FinancialGoals = copyFrom.FinancialGoals;
            Expenses = copyFrom.Expenses;
        }

        public object Clone()
        {
            FinancialPlan clone = new FinancialPlan
            {
                Income = Income,
                Savings = Savings,
                PlannedSavings = PlannedSavings,
              //  FinancialGoals = (List<FinancialGoal>)FinancialGoals.Clone(),
               // Expenses = (List<Expense>)Expenses.Clone()
            };
            return clone;
        }

        public void AddFinancialGoal(FinancialGoal goal)
        {
            FinancialGoals.Add(goal);
        }

        //returns false if item not found
        public bool RemoveFinancialGoal(FinancialGoal goal)
        {
            return FinancialGoals.Remove(goal);
        }

        //adds new or replaces existing expense
        public void AddExpense(Expense expense)
        {
            if (Expenses.Select(x => x.Type == expense.Type).Count() != 0)
                Expenses.RemoveAll(x => x.Type == expense.Type);

            Expenses.Add(expense);
        }

        //adds new or replaces existing expense
        public void ModifyExpensePlannedValue(ExpenseType type, double value)
        {
            if (Expenses.Select(x => x.Type == type).Count() != 0)
            {
                var expense = Expenses.Where(x => x.Type == type).FirstOrDefault();
                expense.PlannedValue = value;
                Expenses.Add(expense);
            }
        }

        //returns false if item not found
        public bool RemoveExpense(Expense expense)
        {
            return Expenses.Remove(expense);
        }

        //returns null if item not found
        public Expense GetExpense(ExpenseType type)
        {
            return Expenses.Where(x => x.Type == type).FirstOrDefault();
        }

        public double GetSpendings()
        {
            try
            {
                return Expenses.Sum(x => x.Value);
            }
            catch 
            {
                return 0;
            }
        }

        public double GetMaxExpense()
        {
            try
            {
                return Expenses.Max(x => x.Value);
            }
            catch 
            {
                return 0;
            }
        }

        public double GetSavings(bool recalculate = true)
        {
            if (recalculate)
                RefreshSavings();
            return Savings;
        }

        public double GetPlannedSavings() {
            PlannedSavings = Income;

            foreach (Expense expense in Expenses) {
                PlannedSavings -= expense.PlannedValue;
            }

            return PlannedSavings;
        }

        public void RefreshSavings()
        {
            Savings = Income;
            Expenses.Select(x => Savings -= x.Value);
        }

    }
}
