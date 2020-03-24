using System;
using System.Collections.Generic;

namespace ZooTycoon
{
    public class Zoo : IZoo
    {
        public List<IAnimal> ZooList { get; set; }
        public Zoo()
        {
            ZooList = new List<IAnimal>();
        }
        public void Add(IAnimal newAnimal)
        {
            ZooList.Add(newAnimal);
        }

        public void Remove()
        {
            int index = RandomIndex();
            ZooList.RemoveAt(index);
        }
        public int GetCount()
        {
            return ZooList.Count;
        }
        private int RandomIndex()
        {
            Random random = new Random();
            return random.Next(0, ZooList.Count);
        }
    }
}
