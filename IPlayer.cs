using System.Collections.Generic;

namespace ZooTycoon
{
    public interface IPlayer
    {
        string DisplayName();
        void DisplayCash();
        bool ChangeCash(double delta, bool optional);
        bool IsBankrupt();
        void PayMaintenanceCosts(IZoo zoo);
        void AddBonus(double bonus);
        void AddExpense(double expense);
        double GetProfit();
        void ClearEndOfDay();
        void DisplayEndOfDaySummary();

    }
}
