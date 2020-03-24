namespace ZooTycoon
{
    public class Penguin : IAnimal
    {
        private int _age;
        private int _numberOfBabies;
        private readonly double _maintenanceCost;
        private readonly double _profit;
        private static readonly double _purchaseCost = 1000;

        public Penguin(double baseCost)
        {
            _age = 1;
            _numberOfBabies = 5;
            _maintenanceCost = baseCost;
            _profit = 0.1 * _purchaseCost;
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
