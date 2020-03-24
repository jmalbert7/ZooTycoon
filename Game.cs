using System;

namespace ZooTycoon
{
    public class Game
    {
        private readonly IMenu _gameMenu;
        private IPlayer _player;
        private readonly double _baseCost;
        private readonly IMenu _purchaseMenu;
        private readonly IZoo _zoo;

        public Game()
        {
            _gameMenu = new GameMenu();
            _purchaseMenu = new PurchaseAnimalMenu();
            _baseCost = 50;
            _zoo = new Zoo();
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Zoo Tycoon!");
            InitializePlayer();
            HoldScreen();
            Console.WriteLine("\nTo begin, you will purchase at least one baby animal from the following menu.");
            HoldScreen();
            bool keepPurchasing;
            do
            {
                keepPurchasing = PurchaseBabies();
            } while (keepPurchasing == true || _zoo.GetCount() < 1);

            Console.Clear();
            Console.WriteLine("Total animals at {0}'s Zoo: {1}",_player.DisplayName(),_zoo.GetCount());
            HoldScreen();
        }
        public bool PurchaseBabies()
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
        private void PurchaseAnimal(PurchaseAnimalOptions animal, int age)
        {
            //See: https://docs.microsoft.com/en-us/dotnet/api/system.activator?redirectedfrom=MSDN&view=netframework-4.8
            string animalString = "ZooTycoon" + "." + Enum.GetName(typeof(PurchaseAnimalOptions), animal);
            object[] arguments = new object[2]{ age, _baseCost };
            System.Runtime.Remoting.ObjectHandle oh = Activator.CreateInstance("ZooTycoon", animalString, false, 0, null, arguments, null, null);
            IAnimal newAnimal = (IAnimal)oh.Unwrap();

            _zoo.Add(newAnimal);
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

        public void InitializePlayer()
        {
            Console.WriteLine("Please Enter Your Name");
            _player = new Player(Console.ReadLine());
            Console.WriteLine("Hello {0}! Let's get started!", _player.DisplayName());
        }

        public bool RunGame()
        {
            int option = _gameMenu.GetUserSelection(_player) - 1;
            bool play = true;
            if ((int)GameMenuOptions.PlayAgain == option)
            {
                Console.WriteLine("In main game loop");
                //play game
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
