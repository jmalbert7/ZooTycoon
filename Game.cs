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
        private readonly IMenu _endOfDayMenu;
        private readonly IZoo _zoo;

        public Game()
        {
            _gameMenu = new GameMenu();
            _purchaseMenu = new PurchaseAnimalMenu();
            _endOfDayMenu = new EndOfDayMenu();
            _baseCost = 50;
            _zoo = new Zoo();
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
                keepPurchasing = ChooseAnimal(1);
            } while (keepPurchasing == true || _zoo.GetCount() < 1);

            Console.Clear();
            Console.WriteLine("Total animals at {0}'s Zoo: {1}",_player.DisplayName(),_zoo.GetCount());
            _zoo.DisplayZooComposition();
            HoldScreen();
        }
        private bool ChooseAnimal(int age)
        {
            PurchaseAnimalOptions selection = (PurchaseAnimalOptions)_purchaseMenu.GetUserSelection(_player) - 1;
            if (selection == PurchaseAnimalOptions.Return)
                return false;
            else
            {
                PurchaseAnimal(selection, age);
                return true;
            }
        }
        private IAnimal CreateAnimal(PurchaseAnimalOptions animal, int age)
        {
            //See: https://docs.microsoft.com/en-us/dotnet/api/system.activator?redirectedfrom=MSDN&view=netframework-4.8
            string animalString = "ZooTycoon" + "." + animal.ToString();
            object[] arguments = new object[2] { age, _baseCost };
            System.Runtime.Remoting.ObjectHandle oh = Activator.CreateInstance("ZooTycoon", animalString, false, 0, null, arguments, null, null);
            IAnimal newAnimal = (IAnimal)oh.Unwrap();

            _zoo.Add(newAnimal);
            return newAnimal;
        }
        private void PurchaseAnimal(PurchaseAnimalOptions animal, int age)
        {
            IAnimal newAnimal = CreateAnimal(animal, age);
            bool purchaseOk = _player.ChangeCash(-newAnimal.PurchaseCost(), true);
            if (!purchaseOk)
            {
                Console.WriteLine("You don't have enough money to purchase this animal");
                _zoo.RemoveAtIndex(_zoo.GetCount() - 1);
                HoldScreen();
            }
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
            Random random = new Random();
            var numberOfEvents = Enum.GetNames(typeof(Events)).Length;
            var randomEvent = random.Next(0, numberOfEvents);
            switch ((Events)randomEvent)
            {
                case Events.Sickness:
                    Sickness();
                    break;
                case Events.AttendanceBoom:
                    AttendanceBoom();
                    break;
                case Events.Birth:
                    Birth();
                    break;
                default:
                    break;
            }

        }
        private void Birth()
        {
            Random random = new Random();
            var numberOfAnimals = _zoo.GetCount();
            var randomAnimal = random.Next(0, numberOfAnimals - 1);
            if (_zoo.ValidBirth(randomAnimal))
            {
                int babies = _zoo.GetBabiesAtIndex(randomAnimal);
                IAnimal newAnimal = null; ;
                for (int i = 0; i < babies; i++)
                {
                    newAnimal = CreateAnimal((PurchaseAnimalOptions)Enum.Parse(typeof(PurchaseAnimalOptions), _zoo.GetTypeAtIndex(randomAnimal)), 1);
                }
                if(babies > 1)
                    Console.WriteLine("Congrats! {0} new {1}s have been born!", babies, _zoo.GetTypeAtIndex(randomAnimal));
                else
                    Console.WriteLine("Congrats! A new {0} has been born!", _zoo.GetTypeAtIndex(randomAnimal));

            }
        }
        private void AttendanceBoom()
        {
            Random random = new Random();
            int val = random.Next(250, 501);
            double bonus = val * _zoo.GetTigerCount();
            Console.WriteLine("Tiger count: {0}, value: {1}, bonus: {2}", _zoo.GetTigerCount(), val, bonus);
            _player.ChangeCash(bonus, false);
            Console.WriteLine("Congrats! A boom in attendance has generated a {0:C} bonus for each Tiger in your zoo! Total bonus is {1:C}", val, bonus);
            _player.AddBonus(bonus);
        }
        private void Sickness()
        {
            string result = _zoo.Remove();
            if(result != "")
                Console.WriteLine("Unfortunately a {0} in your Zoo has passed away.", result);            
        }
        public bool RunGame()
        {
            int startOption = _gameMenu.GetUserSelection(_player) - 1;
            bool play = true;
            int endOption;
            bool done = false;
            if ((int)GameMenuOptions.PlayAgain == startOption)
            {
                //play game
                Console.Clear();
                _zoo.IncreaseAgeAllAnimals();
                _player.PayMaintenanceCosts(_zoo);
                RandomEvent();
                HoldScreen();
                do
                {
                    endOption = _endOfDayMenu.GetUserSelection(_player) - 1;
                    switch ((EndOfDay)endOption)
                    {
                        case EndOfDay.ViewZooSummary:
                            _zoo.DisplayZooComposition();
                            HoldScreen();
                            break;
                        case EndOfDay.PurchaseAdultAnimal:
                            ChooseAnimal(3);
                            HoldScreen();
                            break;
                        case EndOfDay.ViewMoney:
                            _player.DisplayCash();
                            HoldScreen();
                            break;
                        case EndOfDay.ViewDaySummary:
                            _player.DisplayEndOfDaySummary();
                            HoldScreen();
                            break;
                        case EndOfDay.Return:
                            done = true;
                            break;
                        default:
                            break;
                    }
                } while (done == false);

                _player.ClearEndOfDay();
            }
            else
                play = false;            
            

            if (play == false)                
                return false;
            else if (play == true && _player.IsBankrupt() == true)
            {
                Console.Clear();
                Console.WriteLine("You went bankrupt. \n GAME OVER :(:(:(");
                return false;
            }
            else if(play == true && _zoo.GetCount() <= 0)
            {
                Console.Clear();
                Console.WriteLine("No more animals left in your zoo. \n GAME OVER :(:(:(");
                return false;
            }
            else
                return true;
        }
    }
}
