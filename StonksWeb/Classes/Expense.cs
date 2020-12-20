using System;

namespace StonksWeb
{
    [Flags]
    public enum ExpenseType
    {
        Housing,
        Groceries,
        Transportation,
        Entertainment,
        Health,
        Shopping,
        Utilities,
        Other
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
