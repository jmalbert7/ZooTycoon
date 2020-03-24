namespace ZooTycoon
{
    public class Turtle : IAnimal
    {
        private int _age;
        private int _numberOfBabies;
        private readonly double _maintenanceCost;
        private readonly double _profit;
        private static readonly double _purchaseCost = 100;

        public Turtle()
        {
            _age = 1;
            _numberOfBabies = 10;
            _maintenanceCost = 10;
            _profit = 0.05 * _purchaseCost;
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
    }
}
