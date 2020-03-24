namespace ZooTycoon
{
    public interface IZoo
    {
        void Add(IAnimal newAnimal);
        string Remove();
        int GetCount();
        void DisplayZooComposition();
        void IncreaseAgeAllAnimals();
        double GetSumMaintenanceCosts();
        int GetTigerCount();
        bool ValidBirth(int index);
    }
}
