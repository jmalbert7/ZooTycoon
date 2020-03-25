using System;
using System.Collections.Generic;

namespace ZooTycoon
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        private double _cash;
        public bool Bankrupt { get; set; }
        private double _bonus;
        private double _expenses;

        public Player(string name)
        {
            Name = name;
            _cash = 100000;
            Bankrupt = false;
            _bonus = 0;
            _expenses = 0;
        }

        private bool SetCash(double delta, bool optional)
        {
            double tempCash = _cash;
            //Optional transaction and enough money to cover
            if ((tempCash += delta) >= 0 && optional)
            {
                _cash += delta;
                return true;
            }
            //Optional transaction and not enough money to cover
            else if((tempCash += delta) < 0 && optional)
            {
                //Console.WriteLine("You don't have enough money to do this operation.");
                return false;
            }
            //Non-optional transaction and enough money to cover
            else if((tempCash += delta) >= 0 && !optional)
            {
                _cash += delta;
                return true;
            }
            //Non-optional transaction and not enough money to cover. Ends the game because player is bankrupt
            else
            {
                _cash += delta;
                Bankrupt = true;
                return true;
            }
        }
        private double GetCash()
        {
            return _cash;
        }
        private void SetBonus(double bonus)
        {
            SetCash(bonus, false);
            _bonus += bonus;
        }
        private double GetBonus()
        {
            return _bonus;
        }
        private double GetExpenses()
        {
            return _expenses;
        }
        private void SetExpenses(double expenses)
        {

            SetCash(-expenses, false);
            _expenses += expenses;
        }
        private double Profit()
        {
            return _bonus - _expenses;
        }
        public void ClearEndOfDay()
        {
            _bonus = 0;
            _expenses = 0;
        }
        public void AddBonus(double bonus)
        {
            SetBonus(bonus);
        }
        public void AddExpense(double expense)
        {
            SetExpenses(expense);
        }
        public double GetProfit()
        {
            return Profit();
        }
        public void DisplayCash()
        {
            Console.WriteLine("Money in the Bank: {0:C}", GetCash());
        }
        public bool ChangeCash(double delta, bool option)
        {
            if (SetCash(delta, option) && Bankrupt == false)
            {
                DisplayCash();
                return true;
            }
            else if (SetCash(delta, option) && Bankrupt == true)
            {
                Bankrupt = true;
                return false;
            }
            else
                return false;
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
            SetExpenses(cost);
            Console.WriteLine("Mantenance costs deducted from you account: {0:C}", cost);
        }
        public void DisplayEndOfDaySummary()
        {
            Console.WriteLine("Total Expenses: {0:C}", GetExpenses());
            Console.WriteLine("Total Bonus: {0:C}", GetBonus());
            Console.WriteLine("Profit: {0:C}", GetProfit());
        }

    }
}
