﻿namespace ZooTycoon
{
    public class Tiger : IAnimal
    {
        private int _age;
        private int _numberOfBabies;
        private readonly double _maintenanceCost;
        private readonly double _profit;
        private static readonly double _purchaseCost = 10000;
        private static readonly string _type = "Tiger";

        public Tiger()
        {
            _age = 1;
            _numberOfBabies = 1;
            _maintenanceCost = 50;         
            _profit = 0.2 * _purchaseCost;
        }
        public Tiger(int age, double baseCost)
        {
            _age = age;
            _maintenanceCost = 5 * baseCost;
            _numberOfBabies = 1;
            _profit = 0.2 * _purchaseCost;
                       
        }

        public string Type()
        {
            return _type;
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

        public double PurchaseCost()
        {
            return _purchaseCost;
        }

        public void removeAnimal()
        {
            throw new System.NotImplementedException();
        }
        public int GetBabies()
        {
            return _numberOfBabies;
        }
    }
}
