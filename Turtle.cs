namespace ZooTycoon
{
    public class Turtle : IAnimal
    {
        private int _age;
        private int _numberOfBabies;
        private readonly double _maintenanceCost;
        private readonly double _profit;
        private static readonly double _purchaseCost = 100;
        private static readonly string _type = "Turtle";


        public Turtle()
        {
            _age = 1;
            _numberOfBabies = 10;
            _maintenanceCost = 10;
            _profit = 0.05 * _purchaseCost;
            
        }
        public Turtle(int age, double baseCost)
            :this()
        {
            _age = age;
            _maintenanceCost = 0.5 * baseCost;
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
    }
}
