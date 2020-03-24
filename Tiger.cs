﻿namespace ZooTycoon
{
    public class Tiger : IAnimal
    {
        private int _age;
        private int _numberOfBabies;
        private readonly double _maintenanceCost;
        private readonly double _profit;
        private static readonly double _purchaseCost = 10000;

        public Tiger(double baseCost)
        {
            _age = 1;
            _numberOfBabies = 1;
            _maintenanceCost = 5 * baseCost;
            //_purchaseCost = 10000;
            _profit = 0.2 * _purchaseCost;
        }

        public int GetAge()
        {
            return _age;
        }

        public double GetMaintenanceCost()
        {
            return _maintenanceCost;
        }

        public int GetNumberOfBabies()
        {
            return _numberOfBabies;
        }

        public double GetProfit()
        {
            return _profit;
        }

        public static double GetPurchaseCost()
        {
            return _purchaseCost;
        }

        public void increaseAge()
        {
            _age++;
        }

        public void removeAnimal()
        {
            throw new System.NotImplementedException();
        }
    }
}
