using System;
using System.Collections.Generic;
using System.Linq;

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
        public void DisplayZooComposition()
        {
            foreach (var animal in Enum.GetValues(typeof(PurchaseAnimalOptions)))
            {
                if(animal.ToString() != "Return")
                {
                    var count = ZooList.Where(p => p.Type() == animal.ToString());
                    Console.WriteLine("Count of {0} is {1}", animal.ToString(), count.Count());
                }
            }
        }
        public void IncreaseAgeAllAnimals()
        {
            foreach (var animal in ZooList)
            {
                animal.increaseAge();
            }
        }
        public double GetSumMaintenanceCosts()
        {
            double sum = 0;
            foreach (var animal in ZooList)
            {
                sum = ZooList.Sum(p => p.GetMaintenanceCost());
            }
            return sum;
        }
    }
}
