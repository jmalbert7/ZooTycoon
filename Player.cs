using System;
using System.Collections.Generic;

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

        private bool SetCash(double delta, bool optional)
        {
            double tempCash = _cash;
            if ((tempCash += delta) >= 0 && optional)
            {
                _cash += delta;
                return true;
            }
            else if((tempCash += delta) < 0 && optional)
            {
                Console.WriteLine("You don't have enough money to do this operation.");
                return true;
            }
            else if((tempCash += delta) >= 0 && !optional)
            {
                _cash += delta;
                return true;
            }
            else
            {
                _cash += delta;
                return false;
            }
        }
        private double GetCash()
        {
            return _cash;
        }
        public void DisplayCash()
        {
            Console.WriteLine("Money in the Bank: {0:C}", GetCash());
        }
        public void ChangeCash(double delta, bool option)
        {
            if (SetCash(delta, option))
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
        public void PayMaintenanceCosts(IZoo zoo)
        {
            double cost = zoo.GetSumMaintenanceCosts();
            ChangeCash(-cost, false);
            Console.WriteLine("Mantenance costs deducted from you account: {0:C}", cost);
        }

    }
}
