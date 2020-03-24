using System;

namespace ZooTycoon
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        private double _cash;
        public bool Bankrupt { get; set; }

        public Player(string name)
        {
            Name = name;
            _cash = 1000000;
            Bankrupt = false;
        }

        private bool SetCash(double delta)
        {
            double tempCash = _cash;
            if ((tempCash += delta) > 0)
            {
                _cash += delta;
                return true;
            }
            else
                return false;
        }
        private double GetCash()
        {
            return _cash;
        }
        public void DisplayCash()
        {
            Console.WriteLine("Money in the Bank: {0:C}", GetCash());
        }
        public void ChangeCash(double delta)
        {
            if (SetCash(delta))
                DisplayCash();
            else
            {
                Console.WriteLine("You ran out of money! Closing down...");
                Bankrupt = true;
            }
            return;

        }
        public string DisplayName()
        {
            return Name;
        }
        public bool IsBankrupt()
        {
            return Bankrupt;
        }

    }
}
