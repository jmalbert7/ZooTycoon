namespace ZooTycoon
{
    public interface IZoo
    {
        void Add(IAnimal newAnimal);
        void Remove();
        int GetCount();
        void DisplayZooComposition();
        void IncreaseAgeAllAnimals();
        double GetSumMaintenanceCosts();
    }
}
