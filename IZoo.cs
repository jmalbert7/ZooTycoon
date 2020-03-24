namespace ZooTycoon
{
    public interface IZoo
    {
        void Add(IAnimal newAnimal);
        void Remove();
        int GetCount();
    }
}
