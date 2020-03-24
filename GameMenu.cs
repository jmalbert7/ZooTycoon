using System;

namespace ZooTycoon
{
    /*The purpose of this class is displaying the game menu options to the user,
     * reading in and validating the user's selection, and returning the user's 
     * selection to the Game class. The Game class instantiates a GameMenu object
     * and handles routing the user's valid selection.
     */
    public class GameMenu : IMenu
    {
        public string Name { get; private set; }

        public GameMenu()
        {
            Name = "Game Menu";
        }

        public void DisplayName()
        {
            Console.Clear();
            Console.WriteLine(Name);
        }

        public void DisplayOptions()
        {
            Console.WriteLine("1. Play Again");
            Console.WriteLine("2. Quit");
        }

        public int GetUserSelection()
        {
            DisplayName();
            ValidateStringToInt selection = new ValidateStringToInt("");
            bool isValid;
            do
            {
                DisplayOptions();
                selection.StringInput = Console.ReadLine();
                selection.ValidateUserSelection();
                isValid = (selection.IsValid && ValidateMenuOption(selection.IntOutput - 1));
                if(isValid == false)
                    Console.WriteLine("Sorry, that is not an option.");
            } while (isValid == false);

            return selection.IntOutput;            
        }

        public bool ValidateMenuOption(int input)
        {
            if (Enum.IsDefined(typeof(GameMenuOptions), input))
                return true;
            else
                return false;
        }

        
    }
}
