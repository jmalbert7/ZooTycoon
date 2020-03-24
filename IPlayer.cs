using System.Collections.Generic;

namespace ZooTycoon
{
    public interface IPlayer
    {
        string DisplayName();
        void DisplayCash();
        void ChangeCash(double delta, bool optional);
        bool IsBankrupt();
        void PayMaintenanceCosts(IZoo zoo);

    }
}
