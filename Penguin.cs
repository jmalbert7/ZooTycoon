namespace ZooTycoon
{
    public class Penguin : IAnimal
    {
        private int _age;
        private int _numberOfBabies;
        private readonly double _maintenanceCost;
        private readonly double _profit;
        private static readonly double _purchaseCost = 1000;
        private static readonly string _type = "Penguin";

        public Penguin()
        {
            _age = 1;
            _numberOfBabies = 5;
            _maintenanceCost = 25;
            _profit = 0.1 * _purchaseCost;
        }
        public Penguin(int age, double baseCost)
        {
            _age = age;
            _maintenanceCost = baseCost;
            _numberOfBabies = 5;
            _profit = 0.1 * _purchaseCost;
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
