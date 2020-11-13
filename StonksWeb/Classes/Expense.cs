using System;

namespace StonksWeb
{
    [Flags]
    public enum ExpenseType
    {
        Groceries = 1,
        Housing = 2,
        Transport =  4,
        Entertainment = 8,
        Health = 16,
        Shopping = 32,
        Utilities = 64,
        Other = 128
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
