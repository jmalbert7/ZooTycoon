namespace ZooTycoon
{
    public interface IPlayer
    {
        string DisplayName();
        void DisplayCash();
        void ChangeCash(double delta, bool optional);
        bool IsBankrupt();

    }
}
