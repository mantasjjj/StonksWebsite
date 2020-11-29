using System;
using System.Threading.Tasks;

namespace StonksWeb
{
    public delegate void Notify();  // delegate

    [Serializable]
    class FinancialGoal : ICloneable
    {
        public static bool UseYears { get; set; }

        public double Value { get; set; }
        public String Name { get; set; }
        public double AllocatedFunds { get; set; }
        public double TimeToDeadline { get; set; } // if deadline not determined, then equals -1

        public delegate void DeadlineReachedEventHandler(object source, EventArgs args);
        public event DeadlineReachedEventHandler DeadlineReached; // event

        public FinancialGoal(double value, String name)
        {
            Value = value;
            Name = name;
            AllocatedFunds = 0;
            TimeToDeadline = -1;
        }

        public bool SetFundsByDeadline(DateTime dealineIn)
        {
            TimeToDeadline = (DateTime.Now - dealineIn).TotalDays / (UseYears ? 365 : 30);
            AllocatedFunds = Value / TimeToDeadline;
            DeadlineReached += SmartSaver.OnDeadlineReached;
            OnDeadlineReached(TimeSpan.FromDays(TimeToDeadline * (UseYears ? 365 : 30)));
            return true;
        }

        public static string GetEstimatedTime(double Savings, double Value, int Measurements)
        {
            if (Measurements == 0) {
                return (Convert.ToInt32(Value / Savings)).ToString("# months");
            }
            else
            {
                return (Convert.ToInt32(Value / Savings / 12)).ToString("# years");
            }
            
        }

        public bool SetDeadlineByFunds(double value)
        {
            if (value < 0)
            {
                return false; // error
            }    

            AllocatedFunds = value;

            if (AllocatedFunds == 0)
            {
                TimeToDeadline = -1;
                return true;
            }

            TimeToDeadline = Value / AllocatedFunds;
            return true;
        }

        public object Clone()
        {
            var clone = new FinancialGoal(Value, Name);
            clone.AllocatedFunds = AllocatedFunds;
            clone.TimeToDeadline = TimeToDeadline;
            return clone;
        }

        protected virtual async void OnDeadlineReached(TimeSpan ExecutionTime)
        {
            try
            {
                await Task.Delay(ExecutionTime);
            }
            catch
            {
                // exception thrown, because deadline is in the past. Call anyway.
            }
            finally
            {
                //if DeadlineReached is not null then call delegate
                DeadlineReached?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
