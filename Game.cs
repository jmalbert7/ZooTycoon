using System;

namespace ZooTycoon
{
    public class Game
    {
        private readonly IMenu _gameMenu;
        private IPlayer _player;
        private readonly double _baseCost;
        private readonly IMenu _purchaseMenu;

        public Game()
        {
            _gameMenu = new GameMenu();
            _purchaseMenu = new PurchaseAnimalMenu();
            _baseCost = 50;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Zoo Tycoon!");
            InitializePlayer();
            Console.Write("Starting funds: "); _player.DisplayCash();
            PurchaseBabies();
            HoldScreen();
        }
        public void PurchaseBabies()
        {
            Console.WriteLine("\nTo begin, you will purchase at least one baby animal from the following menu.");
            HoldScreen();
            Console.WriteLine("purchase babies selection" +_purchaseMenu.GetUserSelection(_player));

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
