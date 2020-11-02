using System;

namespace Stonks
{
    [Flags]
    public enum ExpenseType
    {
        Groceries = 0,
        Housing = 1,
        Transport =  2,
        Entertainment = 3,
        Health = 4,
        Shopping = 5,
        Utilities = 6,
        Other = 7
    }

    [Serializable]
    public class Expense : ICloneable
    {
        public ExpenseType Type { get; set; }
        public double Value { get; set; }
        public double PlannedValue { get; set; }

        public Expense ()
        {
        }

        public Expense (ExpenseType type, double value, double plannedValue)
        {
            Type = type;
            Value = value;
            PlannedValue = plannedValue;
        }
        
        public object Clone()
        {
            return new Expense(Type, Value, PlannedValue);
        }
    }
}
