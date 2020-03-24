using System;
using System.Collections.Generic;

namespace ZooTycoon
{
    public class Game
    {
        private readonly IMenu _gameMenu;
        private IPlayer _player;
        private readonly double _baseCost;
        private readonly IMenu _purchaseMenu;
        private readonly IZoo _zoo;
        private List<string> _events;
        private double _bonus;

        public Game()
        {
            _gameMenu = new GameMenu();
            _purchaseMenu = new PurchaseAnimalMenu();
            _baseCost = 50;
            _zoo = new Zoo();
            _events = new List<string>();
            _bonus = 0;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Zoo Tycoon!");
            InitializePlayer();
            //HoldScreen();
            Console.WriteLine("\nTo begin, you will purchase at least one baby animal from the following menu.");
            HoldScreen();
            bool keepPurchasing;
            do
            {
                keepPurchasing = PurchaseBabies();
            } while (keepPurchasing == true || _zoo.GetCount() < 1);

            Console.Clear();
            Console.WriteLine("Total animals at {0}'s Zoo: {1}",_player.DisplayName(),_zoo.GetCount());
            _zoo.DisplayZooComposition();
            HoldScreen();
        }
        private bool PurchaseBabies()
        {
            PurchaseAnimalOptions selection = (PurchaseAnimalOptions)_purchaseMenu.GetUserSelection(_player) - 1;
            if (selection == PurchaseAnimalOptions.Return)
                return false;
            else
            {
                PurchaseAnimal(selection, 1);
                return true;
            }
        }
        private IAnimal CreateAnimal(PurchaseAnimalOptions animal, int age)
        {
            //See: https://docs.microsoft.com/en-us/dotnet/api/system.activator?redirectedfrom=MSDN&view=netframework-4.8
            string animalString = "ZooTycoon" + "." + Enum.GetName(typeof(PurchaseAnimalOptions), animal);
            object[] arguments = new object[2] { age, _baseCost };
            System.Runtime.Remoting.ObjectHandle oh = Activator.CreateInstance("ZooTycoon", animalString, false, 0, null, arguments, null, null);
            IAnimal newAnimal = (IAnimal)oh.Unwrap();

            _zoo.Add(newAnimal);
            return newAnimal;
        }
        private void PurchaseAnimal(PurchaseAnimalOptions animal, int age)
        {
            IAnimal newAnimal = CreateAnimal(animal, age);
            _player.ChangeCash(-newAnimal.PurchaseCost(), true);
        }
        public void HoldScreen()
        {
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
        public void EndGame()
        {
            Console.Write("Press any key to exit...");
            Console.ReadLine();
        }

        private void InitializePlayer()
        {
            Console.WriteLine("Please Enter Your Name");
            _player = new Player(Console.ReadLine());
            Console.WriteLine("Hello {0}! Let's get started!", _player.DisplayName());
        }
        private void RandomEvent()
        {
            //Random random = new Random();
            //var numberOfEvents = Enum.GetNames(typeof(Events)).Length;
            //var randomEvent = random.Next(0, numberOfEvents);
            //switch ((Events)randomEvent)
            //{
            //    case Events.Sickness:
            //        Sickness();
            //        break;
            //    case Events.AttendanceBoom:
            //        AttendanceBoom();
            //        break;
            //    case Events.Birth:
            //        Birth();
            //        break;
            //    default:
            //        break;
            //}
            Birth();
        }
        private void Birth()
        {
            Random random = new Random();
            var numberOfAnimals = _zoo.GetCount();
            Console.WriteLine("number of animals before {0}", numberOfAnimals);
            var randomAnimal = random.Next(0, numberOfAnimals - 1);
            Console.WriteLine("random animal: {0}", randomAnimal);
            if (_zoo.ValidBirth(randomAnimal))
            {
                IAnimal newAnimal = CreateAnimal((PurchaseAnimalOptions)randomAnimal, 1);
                //_zoo.Add(newAnimal);
                Console.WriteLine("Congrats! A new {0} has been born!", newAnimal.Type());
            }
            Console.WriteLine("number of animals after {0}", _zoo.GetCount());
        }
        private void AttendanceBoom()
        {
            Random random = new Random();
            int val = random.Next(250, 501);
            double bonus = val * _zoo.GetTigerCount();
            Console.WriteLine("Tiger count: {0}, value: {1}, bonus: {2}", _zoo.GetTigerCount(), val, bonus);
            _player.ChangeCash(bonus, false);
            Console.WriteLine("Congrats! A boom in attendance has generated a {0:C} bonus for each Tiger in your zoo! Total bonus is {1:C}", val, bonus);
            _bonus = bonus;
        }
        private void Sickness()
        {
            string result = _zoo.Remove();
            if(result != "")
                Console.WriteLine("Unfortunately a {0} in your Zoo has passed away.", result);            
        }
        public bool RunGame()
        {
            int option = _gameMenu.GetUserSelection(_player) - 1;
            bool play = true;
            if ((int)GameMenuOptions.PlayAgain == option)
            {
                //play game
                Console.Clear();
                _bonus = 0;
                _zoo.IncreaseAgeAllAnimals();
                _player.PayMaintenanceCosts(_zoo);
                RandomEvent();
                HoldScreen();
            }
            else
                play = false;            
            

            if (play == true && _player.IsBankrupt() == false)
                return true;
            else
                return false; 
        }
    }
}
