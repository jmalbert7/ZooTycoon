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
            HoldScreen();
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
            int option = _gameMenu.GetUserSelection() - 1;
            bool play = true;
            if ((int)GameMenuOptions.PlayAgain == option)
            {
                _player.DisplayCash();
                _player.ChangeCash(-500.00);
                Console.WriteLine(_purchaseMenu.GetUserSelection()); 
                HoldScreen();
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
