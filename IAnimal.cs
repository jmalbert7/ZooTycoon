namespace ZooTycoon
{
    public interface IAnimal
    {
        //double GetPurchaseCost();
        double GetMaintenanceCost();
        double GetProfit();
        int GetAge();
        int GetNumberOfBabies();
        void increaseAge();
        void removeAnimal();

    }
}
