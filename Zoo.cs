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

        public string Remove()
        {
            if (GetCount() > 0)
            {
                int index = RandomIndex();
                string type = ZooList[index].Type();
                ZooList.RemoveAt(index);
                return type;
            }
            else
                return "";
        }
        public void RemoveAtIndex(int index)
        {
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
        public int GetTigerCount()
        {
            return ZooList.Where(p => p.Type() == "Tiger").Count();
        }
        public bool ValidBirth(int index)
        {
            if (ZooList[index].GetAge() > 3)
                return true;
            else
                return false;
        }
        public string GetTypeAtIndex(int index)
        {
            return ZooList[index].Type();
        }
        public int GetBabiesAtIndex(int index)
        {
            return ZooList[index].GetBabies();
        }
    }
}
