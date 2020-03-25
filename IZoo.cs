namespace ZooTycoon
{
    public interface IZoo
    {
        void Add(IAnimal newAnimal);
        string Remove();
        void RemoveAtIndex(int index);
        int GetCount();
        void DisplayZooComposition();
        void IncreaseAgeAllAnimals();
        double GetSumMaintenanceCosts();
        int GetTigerCount();
        bool ValidBirth(int index);
        string GetTypeAtIndex(int index);
        int GetBabiesAtIndex(int index);
    }
}
