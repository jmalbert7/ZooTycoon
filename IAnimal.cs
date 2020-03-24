namespace ZooTycoon
{
    public interface IAnimal
    {
        double PurchaseCost();
        double GetMaintenanceCost();
        double GetProfit();
        int GetAge();
        int GetNumberOfBabies();
        void increaseAge();
        void removeAnimal();

    }
}
